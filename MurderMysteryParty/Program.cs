using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MurderMysteryParty.Services;
using MurderMysteryParty.Components;
using System.Net.Http;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");

// register app services
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddSingleton<CharacterService>();
builder.Services.AddSingleton<GameSessionService>();

await builder.Build().RunAsync();
