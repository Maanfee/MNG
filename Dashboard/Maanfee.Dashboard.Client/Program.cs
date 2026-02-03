using Maanfee.Dashboard;
using Maanfee.Dashboard.Views.Core;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using System.Globalization;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddMaanfeeDashboardServiceManager();

//await builder.Build().RunAsync();

var host = builder.Build();

var Config = host.Services.GetRequiredService<LocalConfigurationService>();
await Config.InitConfigurationAsync(LanguageService.SupportedCountry.US);
await InitCultureAsync(builder.Services);

await host.RunAsync();

async Task InitCultureAsync(IServiceCollection Services)
{
    Services.AddLocalization(options =>
    {
        options.ResourcesPath = "Resources";
    });

    var Culture = new CultureInfo(SharedLayoutSettings.CultureCode);

    CultureInfo.DefaultThreadCurrentCulture = Culture;
    CultureInfo.DefaultThreadCurrentUICulture = Culture;
    CultureInfo.CurrentCulture = Culture;
    CultureInfo.CurrentUICulture = Culture;
}
