using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Eshop_Core.App.Context;
using Eshop_Core.App.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Eshop_Core.App.Pages.Admin
{
    public class EditProductModel : PageModel
    {
        private EshopContext _context;

        public EditProductModel(EshopContext context)
        {
            _context = context;
        }

        [BindProperty]
        public AddEditProductViewModel Product { get; set; }

        [BindProperty]
        public List<int> selectedGroups { get; set; }
        public List<int> groups { get; set; }
        public void OnGet(int id)
        {
            var getProduct = _context.Products.Include(p => p.Item)
                .Where(p => p.Id == id)
                .Select(s => new AddEditProductViewModel()
                {
                    Id = s.Id,
                    Name = s.Name,
                    Description = s.Description,
                    QuantityInStock = s.Item.QuantityInStok,
                    Price = s.Item.Price
                }).FirstOrDefault();

            Product = getProduct;
            getProduct.Categories = _context.Categories.ToList();
            groups = _context.CategoryToProducts.Where(c => c.ProductId == id)
                .Select(c => c.CategoryId).ToList();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            var product = _context.Products.Find(Product.Id);
            var item = _context.Items.First(p => p.Id == product.Id);

            product.Name = Product.Name;
            product.Description = Product.Description;
            item.Price = Product.Price;
            item.QuantityInStok = Product.QuantityInStock;

            _context.SaveChanges();

            if (Product.Picturee?.Length > 0)
            {
                string filePath = Path.Combine(Directory.GetCurrentDirectory(),
                    "wwwroot"
                    , "images"
                    , product.Id + Path.GetExtension(Product.Picturee.FileName));
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    Product.Picturee.CopyTo(stream);
                }
            }

            _context.CategoryToProducts.Where(c => c.ProductId == Product.Id).ToList()
                .ForEach(g => _context.CategoryToProducts.Remove(g));

            /*  */
            if (selectedGroups.Any() && selectedGroups.Count > 0)
            {
                foreach (var groups in selectedGroups)
                {
                    _context.CategoryToProducts.Add(new CategoryToProduct()
                    {
                        CategoryId = groups,
                        ProductId = Product.Id

                    });
                }
                _context.SaveChanges();
            }

            return RedirectToPage("Index");
        }
    }
}
