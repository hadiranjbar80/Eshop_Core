using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eshop_Core.App.Models
{
    public class ProductDetailViewModel
    {
        public Product Product { get; set; }
        public List<Category> Categories { get; set; }
    }
}
