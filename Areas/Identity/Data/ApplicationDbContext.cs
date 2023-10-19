using Asp.NetProject.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Primary_HealthCare_System.Models;

namespace Asp.NetProject.Areas.Identity.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);

       
    }

    public DbSet<Primary_HealthCare_System.Models.Appointments>? Appointments { get; set; }

    public DbSet<Primary_HealthCare_System.Models.Medical_File>? Medical_File { get; set; }

    public DbSet<Primary_HealthCare_System.Models.Medical_Record>? Medical_Record { get; set; }

    public DbSet<Primary_HealthCare_System.Models.Feedback>? Feedback { get; set; }

    public DbSet<Primary_HealthCare_System.Models.Referal>? Referal { get; set; }
    public DbSet<Primary_HealthCare_System.Models.Alert>? Alerts { get; set; }
    public DbSet<Primary_HealthCare_System.Models.Counselling_Sessions>? Counselling_Sessions { get; set; }

    //Chronic Med
    public DbSet<PatientEducation>? PatientEducation { get; set; }
    public DbSet<Reminder>? Reminder { get; set; }
    public DbSet<RefillRequest>? RefillRequest { get; set; }
}






