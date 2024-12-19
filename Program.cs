using TodoApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// для БД
builder.Services.AddDbContext<AppIdentityDbContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("MyDataBase")));

//сервис для CoreIdentity
builder.Services.AddIdentityCore<IdentityUser>().
AddEntityFrameworkStores<AppIdentityDbContext>().
AddSignInManager(); // для входа в систему

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
    pattern: "{controller=Account}/{action=Index}/{id?}");

app.Run();
