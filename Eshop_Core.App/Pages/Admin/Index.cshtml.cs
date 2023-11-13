using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Eshop_Core.App.Context;
using Eshop_Core.App.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Eshop_Core.App.Pages.Admin
{
    public class IndexModel : PageModel
    {
        private EshopContext _context;

        public IndexModel(EshopContext context)
        {
            _context = context;
        }

        public IEnumerable<Product> Products { get; set; }

        public void OnGet()
        {
            Products = _context.Products.Include(p => p.Item);
        }

        public void OnPost()
        {
        }
    }
}
