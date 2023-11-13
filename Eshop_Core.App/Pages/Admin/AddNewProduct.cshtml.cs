using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Eshop_Core.App.Context;
using Eshop_Core.App.Models;
using System.IO;

namespace Eshop_Core.App.Pages.Admin
{
    public class AddNewProductModel : PageModel
    {
        private EshopContext _context;

        public AddNewProductModel(EshopContext context)
        {
            _context = context;
        }

        [BindProperty]
        public AddEditProductViewModel Product { get; set; }

        [BindProperty]
        public List<int> selectedGroups { get; set; }
        public void OnGet()
        {
            Product = new AddEditProductViewModel()
            {
                Categories = _context.Categories.ToList()   
            };
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            var item = new Item()
            {
                Price = Product.Price,
                QuantityInStok = Product.QuantityInStock
            };
            _context.Add(item);
            _context.SaveChanges();

            var pro = new Product()
            {
                Name = Product.Name,
                Item = item,
                Description = Product.Description
            };
            _context.Add(pro);
            _context.SaveChanges();
            pro.ItemId = pro.Id;
            _context.SaveChanges();

            /* Image */

            if (Product.Picturee?.Length > 0)
            {
                var filePath = Path.Combine(Directory.GetCurrentDirectory(),
                    "wwwroot",
                    "images",
                    pro.Id + Path.GetExtension(Product.Picturee.FileName));
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    Product.Picturee.CopyTo(stream);
                }
            }

            /* End Image */
            
            /*  */
            if (selectedGroups.Any() && selectedGroups.Count > 0)
            {
                foreach (var groups in selectedGroups)
                {
                    _context.CategoryToProducts.Add(new CategoryToProduct()
                    {
                        CategoryId=groups,
                        ProductId= pro.Id

                    });
                }
                _context.SaveChanges();
            }

            return RedirectToPage("Index");
        }
    }
}
