using e.ShopSolution.Application.Catalog;
using e.ShopSolution.Application.System.Users;
using e.ShopSolution.Data.EF;
using e.ShopSolution.Data.Entities;
using eShopSolution.Application.Common;
using eShopSolution.Application.System.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
// Connect database
var connectionString = builder.Configuration.GetConnectionString("ConnectionStrings");
builder.Services.AddDbContext<EShopDbContext>(options =>
{
    // Chuỗi DataContext: Là chuỗi trong file Json: appsettings.Development (
    options.UseSqlServer(builder.Configuration.GetConnectionString("eShopSolutionDb"));
});
//add indentity
builder.Services.AddIdentity<AppUser, AppRole>()
    .AddEntityFrameworkStores<EShopDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddTransient<IPublicProductService, PublicProductService>();
builder.Services.AddTransient<IManageProductService, ManageProductService>();
builder.Services.AddTransient<IStorageService, FileStorageService>();

builder.Services.AddTransient<UserManager<AppUser>, UserManager<AppUser>>();
builder.Services.AddTransient<SignInManager<AppUser>, SignInManager<AppUser>>();
builder.Services.AddTransient<RoleManager<AppRole>, RoleManager<AppRole>>();
builder.Services.AddTransient<IUserService, UserService>();


builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "eShopSolution",
       
    });
});



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


//

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Swagger Base Project");
});
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
