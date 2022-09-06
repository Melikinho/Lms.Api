using Lms.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lms.Core.Repositories
{
    public interface IModuleRepository
    {
        public Task<IEnumerable<Module>> GetAllModules();
        public Task<Module> GetModule(string Title);
        public Task<Module> FindAsync(int? id);
        public Task<bool> AnyAsync(int? id);
        public void Add(Module module);
        public void Update(Module module);
        public void Remove(Module module);

    }
}
