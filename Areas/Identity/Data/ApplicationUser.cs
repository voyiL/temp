using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Asp.NetProject.Areas.Identity.Data;

// Add profile data for application users by adding properties to the AppplicationUser class
public class ApplicationUser : IdentityUser
{
    
    public string? firstName { get;set; }
    

    public string? lastName { get;set; }



     
}

