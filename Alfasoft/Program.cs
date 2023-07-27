using Alfasoft;
using Alfasoft.Services.CustomerService;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

var serverVersion = new MySqlServerVersion(new Version(8, 0, 26));

var connectionString = builder.Configuration.GetConnectionString("MariaDB");

builder.Services.AddDbContext<ApplicationDbContext>(options =>

    options.UseMySql(connectionString, serverVersion)

);

builder.Services.AddScoped<ICustomerService, CustomerService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
