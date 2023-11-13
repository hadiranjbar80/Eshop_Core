using Eshop_Core.App.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eshop_Core.App.Controllers
{
    public class ProductController : Controller
    {
        private EshopContext _context;

        public ProductController(EshopContext context)
        {
            _context = context;
        }

        [Route("Group/{id}/{name}")]
        public IActionResult ShowProductByGroupId(int id,string name)
        {
            ViewData["GroupName"] = name;
            var product = _context.CategoryToProducts
                .Where(c => c.CategoryId == id)
                .Include(p => p.Product)
                .Select(p => p.Product)
                .ToList();
            return View(product);
        }
    }
}
