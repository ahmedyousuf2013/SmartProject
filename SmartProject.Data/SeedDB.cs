using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartProject.Data
{
    public class SeedDB
    {

        public static void Initialize(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetRequiredService<ApplicationDbContext>();
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            context.Database.EnsureCreated();
            if (!context.Users.Any())
            {
                ApplicationUser user = new ApplicationUser()
                {
                    Email = "goldena91@gmail.com",
                    SecurityStamp = Guid.NewGuid().ToString(),
                    UserName = "goldena91"
                };
                userManager.CreateAsync(user, "@78Ed12848");
            }
        }
    }
}
