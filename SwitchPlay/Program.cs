using Microsoft.EntityFrameworkCore;
using SwitchPlay.Data;
using SwitchPlay.Repositories;
using SwitchPlay.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<SwitchPlayContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("SwitchPlayContext") ?? throw new InvalidOperationException("Connection string not found")));

// Add services to the container.
builder.Services.AddControllersWithViews();






builder.Services.AddScoped<CategeoryRepository>();

builder.Services.AddTransient<ICategoryService, CategoryService>();




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
