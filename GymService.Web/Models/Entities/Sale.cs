using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GymService.Web.Models.Entities
{
    public class Sale
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public Guid OrderId { get; set; }
        [Range(1, int.MaxValue)]
        public int Quantity { get; set; }
        public double Price { get; set; }

        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
    }
}
