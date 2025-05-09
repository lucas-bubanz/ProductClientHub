using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductClienteHub.API.Entities
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Brand { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public Guid ClientId { get; set; }

    }
}