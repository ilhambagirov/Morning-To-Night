using M2N.Domain.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
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

                if (!db.Stages.Any())
                {
                    var stages = new List<Stage>();

                    stages.Add(new Stage { Name = "Todo", CreatedDate = System.DateTime.Now, CreatedByUserId = 1 });
                    stages.Add(new Stage { Name = "Doing", CreatedDate = System.DateTime.Now, CreatedByUserId = 1 });
                    stages.Add(new Stage { Name = "Done", CreatedDate = System.DateTime.Now, CreatedByUserId = 1 });

                    await db.Stages.AddRangeAsync(stages);
                    await db.SaveChangesAsync();
                }
            }
        }
    }
}
