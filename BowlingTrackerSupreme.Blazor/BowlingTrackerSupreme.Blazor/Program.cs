using BowlingTrackerSupreme.Blazor.Client.Pages;
using BowlingTrackerSupreme.Blazor.Components;
using BowlingTrackerSupreme.Infrastructure;
using BowlingTrackerSupreme.Infrastructure.Database;
using BowlingTrackerSupreme.Migrations;
using Microsoft.IdentityModel.Protocols.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

var connectionString = builder.Configuration.GetConnectionString("BowlingTrackerSupremeDb");

if (connectionString == null)
{
    throw new InvalidConfigurationException("Missing connection string in configuration.");
}

builder.Services.AddDbContext<BowlingTrackerSupremeDbContext>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(BowlingTrackerSupreme.Blazor.Client._Imports).Assembly);

app.Run();