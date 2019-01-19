using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymService.Web.Models.Entities
{
    public class Order
    {
        public Guid Id { get; set; }
        public AppUser Customer { get; set; }
        public AppUser Seller { get; set; }
        public DateTime DateCreated { get; set; }
        public bool Paid { get; set; }
        public bool Received { get; set; }

        public virtual ICollection<Sale> Sales { get; set; }
    }
}
