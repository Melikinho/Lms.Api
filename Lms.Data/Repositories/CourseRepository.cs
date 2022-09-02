using Lms.Api.Data;
using Lms.Core.Entities;
using Lms.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lms.Data.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly LmsApiContext _context;
        public CourseRepository(LmsApiContext _context)
        {
            this._context = _context;
        }
        public void Add(Course course)
        {
            _context.Add(course);
        }

        public async Task<bool> AnyAsync(int? id)
        {
            ArgumentNullException.ThrowIfNull(id);
            return await _context.Course.AnyAsync(i => i.Id == id);
        }

        public async Task<Course> FindAsync(int? id)
        {
            ArgumentNullException.ThrowIfNull(id);
            var course = await _context.Course.Include(i => i.Modules).FirstOrDefaultAsync(i => i.Id == id);

            if (course == null)
                throw new DirectoryNotFoundException();
            return course;
        }

        public async Task<IEnumerable<Course>> GetAllCourses(bool includeModules)
        {
            var query = _context.Course.Include(i => i.Modules);
            var answer = await query.ToListAsync();
            return answer;
        }

        public async Task<Course> GetCourse(int? id)
        {
            ArgumentNullException.ThrowIfNull(id);
            var course = await _context.Course.Include(i => i.Modules).FirstOrDefaultAsync(i => i.Id == id);
            if (course == null)
                throw new DirectoryNotFoundException();

            return course;
        }

        public void Remove(Course course)
        {
            _context.Remove(course);
        }

        public void Update(Course course)
        {
            _context.Update(course);
        }
    }
}
