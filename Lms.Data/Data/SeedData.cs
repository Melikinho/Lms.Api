using Bogus;
using Lms.Api.Data;
using Lms.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lms.Data.Data
{
    public class SeedData
    {
        private static LmsApiContext db = default!;
        public static async Task InitAsync(LmsApiContext context)
        {
            //var faker = new Faker("sv");
            //var courses = new List<Course>();

            if (context == null) throw new ArgumentNullException(nameof(context));
            db = context;

            var courses = GetCourses();
            await db.Course.AddRangeAsync(courses);

            var modules = GetModules();
            await db.Module.AddRangeAsync();


            if (await db.Course.AnyAsync()) return;

            await db.SaveChangesAsync();
        }

        private static IEnumerable<Module> GetModules()
        {
            return new[]
            {
            new Module()
            {
                Id = 1,
                Title = "Programming",
                StartDate = DateTime.Now,
                CourseId = 1
            },
            new Module()
            {
                Id = 2,
                Title = "Language",
                StartDate = DateTime.Now,
                CourseId = 2
            }

        };

        }

        private static IEnumerable<Course> GetCourses()
        {
            return new[]
            {
                new Course()
            {
                Id = 1,
                Title = "Programming Course",
                StartDate = DateTime.Today.AddDays(3).AddHours(7)
            },
                new Course()
                {
                    Id = 2,
                    Title = "Math Course",
                    StartDate = DateTime.Today.AddDays(2).AddHours(6)
                }
        };

        }
    }
}
