using Microsoft.EntityFrameworkCore;
using ObraFacilApp.Migrations;
using ObraFacilApp.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("appsettings.json", optional: false)
        .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json", optional: true)
        .AddJsonFile("appsettings.localhost.json", optional: true)
        .AddEnvironmentVariables();

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddSession();

var Configuration = builder.Configuration;

builder.Services.AddDbContext<ContextoModel>
    (options => options.UseSqlServer
    (Configuration.GetConnectionString("master")));
    //("Data Source=ACERNITRO;Initial Catalog=master;User ID=sa;Password=root; trustServerCertificate=true"));
    //SEnha banco Azure:
    //ObraFacil2023 servidor: acernitro
    //("Server = tcp:bancoobrafacil.database.windows.net, 1433; Initial Catalog = ObraFacil - banco; Persist Security Info=False; User ID =acernitro; Password ={ObraFacil2023}; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30"));


var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Logar}/{action=index}/{id?}");

app.Run();
