using GymService.Web.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymService.Web.Controllers
{
    public class Class
    {
        private AppDbContext context;
        public Class(AppDbContext context)
        {
            this.context = context;

        }
    }
}
