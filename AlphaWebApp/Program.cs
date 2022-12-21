using AlphaWebApp.Data;
using AlphaWebApp.Models;
using AlphaWebApp.Models.Seeds;
using AlphaWebApp.Services;
using Microsoft.AspNetCore.Authorization.Policy;
//using Castle.Core.Smtp;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
//builder.Services.AddDatabaseDeveloperPageExceptionFilter();

// Add services to the container. 
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseLazyLoadingProxies().UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();



    
//Add Services
builder.Services.AddScoped<ApplicationDbContext, ApplicationDbContext>();
builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient("sendEmail");
builder.Services.AddScoped<IArticleService, ArticleService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.AddScoped<IStorageService, StorageService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ISubscriptionTypeService, SubscriptionTypeService>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<IWeatherForcastService,WeatherForcastService>();
builder.Services.AddScoped<ISubscriptionService,SubscriptionService>();

//To make Swagger work
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddResponseCaching();


var app = builder.Build();

// Initializing seed for models
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    SeedCategoryData.Initialize(services);
    SeedSubscriptionTypeData.Initialize(services);
}

//// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //app.UseMigrationsEndPoint();
    //To make Swagger work
    app.UseSwagger();
    app.UseSwaggerUI();
}
//else
//{
//    app.UseExceptionHandler("/Home/Error");
//    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
//    app.UseHsts();
//}

//app.UseResponseCaching();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();


