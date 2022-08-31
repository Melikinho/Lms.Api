using Lms.Api.Data;
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
        private static LmsApiContext db;
        public static async Task InitAsync(LmsApiContext context)
        {
            if (context == null) throw new ArgumentNullException(nameof(context));
            db = context;

            if (await db.Course.AnyAsync()) return;
        }




    }
}
