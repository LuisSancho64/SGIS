using System.Net.Http;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Blazored.LocalStorage;
using SMI.Client;


var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");

// Blazored LocalStorage (puedes mantenerlo si usas para algo más)
builder.Services.AddBlazoredLocalStorage();

// HttpClient simple sin headers extra
builder.Services.AddScoped(sp =>
    new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });


//Servicios
builder.Services.AddScoped<PersonaServiceClient>();

await builder.Build().RunAsync();
