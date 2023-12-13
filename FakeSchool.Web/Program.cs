using FakeSchool.Domain.Escola;
using FakeSchool.Domain.Usuario;
using FakeSchool.Infra.Data;
using FakeSchool.Infra.Repositorios.AlunoRepo;
using FakeSchool.Infra.Services.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Host.ConfigureAppConfiguration((hostingContext, config) =>
{
	config.AddEnvironmentVariables();
});

var dbServer = Environment.GetEnvironmentVariable("DB_SERVER");
var connectionString = $"Server={dbServer}\\SQLEXPRESS;Database=FakeSchool;Trusted_Connection=True;TrustServerCertificate=True";
builder.Services.AddDbContext<BancoContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddIdentity<Usuario, IdentityRole>().AddEntityFrameworkStores<BancoContext>().AddDefaultTokenProviders();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<UsuarioService>();
builder.Services.AddSingleton<IAlunoRepositorio, AlunoRepositorio>();

builder.Services.AddSession(o =>
{
    o.Cookie.HttpOnly = true;
    o.Cookie.IsEssential = true;
});

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

app.UseEndpoints(endpoints =>
{
	endpoints.MapControllerRoute("area", "{area:exists}/{controller=Home}/{action=Index}/{id?}");
});

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Usuario}/{action=Login}/{id?}");

app.Run();
