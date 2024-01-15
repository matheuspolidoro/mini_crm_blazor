using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Mini_CRM_Blazor.Server.Configuration;
using Mini_CRM_Blazor.Server.DAL;
using Mini_CRM_Blazor.Server.DAL.Seeds;
using Mini_CRM_Blazor.Server.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.RegisterServices();
builder.Services.RegisterRepositories();
builder.Services.AddAutoMapper(typeof(Program));

builder.Services.ConfigureApplicationCookie(options =>
{
    options.Cookie.HttpOnly = false;
    options.Events.OnRedirectToLogin = context =>
    {
        context.Response.StatusCode = 401;
        return Task.CompletedTask;
    };
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();


    using (var scope = app.Services.CreateScope())
    {
        CreateUsers.CreateRoles(scope.ServiceProvider, builder).Wait();
    }
}
else
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//var serviceProvider = app.Services.GetService<IServiceProvider>();
//CreateRoles(serviceProvider, builder).Wait();

app.UseHttpsRedirection();
app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
