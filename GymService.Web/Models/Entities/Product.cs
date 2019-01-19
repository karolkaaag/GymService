using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymService.Web.Models.Entities
{
    public class Product
    {
        public Guid Id { get; set; }
        public double Price { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
