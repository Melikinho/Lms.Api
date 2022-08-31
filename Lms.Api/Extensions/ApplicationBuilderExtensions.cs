using Lms.Api.Data;
using Lms.Data.Data;
using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;

namespace Lms.Api.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static async Task<IApplicationBuilder>SeedDataAsync(this IApplicationBuilder application)
        {
            using (var scope = application.ApplicationServices.CreateScope())
            {
                var serviceProvider = scope.ServiceProvider;
                var db = serviceProvider.GetRequiredService<LmsApiContext>();
                db.Database.EnsureCreated();
                db.Database.Migrate();

                try
                {
                    await SeedData.InitAsync(db);
                }
                catch(Exception e)
                {
                    throw;
                }
            }

            return application;
        }         

    }

}
