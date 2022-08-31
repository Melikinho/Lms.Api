using Lms.Api.Data;
using Lms.Core.Entities;
using Lms.Core.Repositories;
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

        public Task<bool> AnyAsync(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<Module> FindAsync(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Module>> GetAllModules()
        {
            throw new NotImplementedException();
        }

        public Task<Module> GetModule(int? id)
        {
            throw new NotImplementedException();
        }

        public void Remove(Module module)
        {
            throw new NotImplementedException();
        }

        public void Update(Module module)
        {
            throw new NotImplementedException();
        }
    }
}
