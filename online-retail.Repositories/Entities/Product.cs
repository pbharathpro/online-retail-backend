using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace online_retail.Repositories.Entities
{
    public class Product
    {
        [Key]
        public Guid ProductId { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
