using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Eshop_Core.App.Context;
using Eshop_Core.App.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Eshop_Core.App.Pages.Admin
{
    public class DeleteProductModel : PageModel
    {
        private EshopContext _context;

        public DeleteProductModel(EshopContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Product Product { get; set; }
        public void OnGet(int id)
        {
            Product = _context.Products.FirstOrDefault(p => p.Id == id);
        }

        public IActionResult OnPost()
        {
            var product = _context.Products.Find(Product.Id);
            var item = _context.Items.First(p => p.Id == product.Id);

            _context.Remove(item);
            _context.Remove(product);
            _context.SaveChanges();

            string filePath = Path.Combine(Directory.GetCurrentDirectory(),
                    "wwwroot"
                    , "images"
                    , product.Id + "jpg");
            if (System.IO.File.Exists(filePath))
            {
                System.IO.File.Delete(filePath);
            }

            return RedirectToPage("Index");
        }
    }
}
