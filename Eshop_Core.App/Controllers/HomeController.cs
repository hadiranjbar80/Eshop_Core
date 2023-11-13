using Eshop_Core.App.Context;
using Eshop_Core.App.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ZarinpalSandbox;

namespace Eshop_Core.App.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private EshopContext _context;

        public HomeController(ILogger<HomeController> logger, EshopContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var products = _context.Products.ToList();
            return View(products);
        }

        #region product section

        public IActionResult ProductDetail(int id)
        {
            // Get a spatial product with its id, including items
            var product = _context.Products.
                Include(p => p.Item).
                SingleOrDefault(p => p.Id == id);

            // Get gategories of the product 
            var categories = _context.Products
                .Where(p => p.Id == id)
                .SelectMany(m => m.CategoryToProducts)
                .Select(s => s.Category).ToList();

            // Create an instance from ProductDetailViewModel
            var pdViewModel = new ProductDetailViewModel()
            {
                Product = product,
                Categories = categories
            };

            return View(pdViewModel);
        }

        #endregion 

        #region cart section

        [Authorize]
        public IActionResult AddToCart(int itemId)
        {
            var product = _context.Products
                .Include(p => p.Item)
                .SingleOrDefault(p => p.ItemId == itemId);

            if (product != null)
            {
                var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier).ToString());
                var order = _context.Orders.FirstOrDefault(o => o.UserId == userId && o.IsFinaly == false);
                if (order != null)
                {
                    var orderDetail =
                       _context.OrderDetails.FirstOrDefault(d => d.OrderId == order.OrderId && d.ProductId == product.Id);
                    if (orderDetail != null)
                    {
                        orderDetail.Count += 1;
                    }
                    else
                    {
                        _context.Add(new OrderDetail()
                        {
                            OrderId = order.OrderId,
                            ProductId = product.Id,
                            Price = product.Item.Price,
                            Count = 1
                        });
                    }
                }
                else
                {
                    order = new Order()
                    {
                        IsFinaly = false,
                        CreateDate = DateTime.Now,
                        UserId = userId
                    };
                    _context.Add(order);
                    _context.SaveChanges();
                    _context.Add(new OrderDetail()
                    {
                        OrderId = order.OrderId,
                        ProductId = product.Id,
                        Price = product.Item.Price,
                        Count = 1
                    });
                }
                _context.SaveChanges();
            }

            return RedirectToAction(nameof(ShowCart));
        }

        public IActionResult ShowCart()
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier).ToString());
            var order = _context.Orders.Where(o => o.UserId == userId)
                .Include(o => o.OrderDetails)
                .ThenInclude(p => p.Product).FirstOrDefault();
            return View(order);
        }

        public IActionResult RemoveFromCart(int detailId)
        {
            var detail = _context.OrderDetails.Find(detailId);
            var order = _context.OrderDetails.FirstOrDefault(o => o.OrderId == detail.OrderId);
            _context.Remove(detail);
            _context.Entry(order).State = EntityState.Deleted;
            _context.SaveChanges();
            return RedirectToAction(nameof(ShowCart));
        }

        #endregion

        [Route("ContactUs")]
        public IActionResult ContactUs()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [Authorize]
        public IActionResult Payment()
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var order = _context.Orders
                .Include(o => o.OrderDetails)
                .FirstOrDefault(o => o.UserId == userId && o.IsFinaly == false);

            if (order == null)
                return NotFound();
            var payment = new Payment((int)order.OrderDetails.Sum(d => d.Price));

            var res = payment.PaymentRequest($"پرداخت شماره فاکتور {order.OrderId}",
                "https://localhost:44309/Users/Home/OnlinePayment/" + order.OrderId, "", "");

            if (res.Result.Status == 100)
            {
                return Redirect("https://sandbox.zarinpal.com/pg/StartPay/" + res.Result.Authority);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet]
        public IActionResult OnlinePayment(int id)
        {
            if (HttpContext.Request.Query["Status"] != "" &&
                HttpContext.Request.Query["Status"].ToString().ToLower() == "ok" &&
                HttpContext.Request.Query["Authority"] != "")
            {
                string authority = HttpContext.Request.Query["Authority"].ToString();
                var order = _context.Orders
               .Include(o => o.OrderDetails)
               .FirstOrDefault(o => o.UserId == id);
                var payment = new Payment((int)order.OrderDetails.Sum(d => d.Price));
                var res = payment.Verification(authority).Result;
                if (res.Status == 100)
                {
                    order.IsFinaly = true;
                    _context.Update(order);
                    _context.SaveChanges();
                    ViewBag.code = res.RefId;
                    return View();
                }
            }

            return NotFound();
        }
    }
}
