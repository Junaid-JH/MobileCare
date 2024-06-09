using System.Security.Claims;
using Dapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MobileCare.Data;
using MobileCare.Models.ViewModels;

namespace MobileCare.Controllers
{
    [Authorize(Roles = "Careworker")]
    public class CareworkerController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CareworkerController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> GetBookingAsync(int id)
        {
            /*Validate that the careworker's ID matches the ID provided in the URL parameters by comparing
             the careworker's ID extracted from the authentication claims with the ID provided in the URL parameters
            */
            if (
                (bool)
                    !User.FindFirst(ClaimTypes.NameIdentifier)
                        ?.Value.Equals(id.ToString(), StringComparison.OrdinalIgnoreCase)
            )
            {
                return Forbid(); // Return 403 Forbidden if the careworker tries to access data with a different ID
            }

            // Define the SQL query with INNER JOIN
            string sql =
                @"
                SELECT 
    Bookings.Id As BookingId, 
    Bookings.Date, 
    Bookings.StartTime, 
    Bookings.EndTime, 
    Bookings.PatientId,
    Patients.Id AS PatientId,
    Patients.AddressId,
    patient.FullName AS PatientFullName,
    careworker.FullName AS CareworkerFullName,
    Bookings.ApplicationUserId,
    Addresses.*
FROM 
    Bookings
INNER JOIN 
    Patients ON Bookings.PatientId = Patients.Id
INNER JOIN 
    ApplicationUsers AS patient ON Patients.ApplicationUserId = patient.Id
INNER JOIN 
    Addresses ON Patients.AddressId = Addresses.Id
INNER JOIN 
    ApplicationUsers AS careworker ON Bookings.ApplicationUserId = careworker.Id
WHERE 
    careworker.Id = @id


";

            // Execute the query and project the result into the DTO
            using (var connection = _context.Database.GetDbConnection())
            {
                var bookings = await connection.QueryAsync<BookingViewModel>(sql, new { id });

                return View(bookings);
            }
        }

        public async Task<IActionResult> GetActivityAsync(
            string bookingId,
            string patientName,
            string careworkerName,
            string careworkerUserId
        )
        {
            // Retrieve previous page info from the query parameters

            ViewData["BookingId"] = bookingId;
            ViewData["PatientName"] = patientName;
            ViewData["CareworkerName"] = careworkerName;
            ViewData["CareworkerUserId"] = careworkerUserId;

            if (!int.TryParse(bookingId, out int bookingIdInt))
            {
                // Handle the case where bookingId is not a valid integer

                return BadRequest("BookingId must be a valid integer.");
            }

            // Define the SQL query with INNER JOIN
            string sql =
                @"
SELECT BookingActivities.BookingId,
        BookingActivities.Id,
		BookingActivities.ActivityId,
		BookingActivities.BookingNote,
		Activities.Title,
		BookingActivities.ActivityNote

FROM    BookingActivities

INNER JOIN Activities ON BookingActivities.ActivityId = Activities.Id
WHERE      BookingActivities.BookingId = @bookingIdInt
";

            // Execute the query and project the result into the DTO
            using (var connection = _context.Database.GetDbConnection())
            {
                var bookingActivities = await connection.QueryAsync<BookingActivityViewModel>(
                    sql,
                    new { bookingIdInt }
                );

                return View(bookingActivities);
            }
        }

        [HttpPost]
        public async Task<IActionResult> UpdateActivityNote(
            int bookingId,
            int bookingActivityId,
            string activityNote
        )
        {
            try
            {
                // Define the update SQL query
                string sql =
                    "UPDATE BookingActivities SET ActivityNote = @ActivityNote WHERE BookingId = @BookingId AND ActivityId = @BookingActivityId";

                // Execute the raw SQL query
                using (var connection = _context.Database.GetDbConnection())
                {
                    await connection.ExecuteAsync(
                        sql,
                        new
                        {
                            ActivityNote = activityNote,
                            BookingId = bookingId,
                            BookingActivityId = bookingActivityId
                        }
                    );

                    // Store success message in TempData
                    TempData["SuccessMessage"] = "Activity note updated successfully.";

                    // Redirect back to the previous page
                    string referer = Request.Headers["Referer"].ToString();
                    return Redirect(referer);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(
                    500,
                    $"An error occurred while updating activity note: {ex.Message}"
                );
            }
        }
    }
}
