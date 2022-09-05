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
using Lms.Core.Lms.Core.Dto;
using AutoMapper;

namespace Lms.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly IUoW UoW;
        private readonly IMapper mapper;

        public CoursesController(IUoW uow, IMapper mapper)
        {
            this.mapper = mapper;
            this.UoW = uow;
        }

        // GET: api/Courses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CourseDto>>> GetCourse(bool includeModules)
        {
            var courses = await UoW.CourseRepository.GetAllCourses(includeModules);
            var coursedto = mapper.Map<IEnumerable<CourseDto>>(courses);
            return Ok(courses);
        }

        // GET: api/Courses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CourseDto>> GetCourse(int id)
        {
          if (await UoW.CourseRepository.AnyAsync(id))
          {
              return BadRequest();
          }
            var course = await UoW.CourseRepository.GetCourse(id);
            var courseDto = mapper.Map<CourseDto>(course);

            return Ok(courseDto);
        }

        // PUT: api/Courses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCourse(int id, Course course)
        {
            try
            {
                UoW.CourseRepository.Update(course);
                await UoW.CompleteAsync();
            }
            catch(Exception)
            {
                return StatusCode(500);
            }
            return BadRequest();
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
