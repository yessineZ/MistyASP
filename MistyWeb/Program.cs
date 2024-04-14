using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using misty.DataAccess.Repository;
using misty.DataAccess.Repository.IRepository;
using misty.Models;
using MistyASP.DataAccess.Data;





var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Add services to the container.


builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("misty.DataAccess")));




builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddControllersWithViews();

builder.Services.AddIdentity<AppUser,IdentityRole>(
    options => {
        options.Password.RequiredUniqueChars = 0;
        options.Password.RequireUppercase = false; 
        options.Password.RequiredLength = 8 ;
        options.Password.RequireNonAlphanumeric = false;
        options.Password.RequireLowercase = false;
    }
    
    ).AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment()) {
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for Modelion scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
