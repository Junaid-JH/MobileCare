using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MobileCare.Data;
using MobileCare.Models;

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.UseEnvironment(
    Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"
);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Read the connection string from environment variable
var connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING");

// Check if the connection string is retrieved correctly
if (string.IsNullOrEmpty(connectionString))
{
    throw new InvalidOperationException(
        "The connection string is missing or empty. Check your environment variables."
    );
}

// Configure DbContext with the connection string
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString)
);

//InvoiceService
builder.Services.AddHttpClient<InvoiceService>();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString)
);
builder
    .Services.AddIdentity<ApplicationUser, IdentityRole<int>>(options =>
    {
        // Configure identity options
        options.User.RequireUniqueEmail = true;
        // Other identity options if needed
    })
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
