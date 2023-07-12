using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using restaurant.Services;
using restaurant.Data;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
.AddCookie(options =>{
    options.LoginPath = "/Autentificacion/IniciarSesion";
    options.LogoutPath = "/Home/Index.cshtml";
    options.AccessDeniedPath = "/Autentificacion/IniciarSesion";
    options.AccessDeniedPath = "/Home/Index";
    options.ClaimsIssuer = "http://schemas.microsoft.com/ws/2008/06/identity/claims/role";
    options.ExpireTimeSpan = TimeSpan.FromHours(2);
});

builder.Services.Configure<IdentityOptions>(options =>
{
    options.ClaimsIdentity.RoleClaimType = ClaimTypes.Role;
});

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("PostgreSQLConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
//builder.Services.AddScoped<IUsuarioService,UsuarioServiceImplement>();
builder.Services.AddScoped<UsuarioServiceImplement>();
builder.Services.AddScoped<PersonaServiceImplement>();
builder.Services.AddScoped<ProductoServiceImplement>();
builder.Services.AddScoped<CategoriaServiceImplement>();

/*
builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();

*/


builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
