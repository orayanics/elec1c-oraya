using Microsoft.EntityFrameworkCore;
using OrayaAct.Database;
using OrayaAct.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// builder.Services.AddSingleton<IPopulateDataService, PopulateDataService>();

// Add DbContext for DB
// Uses DefaultConnection variable string in appsettings.json
builder.Services.AddDbContext<OrayaDbContext>(options => options.UseSqlServer
    (builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

var context = app.Services.CreateScope().ServiceProvider.GetRequiredService<OrayaDbContext>();
context.Database.EnsureCreated();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
