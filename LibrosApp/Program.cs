using Microsoft.EntityFrameworkCore;
using LibrosApp.Models;

var builder = WebApplication.CreateBuilder(args);

var librosAppCNS = builder.Configuration.GetConnectionString("LibrosAppCNS");

builder.Services.AddDbContext<LibrosContext>(options => options.UseSqlServer(librosAppCNS));

// Add services to the container.
builder.Services.AddControllersWithViews();

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
    pattern: "{controller=Home}/{action=Authors}/{id?}");

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var dbContext = services.GetRequiredService<LibrosContext>();

    dbContext.Database.Migrate();
   
}

app.Run();
