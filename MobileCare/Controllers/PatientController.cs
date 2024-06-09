using System.Security.Claims;
using Dapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MobileCare.Data;
using MobileCare.Models.ViewModels;

namespace MobileCare.Controllers
{
    [Authorize(Roles = "Patient")]
    public class PatientController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PatientController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> IndexAsync(int id)
        {
            /*Validate that the patient's ID matches the ID provided in the URL parameters by comparing
             the patient's ID extracted from the authentication claims with the ID provided in the URL parameters
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
    ApplicationUsers.Id AS ApplicationUserId,
ApplicationUsers.FullName AS PatientFullName,
    Patients.Id AS PatientId,
    BookingActivities.BookingId,
    Bookings.Date,
    BookingActivities.ActivityId,
	BookingActivities.ActivityNote AS ActivityReport,
	Activities.Id,
	Activities.Title
FROM BookingActivities
INNER JOIN Bookings ON BookingActivities.BookingId = Bookings.Id
INNER JOIN Patients ON Bookings.PatientId = Patients.Id
INNER JOIN ApplicationUsers ON Patients.ApplicationUserId = ApplicationUsers.Id
INNER JOIN Activities ON BookingActivities.ActivityId = Activities.Id
WHERE BookingActivities.BookingId IN (
    SELECT Bookings.Id
    FROM Bookings
    INNER JOIN Patients ON Bookings.PatientId = Patients.Id
    INNER JOIN ApplicationUsers ON ApplicationUsers.Id = Patients.ApplicationUserId
    WHERE Patients.ApplicationUserId = @id
)

";

            // Execute the query and project the result into the DTO
            using (var connection = _context.Database.GetDbConnection())
            {
                var activityReports = await connection.QueryAsync<PatientActivityReportViewModel>(
                    sql,
                    new { id }
                );

                return View(activityReports);
            }
        }
    }
}
