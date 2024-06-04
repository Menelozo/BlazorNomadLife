using NomadLife.Shared.Interfaces;
using NomadLife.Web;
using NomadLife.Web.Components;
using NomadLife.Web.Data;
using NomadLife.Web.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContextFactory<HotelContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("NomadLife");
    options.UseSqlServer(connectionString);
});

// Add services to the container.
builder.Services.AddRazorComponents();


builder.Services.AddTransient<IHotelService, HotelService>()
    .AddSingleton<ICommonService, CommonService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
  .AddAdditionalAssemblies(typeof(NomadLife.Shared.Components.Pages.Hotel).Assembly);

app.MapHotelEndpoints();

app.Run();
