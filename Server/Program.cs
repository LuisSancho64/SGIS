using Microsoft.EntityFrameworkCore;
using Application.Interfaces;

using Infrastructure.Context;
using SMI.Server.Services;
using Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

// Conexión a base de datos
builder.Services.AddDbContext<SmiDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// MVC y Razor Pages
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

//registro
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IPersonaService, PersonaService>();




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
