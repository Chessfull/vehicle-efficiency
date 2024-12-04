using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;
using VehicleEfficiencyAcd.Business.DataProtection;
using VehicleEfficiencyAcd.Business.Operations.User;
using VehicleEfficiencyAcd.Business.Operations.Vehicle;
using VehicleEfficiencyAcd.Business.Operations.VehicleUsage;
using VehicleEfficiencyAcd.Data.Context;
using VehicleEfficiencyAcd.Data.Repositories;
using VehicleEfficiencyAcd.Data.UnitOfWork;
using VehicleEfficiencyAcd.Presentation.SignalR;

var builder = WebApplication.CreateBuilder(args);

// Add mvc
builder.Services.AddControllersWithViews();

builder.Services.AddSignalR();

// Getting connection string from appsettings and add dbcontext service
var connectionString = builder.Configuration.GetConnectionString("VehicleEfficiencyAcd");
builder.Services.AddDbContext<VehicleEfficiencyAcdDbContext>(options => options.UseSqlServer(connectionString));

// Adding services, dependency injection 
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>)); // -> We use type of cause of generic type
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>(); // -> UnitOfWork injection service
builder.Services.AddScoped<IUserService, UserManager>(); // -> User operation injection service
builder.Services.AddScoped<IVehicleService, VehicleManager>(); // -> Vehicle operation injection service
builder.Services.AddScoped<IVehicleUsageService, VehicleUsageManager>(); // -> VehicleUsage operation injection service
builder.Services.AddScoped<IDataProtection, DataProtection>(); // -> Data protection injection service

// I used this auth schema on my projcet but defined jwt schema below as well for possible next approaches 
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
{
    options.LoginPath = "/Auth/Login"; 
    options.LogoutPath = "/Auth/Logout"; 
    options.AccessDeniedPath = "/Home/AccessDenied";

});

//// For JWT Authentication Schema for possible next
//builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
//    .AddJwtBearer(options =>
//    {
//        options.TokenValidationParameters = new TokenValidationParameters
//        {
//            ValidateIssuer = true,
//            ValidIssuer = builder.Configuration["Jwt:Issuer"],

//            ValidateAudience = true,
//            ValidAudience = builder.Configuration["Jwt:Audience"],

//            ValidateLifetime = true, // Token expire check

//            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:SecretKey"]!)),
//            ValidateIssuerSigningKey = true
//        };

//    });

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

app.UseAuthentication();

app.UseAuthorization();

app.MapHub<VehiclePerformanceHub>("/vehiclePerformanceHub"); // -> Adding hup service I defined for adding any possibe real time updates

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
