using Microsoft.EntityFrameworkCore;
using myfinance_web_netcore.Domain.Services;
using myfinance_web_netcore.Infrastructure.ApplicationDbContext;
using myfinance_web_netcore.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// If you want to use a different database, change the 'DevConnection' string in appsettings.json file.
string dbConnectionString = builder.Configuration.GetConnectionString("DevConnection");

// Add the database context.
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(dbConnectionString));

// Dependency Injection Services Registration
builder.Services.AddScoped<IPlanoContaRepository, PlanoContaRepository>();
builder.Services.AddScoped<ITransacaoRepository, TransacaoRepository>();

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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
