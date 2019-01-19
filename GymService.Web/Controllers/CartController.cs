using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GymService.Web.Models.Entities;
using GymService.Web.Persistence;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Claims;

namespace GymService.Web.Controllers
{
    public class CartController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        public CartController(AppDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        const string SessionCart = "Cart";

        // GET: Cart
        public ActionResult Index()
        {
            List<Sale> cart = HttpContext.Session.Get<List<Sale>>();

            return View(cart);
        }

        public ActionResult Buy(Guid id)
        {
            List<Sale> cart = HttpContext.Session.Get<List<Sale>>();

            if (cart == null ? false : cart.Find(x => x.Product.Id == id) != null)
            {
                cart.Find(x => x.Product.Id == id).Quantity++;
            }
            else
            {
                if (cart == null)
                    cart = new List<Sale>();

                Product product = _context.Products.Find(id);
                cart.Add(
                    new Sale
                    {
                        Price = product.Price,
                        Product = product,
                        Quantity = 1,
                    }
                );
            }

            HttpContext.Session.Set(cart);
            HttpContext.Session.SetInt32("_CartCount", cart.Count);
            return RedirectToAction("Index", "Shop");
        }

        public ActionResult Remove(Guid id)
        {
            List<Sale> cart = HttpContext.Session.Get<List<Sale>>();
            cart.Remove(cart.Find(x => x.Product.Id == id));
            HttpContext.Session.Set(cart);

            return RedirectToAction("Index");
        }

        [Authorize]
        public async Task<IActionResult> SubmitOrder()
        {
            List<Sale> sales = HttpContext.Session.Get<List<Sale>>();
            var currentUser = await _userManager.GetUserAsync(User);
            Order order = new Order
            {
                Customer = currentUser,
                Seller = null,
                DateCreated = DateTime.Now,
                Paid = false,
                Received = false,
            };
            foreach (var item in sales)
            {
                item.ProductId = item.Product.Id;
                item.Product = null;
                item.Order = order;
            }
            order.Sales = sales;
            _context.Orders.Add(order);
            _context.SaveChanges();

            return View(order);
        }
    }

    public static class CartSessionExtensions
    {
        private const string CartSessionKey = "_CartKey";
        public static void Set<T>(this ISession session, T value)
        {
            session.SetString(CartSessionKey, JsonConvert.SerializeObject(value));
        }

        public static T Get<T>(this ISession session)
        {
            var value = session.GetString(CartSessionKey);

            return value == null ? default(T) :
                JsonConvert.DeserializeObject<T>(value);
        }
    }
}