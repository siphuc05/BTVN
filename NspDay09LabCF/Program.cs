using Microsoft.EntityFrameworkCore;
using NspDay09LabCF.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
var nspConnectString = builder.Configuration.GetConnectionString("NspDay09LabCFConnection");
builder.Services.AddDbContext<NspDay09LabCFContext>(nspOptions => nspOptions.UseSqlServer(nspConnectString));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{nspid?}");

app.Run();
