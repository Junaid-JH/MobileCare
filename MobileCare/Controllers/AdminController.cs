using Dapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MobileCare.Data;
using MobileCare.Models.ViewModels;
using MobileCare.Models.ViewModels.Invoice;

namespace MobileCare.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly InvoiceService _invoiceService;

        public AdminController(InvoiceService invoiceService, ApplicationDbContext context)
        {
            _context = context;
            _invoiceService = invoiceService;
        }

        public async Task<IActionResult> IndexAsync()
        {
            // Define the SQL query with INNER JOIN
            string sql =
                @"SELECT Bookings.*,
AU1.FullName AS PatientFullName,
AU2.FullName AS CareworkerFullName,
Addresses.*
FROM Bookings
INNER JOIN Patients ON Patients.Id = Bookings.PatientId
INNER JOIN ApplicationUsers AU1 ON AU1.Id = Patients.ApplicationUserId
INNER JOIN ApplicationUsers AU2 ON AU2.Id = Bookings.ApplicationUserId
INNER JOIN Addresses ON Addresses.Id = Patients.AddressId";

            // Execute the query and project the result into the DTO
            using (var connection = _context.Database.GetDbConnection())
            {
                var allBookings = await connection.QueryAsync<AdminViewModel>(sql);

                return View(allBookings);
            }
        }

        public async Task<IActionResult> GenerateInvoice(
            int id,
            string patientName,
            string streetAddress,
            string suburb,
            string city,
            string postalCode,
            string country,
            string bookingId,
            string careworkerName
        )
        {
            // Fetch invoice data from your database based on the bookingId
            var invoice = GetInvoiceFromDatabase(
                //id,
                patientName,
                streetAddress,
                suburb,
                city,
                postalCode,
                country,
                bookingId,
                careworkerName
            );

            var pdfBytes = await _invoiceService.GenerateInvoiceAsync(invoice);

            return File(pdfBytes, "application/pdf", "invoice.pdf");
        }

        private async Task<InvoiceViewModel> GetInvoiceFromDatabase(
            //int id,
            string patientName,
            string streetAddress,
            string suburb,
            string city,
            string postalCode,
            string country,
            string bookingId,
            string careworkerName
        )
        {
            var bookingIdInt = int.Parse(bookingId);

            // Define the SQL query with INNER JOIN
            string sql =
                @"           
            SELECT BookingActivities.BookingId,
		            Activities.Title,
		            BookingActivities.Hours,
		            Activities.RatePerHour,
		            BookingActivities.ActivityNote
            FROM    BookingActivities
            INNER JOIN Activities ON BookingActivities.ActivityId = Activities.Id
            WHERE   BookingActivities.BookingId = @BookingIdInt";

            // Execute the query and project the result into the DTO
            using (var connection = _context.Database.GetDbConnection())
            {
                var invoiceActivities = await connection.QueryAsync<InvoiceActivity>(
                    sql,
                    new { bookingIdInt }
                );

                return new InvoiceViewModel
                {
                    From = "MobileCare\nPort Elizabeth, ZA\n info@mobilecare.com\n 041 481 0617",
                    To =
                        $"{patientName}\n{streetAddress}\n{suburb}\n{city}\n{postalCode}\n{country}",
                    Logo = "https://i.imgur.com/saCRrLd.png",
                    Number = $"INV-{bookingId}",
                    Currency = "ZAR",
                    DueDate = DateTime.Now.AddDays(7).ToString("MMMM d, yyyy"),
                    Fields = new InvoiceField { Tax = "%" },
                    InvoiceCustomFields = new List<InvoiceCustomField>
                    {
                        new InvoiceCustomField
                        {
                            Name = "Assigned Careworker",
                            Value = careworkerName
                        }
                    },
                    ItemHeader = "Activity",
                    QuantityHeader = "Hours",
                    Tax = 15,
                    Notes = "Thank you for your business",
                    Terms = "Activities are priced on a per hourly basis",

                    InvoiceActivities = invoiceActivities.ToList()
                };
            }
            ;
        }
    }
}
