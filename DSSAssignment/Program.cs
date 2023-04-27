using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using DSSAssignment.Data;
using Microsoft.AspNetCore.Identity;
using DSSAssignment;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DSSAssignmentIdentityContextConnection") ?? throw new InvalidOperationException("Connection string 'DSSAssignmentIdentityContextConnection' not found.");

builder.Services.AddDbContext<DSSAssignmentIdentityContext>(options =>
    options.UseSqlServer(connectionString));;

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<DSSAssignmentIdentityContext>();;
builder.Services.AddDbContext<DSSAssignmentContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DSSAssignmentContext") ?? throw new InvalidOperationException("Connection string 'DSSAssignmentContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var userManager = services.GetRequiredService<UserManager<IdentityUser>>();

    Seed.Initialize(services);
    Seed.SeedAdmin(userManager);

}

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
app.UseAuthentication();;

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();
