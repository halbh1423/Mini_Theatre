using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.EntityFrameworkCore;
using Mini_Theatre.Data;
using Mini_Theatre.Interfaces;
using Mini_Theatre.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Get connection strings
var connectionString = builder.Configuration.GetConnectionString("PCToanConnection") ?? throw new InvalidOperationException("Connection string DbContext not found.");
//var connectionString = builder.Configuration.GetConnectionString("ToanConnection") ?? throw new InvalidOperationException("Connection string DbContext not found.");
//var connectionString = builder.Configuration.GetConnectionString("HaConnection") ?? throw new InvalidOperationException("Connection string DbContext not found.");

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    //options.UseSqlite(connectionString);
    options.UseSqlServer(connectionString);
});

// Add DI
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IRoleRepository, RoleRepository>();
builder.Services.AddScoped<IMovieRepository, MovieRepository>();
builder.Services.AddScoped<IScheduleRepository, ScheduleRepository>();

builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
})
.AddCookie(cookieOptions =>
{
    cookieOptions.LoginPath = "/Authentication/Login";
    cookieOptions.LogoutPath = "/Authentication/Logout";
    cookieOptions.AccessDeniedPath = "/Authentication/AccessDenied";
})
.AddGoogle(googleOptions =>
{
    var googleConfig = builder.Configuration.GetSection("Authentication:Google");
    googleOptions.ClientId = googleConfig["ClientId"] ?? "";
    googleOptions.ClientSecret = googleConfig["ClientSecret"] ?? "";
    googleOptions.SaveTokens = true;
});

builder.Services.AddRazorPages();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseStatusCodePagesWithReExecute("/404");

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();