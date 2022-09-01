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
    public class ModuleRepository : IModuleRepository
    {
        private readonly LmsApiContext _context;
        public ModuleRepository(LmsApiContext _context)
        {
            this._context = _context;
        }
        public void Add(Module module)
        {
            _context.Add(module);
        }

        public async Task<bool> AnyAsync(int? id)
        {
            ArgumentNullException.ThrowIfNull(id);
            return await _context.Module!.AnyAsync(i => i.Id == id);
        }

        public async Task<Module> FindAsync(int? id)
        {
            ArgumentNullException.ThrowIfNull(id);
            return await _context.Module.FindAsync(id);
        }

        public async Task<IEnumerable<Module>> GetAllModules()
        {
            return await _context.Module!.ToListAsync();
        }

        public async Task<Module> GetModule(int? id)
        {
            ArgumentNullException.ThrowIfNull(id);
            var modules = await _context.Module!.FindAsync(id);
            if (modules is null)
                throw new DirectoryNotFoundException();
            return modules;
        }

        public void Remove(Module module)
        {
            _context.Remove(module);
        }

        public void Update(Module module)
        {
            _context.Update(module);
        }
    }
}
