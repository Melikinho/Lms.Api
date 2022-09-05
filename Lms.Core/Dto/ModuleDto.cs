using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lms.Core.Dto
{
#nullable disable
    public class ModuleDto
    {
        public string TitleDto { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime StopDate => StartDate.AddMonths(1);
    }
}
