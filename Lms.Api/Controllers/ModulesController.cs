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

namespace Lms.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModulesController : ControllerBase
    {
        private readonly IUoW UoW;
        private readonly LmsMappings lmsMappings;

        public ModulesController(IUoW UoW, LmsMappings lmsMappings)
        {
            this.UoW = UoW;
            this.lmsMappings = lmsMappings;
        }

        // GET: api/Modules
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Module>>> GetModule()
        {
          if (UoW.ModuleRepository == null)
          {
              return NotFound();
          }
            return Ok();
        }

        // GET: api/Modules/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Module>> GetModule(int id)
        {
          if (UoW.ModuleRepository == null)
          {
              return NotFound();
          }
            var @module = await UoW.ModuleRepository.FindAsync(id);

            if (@module == null)
            {
                return NotFound();
            }

            return Ok(GetModule());
        }

        // PUT: api/Modules/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutModule(int id, Module @module)
        {
            if (id != @module.Id)
            {
                return BadRequest();
            }

            //UoW.Entry(@module).State = EntityState.Modified;

                await UoW.CompleteAsync();


            return Ok();
        }

        // POST: api/Modules
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Module>> PostModule(Module @module)
        {
          if (UoW.ModuleRepository == null)
          {
              return Problem("Entity set 'LmsApiContext.Module'  is null.");
          }
            UoW.ModuleRepository.Add(@module);
            await UoW.CompleteAsync();

            return CreatedAtAction("GetModule", new { id = @module.Id }, @module);
        }

        // DELETE: api/Modules/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteModule(int id)
        {
            if (UoW.ModuleRepository == null)
            {
                return NotFound();
            }
            var @module = await UoW.ModuleRepository.FindAsync(id);
            if (@module == null)
            {
                return NotFound();
            }

            UoW.ModuleRepository.Remove(@module);
            await UoW.CompleteAsync();

            return Ok();
        }

        //private bool ModuleExists(int id)
        //{
        //    return (_context.Module?.Any(e => e.Id == id)).GetValueOrDefault();
        //}
    }
}
