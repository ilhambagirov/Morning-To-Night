using M2N.Domain.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace M2N.Persistence.Data
{
    public static class AppDbSeed
    {
        public async static void SeedData(this IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<AppRole>>();

                if (!db.Stages.Any())
                {
                    var stages = new List<Stage>();

                    stages.Add(new Stage { Name = "Todo", CreatedDate = System.DateTime.Now, CreatedByUserId = 1 });
                    stages.Add(new Stage { Name = "Doing", CreatedDate = System.DateTime.Now, CreatedByUserId = 1 });
                    stages.Add(new Stage { Name = "Done", CreatedDate = System.DateTime.Now, CreatedByUserId = 1 });

                    await db.Stages.AddRangeAsync(stages);
                    await db.SaveChangesAsync();
                }

                if (!db.Users.Any() && !db.UserRoles.Any())
                {
                    var users = new List<AppUser>();

                    users.Add(new AppUser { UserName = "Ilham", Email ="ilham@test.com", EmailConfirmed = true });
                    users.Add(new AppUser { UserName = "Mubo", Email = "Mubo@test.com", EmailConfirmed = true });
                    users.Add(new AppUser { UserName = "Elik", Email = "Elik@test.com", EmailConfirmed = true });

                    foreach (var user in users)
                    {
                        await userManager.CreateAsync(user, "Pa$$w0rd");
                    }
                    var roles = new List<AppRole>();

                    roles.Add(new AppRole {Name = "Admin"});
                    roles.Add(new AppRole { Name = "User" });

                    foreach (var role in roles)
                    {
                        await roleManager.CreateAsync(role);
                    }
                    await db.SaveChangesAsync();
                }
            }
        }
    }
}
