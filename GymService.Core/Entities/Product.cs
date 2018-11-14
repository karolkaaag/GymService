using System;
using System.Collections.Generic;
using System.Text;

namespace GymService.Core.Entities
{
    class Product
    {
        public Guid Id { get; protected set; }
        public string Name { get; protected set; }
        public string Description { get; protected set; }
        public double BasePrice { get; protected set; }
    }
}
