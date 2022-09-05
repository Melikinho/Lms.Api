using Bogus;
using Lms.Data.Data;
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


            if (context == null) throw new ArgumentNullException(nameof(context));
            db = context;

            var courses = GetCourses();
            db.AddRange(courses);

            if (db.Course.Any()) return;

            await db.SaveChangesAsync();
        }

        private static IEnumerable<Course> GetCourses()
        {
            var courses = new List<Course>();
            var faker = new Faker("sv");
            for (int i = 0; i < 10; i++)
            {
                var data = new Course()
                {
                    Title = faker.Random.Word(),
                    StartDate = faker.Date.Soon()
                };
                data.Modules = GetModules(data);
                courses.Add(data);
            }
            return courses;
        }

        private static ICollection<Module> GetModules(Course course)
        {

            var modules = new List<Module>();
            var faker = new Faker("sv");
            for (int i = 0; i < faker.Random.Int(0,20); i++)
            {
                var data = new Module()
                {
                    Title = faker.Random.Word(),
                    StartDate = faker.Date.Soon()
                };
                modules.Add(data);
            }
            return modules;
        }
    }
}
