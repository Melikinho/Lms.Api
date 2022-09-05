using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Lms.Data.Data;
using Lms.Core.Entities;
using Lms.Core.Repositories;
using Lms.Data.Repositories;

namespace Lms.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly IUoW UoW;

        public CoursesController(IUoW uow)
        {
            UoW = uow;
        }

        // GET: api/Courses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Course>>> GetCourse(bool includeModules)
        {
            var courses = await UoW.CourseRepository.GetAllCourses(includeModules);
          if (UoW.CourseRepository == null)
          {
              return NotFound();
          }
            return Ok(courses);
        }

        // GET: api/Courses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Course>> GetCourse(int id)
        {
          if (UoW.CourseRepository == null)
          {
              return NotFound();
          }
            var course = await UoW.CourseRepository.FindAsync(id);

            if (course == null)
            {
                return NotFound();
            }

            return course;
        }

        // PUT: api/Courses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCourse(int id, Course course)
        {
            //await UoW.CourseRepository.FindAsync(id, false);
            if (course is null)
                return NotFound();
            await UoW.CompleteAsync();
            return Ok(course);
        }

        // POST: api/Courses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Course>> PostCourse(Course course)
        {
          if (UoW.CourseRepository == null)
          {
              return Problem("Entity set 'LmsApiContext.Course'  is null.");
          }
            UoW.CourseRepository.Add(course);
            await UoW.CompleteAsync();

            return CreatedAtAction("GetCourse", new { id = course.Id }, course);
        }

        // DELETE: api/Courses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourse(int id)
        {
            if (UoW.CourseRepository == null)
            {
                return NotFound();
            }
            var course = await UoW.CourseRepository.FindAsync(id);
            if (course == null)
            {
                return NotFound();
            }

            UoW.CourseRepository.Remove(course);
            await UoW.CompleteAsync();

            return NoContent();
        }

        //private bool CourseExists(int id)
        //{
        //    return (UoW.CourseRepository.Any(e => e.Id == id)).GetValueOrDefault();
        //}
    }
}
