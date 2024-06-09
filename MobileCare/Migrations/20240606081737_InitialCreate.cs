using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MobileCare.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Activities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RatePerHour = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StreetAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Suburb = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BookingActivities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookingId = table.Column<int>(type: "int", nullable: false),
                    ActivityId = table.Column<int>(type: "int", nullable: false),
                    BookingNote = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ActivityNote = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Hours = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingActivities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    StartTime = table.Column<TimeOnly>(type: "time", nullable: false),
                    EndTime = table.Column<TimeOnly>(type: "time", nullable: false),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    ApplicationUserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationUserId = table.Column<int>(type: "int", nullable: false),
                    AddressId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_ApplicationUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "ApplicationUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_ApplicationUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "ApplicationUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_ApplicationUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "ApplicationUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationUserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_ApplicationUserRoles_ApplicationUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "ApplicationUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicationUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "RatePerHour", "Title" },
                values: new object[,]
                {
                    { 1, 450.0, "Bathroom & Bathing Assistance" },
                    { 2, 325.0, "Dressing Assistance" },
                    { 3, 350.0, "Post-Operative Care" },
                    { 4, 375.0, "Bed Bath" },
                    { 5, 400.0, "Mobility Assistance" }
                });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "City", "Country", "PostalCode", "StreetAddress", "Suburb" },
                values: new object[,]
                {
                    { 1, "Port Elizabeth", "South Africa", "6059", "25 Sayster", "Salsoneville" },
                    { 2, "Port Elizabeth", "South Africa", "6025", "53 Liesbeek", "Kabega Park" },
                    { 3, "Port Elizabeth", "South Africa", "6070", "12 Arras", "Lorraine" },
                    { 4, "Port Elizabeth", "South Africa", "6059", "15 Marock", "Sanctor" },
                    { 5, "Port Elizabeth", "South Africa", "6059", "33 Heathcote", "Aspen Heights" },
                    { 6, "Port Elizabeth", "South Africa", "6059", "12 St Benedict", "West End" },
                    { 7, "Port Elizabeth", "South Africa", "6020", "5 Crammer", "Malabar" },
                    { 8, "Port Elizabeth", "South Africa", "6025", "73 Clarence", "Westring" }
                });

            migrationBuilder.InsertData(
                table: "ApplicationUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { 1, 0, "e301eccf-a135-4607-bf9a-665578e93531", "admin@mobilecare.com", false, "Junaid Hassan", false, null, "ADMIN@MOBILECARE.COM", "ADMIN@MOBILECARE.COM", "AQAAAAIAAYagAAAAEI6EFZqX48rtbsX95OXFaW//IiD/3JFzTi1URoL2GgUaTnN2w1cH+roD+PpOScQgwA==", null, false, "0ff7c383-40f8-4ba8-b88d-8fe3991d8388", false, "admin@mobilecare.com" },
                    { 2, 0, "2974903d-7958-430c-9a9a-48f24b495a23", "tevinp@mobilecare.com", false, "Tevin Prinsloo", false, null, "TEVINP@MOBILECARE.COM", "TEVINP@MOBILECARE.COM", "AQAAAAIAAYagAAAAEBmXN2/j5yT1+XvdG7M1i5M8cD/nT5cJ1xDIZ+UW9ra/3cDh87oSq/udyNVvk/UCGQ==", null, false, "2c11c4fb-26a3-4daa-9340-9e4ff0fbe9c7", false, "tevinp@mobilecare.com" },
                    { 3, 0, "b9db920d-2783-458b-b7c3-e46bf9818bed", "shaheedt@mobilecare.com", false, "Shaheed Tobias", false, null, "SHAHEEDT@MOBILECARE.COM", "SHAHEEDT@MOBILECARE.COM", "AQAAAAIAAYagAAAAEGgtcf79ncTz0NT6EYYCdC7x1oL+jZgZOQN83dg3I97y8xQzf++nCb/LAt4v45mkrA==", null, false, "1004d689-9a05-4595-b358-1fd7441f2942", false, "shaheedt@mobilecare.com" },
                    { 4, 0, "0e6f5613-aacc-40ad-acc1-3f28c9f18809", "charlezer@gmail.com", false, "Charleze Rensburg", false, null, "CHARLEZER@GMAIL.COM", "CHARLEZER@GMAIL.COM", "AQAAAAIAAYagAAAAEHsHLcqbmztv/VpRdQRX78tQtabD7teA33KjZ635QynC9lPA/TSYRUCjp+r9nXfEVQ==", null, false, "3c06d9ce-b06f-45d3-aad2-af8a57ed4250", false, "charlezer@gmail.com" },
                    { 5, 0, "f0241bbf-d983-4ce2-89be-0fbc7a8182ca", "charlp@gmail.com", false, "Charl Peters", false, null, "CHARLP@GMAIL.COM", "CHARLP@GMAIL.COM", "AQAAAAIAAYagAAAAEEsGCnGWCfmJ1cbrfGpgegP6GfFR2i7N7X1YHBWjLgr1XvI5KvCuoHcID245RR/9iQ==", null, false, "f7516666-5b01-4d28-8b99-3c4d0d29f9bd", false, "charlp@gmail.com" },
                    { 6, 0, "023a7508-8264-45ba-83f9-f9ab19fdb00d", "sinaedl@gmail.com", false, "Sinaed Lila", false, null, "SINAEDL@GMAIL.COM", "SINAEDL@GMAIL.COM", "AQAAAAIAAYagAAAAEAX+HY1ZAw1lX0GVDk6xgwXX3LeDHF2r9mZwQhg4epHA1H6UWkUrP4vggLWMMHhTFA==", null, false, "e1a94569-ea96-4337-a620-6b408bc579cc", false, "sinaedl@gmail.com" },
                    { 7, 0, "c85a7a72-3b9c-478a-9e38-0a4b3747476b", "danep@gmail.com", false, "Dane Prinsloo", false, null, "DANEP@GMAIL.COM", "DANEP@GMAIL.COM", "AQAAAAIAAYagAAAAEM9jvi56bE4GUIYPJFH16eVUXzn184WavfGwv1c8W9gS//EYLlha44sBv6rPJ9o+RQ==", null, false, "831a28fb-b191-4efa-970c-e54572a63298", false, "danep@gmail.com" },
                    { 8, 0, "804a0459-ea19-43be-8d7d-5048f3b42ced", "demim@gmail.com", false, "Demi Miller", false, null, "DEMIM@GMAIL.COM", "DEMIM@GMAIL.COM", "AQAAAAIAAYagAAAAEBepFjjIt88Axp9JP72whAh64RviX3npoILifH3bYbQHbaJnvKybWZaI1qTafe1OeA==", null, false, "68bb3698-5fdc-4b24-9f29-c816f2acb082", false, "demim@gmail.com" },
                    { 9, 0, "b1467b43-e226-4c49-b71d-bbbe07d1e729", "tasneemd@gmail.com", false, "Tasneem Dennis", false, null, "TASNEEMD@GMAIL.COM", "TASNEEMD@GMAIL.COM", "AQAAAAIAAYagAAAAEEg/fhoaaUNP5shiGRlv12XWsxXRK+ojwXbFhQqws+ty7LuFYIFxgum9J76TaHQfyg==", null, false, "f2228bcb-851c-4f38-ac77-bd83ab2207db", false, "tasneemd@gmail.com" },
                    { 10, 0, "7ec16896-6fe1-444c-9d39-cf3a2e7bf730", "fazlodeanl@gmail.com", false, "Fazlodean Lean", false, null, "FAZLODEANL@GMAIL.COM", "FAZLODEANL@GMAIL.COM", "AQAAAAIAAYagAAAAEN6h4hsp3efCr+4ScX+bbGCgzB+fVVo8Tr5nP3NcD/dTJxXFWJ8Dq/U5Q/3e1adreg==", null, false, "dd946f83-da45-4313-a428-3e49556c2a9e", false, "fazlodeanl@gmail.com" },
                    { 11, 0, "e74d823d-f22a-4822-bb71-b51658cf3fbd", "brynthiab@gmail.com", false, "Brynthia Burgins", false, null, "BRYNTHIAB@GMAIL.COM", "BRYNTHIAB@GMAIL.COM", "AQAAAAIAAYagAAAAEAY8B+J6snpp6TdsyEU5IAX/RAZS1jAaz3YMCiAbqm2O8/MJbWmvc+I9xVU7wnQhMA==", null, false, "00ddda0c-a089-46b0-9c43-38a0bc631aaf", false, "brynthiab@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { 1, null, "Admin", "ADMIN" },
                    { 2, null, "Careworker", "CAREWORKER" },
                    { 3, null, "Patient", "PATIENT" }
                });

            migrationBuilder.InsertData(
                table: "BookingActivities",
                columns: new[] { "Id", "ActivityId", "ActivityNote", "BookingId", "BookingNote", "Hours" },
                values: new object[,]
                {
                    { 1, 1, "Patient needed slight adjustment to usual positioning of shower chair", 1, "Ensure shower chair is readily available", 1 },
                    { 2, 2, "Due to warm weather, patient was dressed in shorts and short sleeved shirt as requested", 1, "Prefer wearing comfortable clothing according to weather", 1 },
                    { 3, 3, "Aseptic cleaning and wound dressing changes were done. No abnormalities found.", 1, "I have 1 surgical wound. Wound dressing changes to be done twice daily. Had kneee replacement done.", 1 },
                    { 4, 5, null, 2, "Require assistance to and from doctor visits", 2 },
                    { 5, 2, null, 3, "Require assistance with dressing", 1 },
                    { 6, 3, null, 4, "Require post-oparative care after skin surgery", 2 },
                    { 7, 4, "Bathing of patient went well. Skin seems a bit irritated by particular brand of soap used. Patient should consider trying different soap brand.", 5, "Prefer being bathed with music in the background", 1 },
                    { 8, 5, "Accomodated patient during the visitation", 5, "Visiting my grandchildren and require assistance", 3 },
                    { 9, 3, null, 6, "Had hip surgery. Required post-operative care assistance", 2 },
                    { 10, 1, null, 7, null, 1 },
                    { 11, 2, null, 7, null, 1 },
                    { 12, 2, "Assisted patient as requested", 8, "Require dressing assistance as I can't move my body much due to injury", 1 }
                });

            migrationBuilder.InsertData(
                table: "Bookings",
                columns: new[] { "Id", "ApplicationUserId", "Date", "EndTime", "PatientId", "StartTime" },
                values: new object[,]
                {
                    { 1, 2, new DateOnly(2024, 6, 3), new TimeOnly(11, 0, 0), 1, new TimeOnly(8, 0, 0) },
                    { 2, 2, new DateOnly(2024, 6, 3), new TimeOnly(14, 0, 0), 2, new TimeOnly(12, 0, 0) },
                    { 3, 2, new DateOnly(2024, 6, 4), new TimeOnly(10, 0, 0), 3, new TimeOnly(9, 0, 0) },
                    { 4, 2, new DateOnly(2024, 6, 4), new TimeOnly(13, 0, 0), 4, new TimeOnly(11, 0, 0) },
                    { 5, 3, new DateOnly(2024, 6, 3), new TimeOnly(12, 0, 0), 5, new TimeOnly(8, 0, 0) },
                    { 6, 3, new DateOnly(2024, 6, 3), new TimeOnly(15, 0, 0), 6, new TimeOnly(13, 0, 0) },
                    { 7, 3, new DateOnly(2024, 6, 4), new TimeOnly(14, 0, 0), 7, new TimeOnly(12, 0, 0) },
                    { 8, 3, new DateOnly(2024, 6, 4), new TimeOnly(16, 0, 0), 8, new TimeOnly(15, 0, 0) }
                });

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "Id", "AddressId", "ApplicationUserId" },
                values: new object[,]
                {
                    { 1, 1, 4 },
                    { 2, 2, 5 },
                    { 3, 3, 6 },
                    { 4, 4, 7 },
                    { 5, 5, 8 },
                    { 6, 6, 9 },
                    { 7, 7, 10 },
                    { 8, 8, 11 }
                });

            migrationBuilder.InsertData(
                table: "ApplicationUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 2, 3 },
                    { 3, 4 },
                    { 3, 5 },
                    { 3, 6 },
                    { 3, 7 },
                    { 3, 8 },
                    { 3, 9 },
                    { 3, 10 },
                    { 3, 11 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUserRoles_RoleId",
                table: "ApplicationUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "ApplicationUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "ApplicationUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Activities");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "ApplicationRoles");

            migrationBuilder.DropTable(
                name: "ApplicationUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "BookingActivities");

            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "ApplicationUsers");
        }
    }
}
