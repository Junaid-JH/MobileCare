using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MobileCare.Models;

namespace MobileCare.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, IdentityRole<int>, int>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        // Other DbSet properties and configuration if any
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<ActivityOption> Activities { get; set; }
        public DbSet<BookingActivity> BookingActivities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); // Let IdentityDbContext handle its configurations

            // Customize the ASP.NET Identity model and override the defaults
            // For example, you can rename the ASP.NET Identity table names
            modelBuilder.Entity<ApplicationUser>(entity =>
            {
                entity.ToTable(name: "ApplicationUsers");
            });

            // Similarly, you can rename other Identity tables like AspNetRoles, AspNetUserRoles, etc.
            modelBuilder.Entity<IdentityRole>(entity =>
            {
                entity.ToTable(name: "ApplicationRoles");
            });
            modelBuilder.Entity<IdentityUserRole<int>>(entity =>
            {
                entity.ToTable(name: "ApplicationUserRoles");
            });
            // Add similar configurations for other Identity tables if needed




            var hasher = new PasswordHasher<ApplicationUser>();

            // Seed initial data with actual instances of ApplicationUser
            var users = new List<ApplicationUser>
            {
                new ApplicationUser
                {
                    Id = 1,
                    FullName = "Junaid Hassan",
                    Email = "admin@mobilecare.com",
                    NormalizedEmail = "ADMIN@MOBILECARE.COM",
                    UserName = "admin@mobilecare.com",
                    NormalizedUserName = "ADMIN@MOBILECARE.COM",
                    SecurityStamp = Guid.NewGuid().ToString()
                },
                new ApplicationUser
                {
                    Id = 2,
                    FullName = "Tevin Prinsloo",
                    Email = "tevinp@mobilecare.com",
                    NormalizedEmail = "TEVINP@MOBILECARE.COM",
                    UserName = "tevinp@mobilecare.com",
                    NormalizedUserName = "TEVINP@MOBILECARE.COM",
                    SecurityStamp = Guid.NewGuid().ToString()
                },
                new ApplicationUser
                {
                    Id = 3,
                    FullName = "Shaheed Tobias",
                    Email = "shaheedt@mobilecare.com",
                    NormalizedEmail = "SHAHEEDT@MOBILECARE.COM",
                    UserName = "shaheedt@mobilecare.com",
                    NormalizedUserName = "SHAHEEDT@MOBILECARE.COM",
                    SecurityStamp = Guid.NewGuid().ToString()
                },
                new ApplicationUser
                {
                    Id = 4,
                    FullName = "Charleze Rensburg",
                    Email = "charlezer@gmail.com",
                    NormalizedEmail = "CHARLEZER@GMAIL.COM",
                    UserName = "charlezer@gmail.com",
                    NormalizedUserName = "CHARLEZER@GMAIL.COM",
                    SecurityStamp = Guid.NewGuid().ToString()
                },
                new ApplicationUser
                {
                    Id = 5,
                    FullName = "Charl Peters",
                    Email = "charlp@gmail.com",
                    NormalizedEmail = "CHARLP@GMAIL.COM",
                    UserName = "charlp@gmail.com",
                    NormalizedUserName = "CHARLP@GMAIL.COM",
                    SecurityStamp = Guid.NewGuid().ToString()
                },
                new ApplicationUser
                {
                    Id = 6,
                    FullName = "Sinaed Lila",
                    Email = "sinaedl@gmail.com",
                    NormalizedEmail = "SINAEDL@GMAIL.COM",
                    UserName = "sinaedl@gmail.com",
                    NormalizedUserName = "SINAEDL@GMAIL.COM",
                    SecurityStamp = Guid.NewGuid().ToString()
                },
                new ApplicationUser
                {
                    Id = 7,
                    FullName = "Dane Prinsloo",
                    Email = "danep@gmail.com",
                    NormalizedEmail = "DANEP@GMAIL.COM",
                    UserName = "danep@gmail.com",
                    NormalizedUserName = "DANEP@GMAIL.COM",
                    SecurityStamp = Guid.NewGuid().ToString()
                },
                new ApplicationUser
                {
                    Id = 8,
                    FullName = "Demi Miller",
                    Email = "demim@gmail.com",
                    NormalizedEmail = "DEMIM@GMAIL.COM",
                    UserName = "demim@gmail.com",
                    NormalizedUserName = "DEMIM@GMAIL.COM",
                    SecurityStamp = Guid.NewGuid().ToString()
                },
                new ApplicationUser
                {
                    Id = 9,
                    FullName = "Tasneem Dennis",
                    Email = "tasneemd@gmail.com",
                    NormalizedEmail = "TASNEEMD@GMAIL.COM",
                    UserName = "tasneemd@gmail.com",
                    NormalizedUserName = "TASNEEMD@GMAIL.COM",
                    SecurityStamp = Guid.NewGuid().ToString()
                },
                new ApplicationUser
                {
                    Id = 10,
                    FullName = "Fazlodean Lean",
                    Email = "fazlodeanl@gmail.com",
                    NormalizedEmail = "FAZLODEANL@GMAIL.COM",
                    UserName = "fazlodeanl@gmail.com",
                    NormalizedUserName = "FAZLODEANL@GMAIL.COM",
                    SecurityStamp = Guid.NewGuid().ToString()
                },
                new ApplicationUser
                {
                    Id = 11,
                    FullName = "Brynthia Burgins",
                    Email = "brynthiab@gmail.com",
                    NormalizedEmail = "BRYNTHIAB@GMAIL.COM",
                    UserName = "brynthiab@gmail.com",
                    NormalizedUserName = "BRYNTHIAB@GMAIL.COM",
                    SecurityStamp = Guid.NewGuid().ToString()
                }
            };

            foreach (var user in users)
            {
                user.PasswordHash = hasher.HashPassword(user, "Password123");
            }

            modelBuilder.Entity<ApplicationUser>().HasData(users);

            modelBuilder
                .Entity<IdentityRole<int>>()
                .HasData(
                    new IdentityRole<int>
                    {
                        Id = 1,
                        Name = "Admin",
                        NormalizedName = "ADMIN"
                    },
                    new IdentityRole<int>
                    {
                        Id = 2,
                        Name = "Careworker",
                        NormalizedName = "CAREWORKER"
                    },
                    new IdentityRole<int>
                    {
                        Id = 3,
                        Name = "Patient",
                        NormalizedName = "PATIENT"
                    }
                );

            modelBuilder
                .Entity<IdentityUserRole<int>>()
                .HasData(
                    new IdentityUserRole<int> { UserId = 1, RoleId = 1 }, // Assigning role "Admin" to user with Id 1
                    // Assign more roles to users as needed
                    new IdentityUserRole<int> { UserId = 2, RoleId = 2 },
                    new IdentityUserRole<int> { UserId = 3, RoleId = 2 },
                    new IdentityUserRole<int> { UserId = 4, RoleId = 3 },
                    new IdentityUserRole<int> { UserId = 5, RoleId = 3 },
                    new IdentityUserRole<int> { UserId = 6, RoleId = 3 },
                    new IdentityUserRole<int> { UserId = 7, RoleId = 3 },
                    new IdentityUserRole<int> { UserId = 8, RoleId = 3 },
                    new IdentityUserRole<int> { UserId = 9, RoleId = 3 },
                    new IdentityUserRole<int> { UserId = 10, RoleId = 3 },
                    new IdentityUserRole<int> { UserId = 11, RoleId = 3 }
                );

            modelBuilder
                .Entity<Address>()
                .HasData(
                    new Address
                    {
                        Id = 1,
                        StreetAddress = "25 Sayster",
                        Suburb = "Salsoneville",
                        City = "Port Elizabeth",
                        PostalCode = "6059",
                        Country = "South Africa"
                    },
                    new Address
                    {
                        Id = 2,
                        StreetAddress = "53 Liesbeek",
                        Suburb = "Kabega Park",
                        City = "Port Elizabeth",
                        PostalCode = "6025",
                        Country = "South Africa"
                    },
                    new Address
                    {
                        Id = 3,
                        StreetAddress = "12 Arras",
                        Suburb = "Lorraine",
                        City = "Port Elizabeth",
                        PostalCode = "6070",
                        Country = "South Africa"
                    },
                    new Address
                    {
                        Id = 4,
                        StreetAddress = "15 Marock",
                        Suburb = "Sanctor",
                        City = "Port Elizabeth",
                        PostalCode = "6059",
                        Country = "South Africa"
                    },
                    new Address
                    {
                        Id = 5,
                        StreetAddress = "33 Heathcote",
                        Suburb = "Aspen Heights",
                        City = "Port Elizabeth",
                        PostalCode = "6059",
                        Country = "South Africa"
                    },
                    new Address
                    {
                        Id = 6,
                        StreetAddress = "12 St Benedict",
                        Suburb = "West End",
                        City = "Port Elizabeth",
                        PostalCode = "6059",
                        Country = "South Africa"
                    },
                    new Address
                    {
                        Id = 7,
                        StreetAddress = "5 Crammer",
                        Suburb = "Malabar",
                        City = "Port Elizabeth",
                        PostalCode = "6020",
                        Country = "South Africa"
                    },
                    new Address
                    {
                        Id = 8,
                        StreetAddress = "73 Clarence",
                        Suburb = "Westring",
                        City = "Port Elizabeth",
                        PostalCode = "6025",
                        Country = "South Africa"
                    }
                );

            modelBuilder
                .Entity<Patient>()
                .HasData(
                    new Patient
                    {
                        Id = 1,
                        ApplicationUserId = 4,
                        AddressId = 1
                    },
                    new Patient
                    {
                        Id = 2,
                        ApplicationUserId = 5,
                        AddressId = 2
                    },
                    new Patient
                    {
                        Id = 3,
                        ApplicationUserId = 6,
                        AddressId = 3
                    },
                    new Patient
                    {
                        Id = 4,
                        ApplicationUserId = 7,
                        AddressId = 4
                    },
                    new Patient
                    {
                        Id = 5,
                        ApplicationUserId = 8,
                        AddressId = 5
                    },
                    new Patient
                    {
                        Id = 6,
                        ApplicationUserId = 9,
                        AddressId = 6
                    },
                    new Patient
                    {
                        Id = 7,
                        ApplicationUserId = 10,
                        AddressId = 7
                    },
                    new Patient
                    {
                        Id = 8,
                        ApplicationUserId = 11,
                        AddressId = 8
                    }
                );
            modelBuilder
                .Entity<Booking>()
                .HasData(
                    new Booking
                    {
                        Id = 1,
                        Date = new DateOnly(2024, 06, 03),
                        StartTime = new TimeOnly(08, 00),
                        EndTime = new TimeOnly(11, 00),
                        PatientId = 1,
                        ApplicationUserId = 2,
                    },
                    new Booking
                    {
                        Id = 2,
                        Date = new DateOnly(2024, 06, 03),
                        StartTime = new TimeOnly(12, 00),
                        EndTime = new TimeOnly(14, 00),
                        PatientId = 2,
                        ApplicationUserId = 2,
                    },
                    new Booking
                    {
                        Id = 3,
                        Date = new DateOnly(2024, 06, 04),
                        StartTime = new TimeOnly(09, 00),
                        EndTime = new TimeOnly(10, 00),
                        PatientId = 3,
                        ApplicationUserId = 2,
                    },
                    new Booking
                    {
                        Id = 4,
                        Date = new DateOnly(2024, 06, 04),
                        StartTime = new TimeOnly(11, 00),
                        EndTime = new TimeOnly(13, 00),
                        PatientId = 4,
                        ApplicationUserId = 2,
                    },
                    new Booking
                    {
                        Id = 5,
                        Date = new DateOnly(2024, 06, 03),
                        StartTime = new TimeOnly(08, 00),
                        EndTime = new TimeOnly(12, 00),
                        PatientId = 5,
                        ApplicationUserId = 3,
                    },
                    new Booking
                    {
                        Id = 6,
                        Date = new DateOnly(2024, 06, 03),
                        StartTime = new TimeOnly(13, 00),
                        EndTime = new TimeOnly(15, 00),
                        PatientId = 6,
                        ApplicationUserId = 3,
                    },
                    new Booking
                    {
                        Id = 7,
                        Date = new DateOnly(2024, 06, 04),
                        StartTime = new TimeOnly(12, 00),
                        EndTime = new TimeOnly(14, 00),
                        PatientId = 7,
                        ApplicationUserId = 3,
                    },
                    new Booking
                    {
                        Id = 8,
                        Date = new DateOnly(2024, 06, 04),
                        StartTime = new TimeOnly(15, 00),
                        EndTime = new TimeOnly(16, 00),
                        PatientId = 8,
                        ApplicationUserId = 3,
                    },
                    new Booking
                    {
                        Id = 9,
                        Date = new DateOnly(2024, 06, 05),
                        StartTime = new TimeOnly(08, 00),
                        EndTime = new TimeOnly(09, 00),
                        PatientId = 1,
                        ApplicationUserId = 2,
                    },
                    new Booking
                    {
                        Id = 10,
                        Date = new DateOnly(2024, 06, 05),
                        StartTime = new TimeOnly(09, 00),
                        EndTime = new TimeOnly(10, 00),
                        PatientId = 5,
                        ApplicationUserId = 3,
                    }
                );

            modelBuilder
                .Entity<ActivityOption>()
                .HasData(
                    new ActivityOption
                    {
                        Id = 1,
                        Title = "Bathroom & Bathing Assistance",
                        RatePerHour = 450
                    },
                    new ActivityOption
                    {
                        Id = 2,
                        Title = "Dressing Assistance",
                        RatePerHour = 325
                    },
                    new ActivityOption
                    {
                        Id = 3,
                        Title = "Post-Operative Care",
                        RatePerHour = 350
                    },
                    new ActivityOption
                    {
                        Id = 4,
                        Title = "Bed Bath",
                        RatePerHour = 375
                    },
                    new ActivityOption
                    {
                        Id = 5,
                        Title = "Mobility Assistance",
                        RatePerHour = 400
                    }
                );

            modelBuilder
                .Entity<BookingActivity>()
                .HasData(
                    new BookingActivity
                    {
                        Id = 1,
                        BookingId = 1,
                        ActivityId = 1,
                        BookingNote = "Ensure shower chair is readily available",
                        ActivityNote =
                            "Patient needed slight adjustment to usual positioning of shower chair",
                        Hours = 1
                    },
                    new BookingActivity
                    {
                        Id = 2,
                        BookingId = 1,
                        ActivityId = 2,
                        BookingNote = "Prefer wearing comfortable clothing according to weather",
                        ActivityNote =
                            "Due to warm weather, patient was dressed in shorts and short sleeved shirt as requested",
                        Hours = 1
                    },
                    new BookingActivity
                    {
                        Id = 3,
                        BookingId = 1,
                        ActivityId = 3,
                        BookingNote =
                            "I have 1 surgical wound. Wound dressing changes to be done twice daily. Had kneee replacement done.",
                        ActivityNote =
                            "Aseptic cleaning and wound dressing changes were done. No abnormalities found.",
                        Hours = 1
                    },
                    new BookingActivity
                    {
                        Id = 4,
                        BookingId = 2,
                        ActivityId = 5,
                        BookingNote = "Require assistance to and from doctor visits",
                        Hours = 2
                    },
                    new BookingActivity
                    {
                        Id = 5,
                        BookingId = 3,
                        ActivityId = 2,
                        BookingNote = "Require assistance with dressing",
                        Hours = 1
                    },
                    new BookingActivity
                    {
                        Id = 6,
                        BookingId = 4,
                        ActivityId = 3,
                        BookingNote = "Require post-oparative care after skin surgery",
                        Hours = 2
                    },
                    new BookingActivity
                    {
                        Id = 7,
                        BookingId = 5,
                        ActivityId = 4,
                        BookingNote = "Prefer being bathed with music in the background",
                        ActivityNote =
                            "Bathing of patient went well. Skin seems a bit irritated by particular brand of soap used. Patient should consider trying different soap brand.",
                        Hours = 1
                    },
                    new BookingActivity
                    {
                        Id = 8,
                        BookingId = 5,
                        ActivityId = 5,
                        BookingNote = "Visiting my grandchildren and require assistance",
                        ActivityNote = "Accomodated patient during the visitation",
                        Hours = 3
                    },
                    new BookingActivity
                    {
                        Id = 9,
                        BookingId = 6,
                        ActivityId = 3,
                        BookingNote = "Had hip surgery. Required post-operative care assistance",
                        Hours = 2
                    },
                    new BookingActivity
                    {
                        Id = 10,
                        BookingId = 7,
                        ActivityId = 1,
                        Hours = 1
                    },
                    new BookingActivity
                    {
                        Id = 11,
                        BookingId = 7,
                        ActivityId = 2,
                        Hours = 1
                    },
                    new BookingActivity
                    {
                        Id = 12,
                        BookingId = 8,
                        ActivityId = 2,
                        BookingNote =
                            "Require dressing assistance as I can't move my body much due to injury",
                        ActivityNote = "Assisted patient as requested",
                        Hours = 1
                    },
                    new BookingActivity
                    {
                        Id = 13,
                        BookingId = 9,
                        ActivityId = 1,
                        Hours = 1
                    },
                    new BookingActivity
                    {
                        Id = 14,
                        BookingId = 10,
                        ActivityId = 3,
                        Hours = 1
                    }
                );
        }
    }
}
