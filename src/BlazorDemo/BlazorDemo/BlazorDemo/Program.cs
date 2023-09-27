using BlazorDemo.Components;
using BlazorDemo.Services;
using Microsoft.AspNetCore.Mvc;
using MudBlazor.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddServerComponents()
    .AddWebAssemblyComponents();

builder.Services.AddMudServices();

builder.Services.AddTransient<DashboardService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
}

app.UseStaticFiles();

app.MapRazorComponents<App>()
    .AddServerRenderMode()
    .AddWebAssemblyRenderMode();

app.MapGet("/api/dashboard/points", ([FromServices] DashboardService DashboardService) =>  DashboardService.GetPoints());
app.MapGet("/api/dashboard/cumulative", ([FromServices] DashboardService DashboardService) => DashboardService.GetCumulative());

app.Run();
