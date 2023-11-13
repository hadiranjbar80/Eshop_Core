using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eshop_Core.App.Models
{
    public class Item
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public int QuantityInStok { get; set; }

        public Product Product { get; set; }
    }
}
