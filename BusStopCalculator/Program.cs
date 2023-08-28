using BusStopCalculator;

var builder = WebApplication.CreateBuilder(args);

builder.Services.RegisterDependencies();
builder.Services.AddControllersWithViews();
builder.Services.AddMvc();

var app = builder.Build();

app.UseRouting();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();