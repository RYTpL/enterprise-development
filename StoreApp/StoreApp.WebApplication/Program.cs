using MudBlazor;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using StoreApp.WebApplication;
using System.Net.Http;
using Microsoft.AspNetCore.Components.Web;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// Регистрируем HttpClient
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

// Регистрируем MudBlazor
builder.Services.AddMudServices();

await builder.Build().RunAsync();
