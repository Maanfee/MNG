using Maanfee.Dashboard;
using Maanfee.Dashboard.Components;
using Maanfee.Dashboard.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

builder.Services.AddMaanfeeDashboardServiceManager();
builder.Services.AddDashboardCompression();
builder.Services.AddDashboardAuthorization();
builder.Services.AddDashboardDatabaseConfigurations(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
}
app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseAntiforgery();

app.UseDashboardCompression();
app.UseDashboardAuthorization();
app.UseDashboardDatabaseConfigurations();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(Maanfee.Dashboard.Client._Imports).Assembly);

app.Run();
