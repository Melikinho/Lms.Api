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
using AutoMapper;
using Lms.Core.Dto;

namespace Lms.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModulesController : ControllerBase
    {
        private readonly IUoW UoW;
        private readonly IMapper mapper;

        public ModulesController(IUoW UoW, IMapper mapper)
        {
            this.UoW = UoW;
            this.mapper = mapper;
        }

        // GET: api/Modules
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ModuleDto>>> GetModule()
        {
            var modules = await UoW.ModuleRepository.GetAllModules();
            var modulesDto = mapper.Map<IEnumerable<ModuleDto>>(modules);
            return Ok(modulesDto);
        }

        // GET: api/Modules/5
        [HttpGet("{title}")]
        public async Task<ActionResult<Module>> GetModule(string Title)
        {
            var modules = await UoW.ModuleRepository.GetModule(Title);
            var moduleDto = mapper.Map<ModuleDto>(modules);

            return Ok();
        }

        // PUT: api/Modules/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutModule(int id, Module @module)
        {
            try 
            {
                UoW.ModuleRepository.Update(@module);
                await UoW.CompleteAsync();
            }
            catch(Exception)
            {
                return StatusCode(500);
            }
            //UoW.Entry(@module).State = EntityState.Modified;
                //await UoW.CompleteAsync();
            return BadRequest();
        }

        // POST: api/Modules
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Module>> PostModule(Module @module)
        {
          try 
          {
                UoW.ModuleRepository.Add(@module);
                await UoW.CompleteAsync();
            }
            catch (Exception)
            {
                StatusCode(500);
            }


            return CreatedAtAction("GetModule", new { id = @module.Id }, @module);
        }

        // DELETE: api/Modules/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteModule(int id)
        {
            if (await UoW.ModuleRepository.AnyAsync(id));
            {
                return BadRequest();
            }
            try
            {
                UoW.ModuleRepository.Remove(await UoW.ModuleRepository.FindAsync(id));
                await UoW.CompleteAsync();
            }
            catch (Exception)
            {
                throw;
            }

            //UoW.ModuleRepository.Remove(@module);
            //await UoW.CompleteAsync();

            return BadRequest();
        }

        //private bool ModuleExists(int id)
        //{
        //    return (_context.Module?.Any(e => e.Id == id)).GetValueOrDefault();
        //}
    }
}
