using Data;
using Data.Interfaces;
using Data.Services;
using Laboratorium_ASPNET.Interfaces;
using Laboratorium_ASPNET.Services;
using Laboratorium_ASPNET.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Register DbContext for Data layer
builder.Services.AddDbContext<AppDbContext>();

// Register Data layer services
builder.Services.AddTransient<Data.Interfaces.IContactService, EFContactService>();

// Register Application layer services
builder.Services.AddScoped<Laboratorium_ASPNET.Interfaces.IContactService, ContactService>();

// Register Memory-based services for computers
builder.Services.AddScoped<IComputerService, MemoryComputerService>();

// Add controllers with views
builder.Services.AddControllersWithViews();

// Add authorization middleware
builder.Services.AddAuthorization();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Define default route mapping
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();