using GymService.Web.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymService.Web.Models.Entities
{
    public class Subscription
    {
        public Guid Id { get; set; }
        public SubscriptionType Type { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public AppUser Owner { get; set; }
    }
}
