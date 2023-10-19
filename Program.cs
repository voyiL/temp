using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Asp.NetProject.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity.UI.Services;
using Primary_HealthCare_System.Services;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("ApplicationDbContextConnection") ?? throw new InvalidOperationException("Connection string 'ApplicationDbContextConnection' not found.");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddTransient<IEmailSender, EmailSender>();
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
app.UseAuthentication();;

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
//created roles default
using (var scope = app.Services.CreateScope())
{
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

    var roles = new[] { "Administration", "Patient", "Nurse", "Counsellor", "Doctor"};

    foreach (var role in roles)
    {
        if (!await roleManager.RoleExistsAsync(role))
        {
            await roleManager.CreateAsync(new IdentityRole(role));
        }
    }

}
//assigning admin role to one user only
using (var scope = app.Services.CreateScope())
{
    var userManager =

    scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
    string firstName = "Vuyo";
    string lastName = "Dan";
    string email = "danvuyo@gmail.com";
    string password = "Daniel@1";
    if (await userManager.FindByEmailAsync(email) == null)
    {
        var user = new ApplicationUser();
        user.firstName = firstName;
        user.lastName = lastName;
        user.UserName = email;
        user.Email = email;
        user.EmailConfirmed = true;

        await userManager.CreateAsync(user, password);
        await userManager.AddToRoleAsync(user, "Administration");
    }

}
using (var scope = app.Services.CreateScope())
{
    var userManager =

    scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
    string firstName = "Vuyo";
    string lastName = "Deanil";
    string email = "denialvuyo@gmail.com";
    string password = "Daniel@1";
    if (await userManager.FindByEmailAsync(email) == null)
    {
        var user = new ApplicationUser();
        user.firstName = firstName;
        user.lastName = lastName;
        user.UserName = email;
        user.Email = email;
        user.EmailConfirmed = true;

        await userManager.CreateAsync(user, password);
        await userManager.AddToRoleAsync(user, "Patient");
    }

}

using (var scope = app.Services.CreateScope())
{
    var userManager =

    scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
    string firstName = "Dorry";
    string lastName = "Molele";
    string email = "Dorry@gmail.com";
    string password = "Dorry@1";
    if (await userManager.FindByEmailAsync(email) == null)
    {
        var user = new ApplicationUser();
        user.firstName = firstName;
        user.lastName = lastName;
        user.UserName = email;
        user.Email = email;
        user.EmailConfirmed = true;

        await userManager.CreateAsync(user, password);
        await userManager.AddToRoleAsync(user, "Patient");
    }

}
using (var scope = app.Services.CreateScope())
{
    var userManager =

    scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
    string firstName = "Molatji";
    string lastName = "Molela";
    string email = "Molatji@gmail.com";
    string password = "Molatji@1";
    if (await userManager.FindByEmailAsync(email) == null)
    {
        var user = new ApplicationUser();
        user.firstName = firstName;
        user.lastName = lastName;
        user.UserName = email;
        user.Email = email;
        user.EmailConfirmed = true;

        await userManager.CreateAsync(user, password);
        await userManager.AddToRoleAsync(user, "Counsellor");
    }

}
app.MapRazorPages();
app.Run();
