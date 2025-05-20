using Microsoft.EntityFrameworkCore;
using SMI.Server.Services;
using Infrastructure.Context;

var builder = WebApplication.CreateBuilder(args);

// Conexión a base de datos
builder.Services.AddDbContext<SmiDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// MVC y Razor Pages
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

// Registro del servicio de autenticación simple
builder.Services.AddScoped<IAuthService, AuthService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();

app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
