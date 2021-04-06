using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_EF_Start.DataAccess;
using MVC_EF_Start.Models;
using System;
using System.Linq;

namespace MVC_EF_Start.Controllers
{
    public class HomeController : Controller
    {

        public ApplicationDbContext dbContext;
        public HomeController(ApplicationDbContext context)
        {
            dbContext = context;
        }

       

        public IActionResult Index()
        {
            Order Myorder = new Order { Qty = 100 };
            Product Myproduct = new Product { ProductName = "Shampoo" };
            Placed placed = new Placed
            {
                PlacedOrder = Myorder,
                PlacedProduct = Myproduct,
                PlacedDate = DateTime.Now
            };

            Order Myorder1 = new Order { Qty = 30 };
            Product Myproduct1 = new Product { ProductName = "Soap" };
            Placed placed1 = new Placed
            {
                PlacedOrder = Myorder1,
                PlacedProduct = Myproduct1,
                PlacedDate = DateTime.Now
            };

            Order Myorder2 = new Order { Qty = 10 };
            Product Myproduct2 = new Product { ProductName = "Comb" };
            Order Myorder3 = new Order { Qty = 1 };
            Product Myproduct3 = new Product { ProductName = "Conditioner" };
            Placed placed2 = new Placed
            {
                PlacedOrder = Myorder2,
                PlacedProduct = Myproduct2,
                PlacedDate = DateTime.Now
            };


            Placed placed3 = new Placed
            {
                PlacedOrder = Myorder3,
                PlacedProduct = Myproduct2,
                PlacedDate = DateTime.Now
            };

            dbContext.Orders.Add(Myorder);
            dbContext.Products.Add(Myproduct);
            dbContext.Places.Add(placed);

            dbContext.Orders.Add(Myorder1);
            dbContext.Products.Add(Myproduct1);
            dbContext.Places.Add(placed1);

            dbContext.Orders.Add(Myorder2);
            dbContext.Products.Add(Myproduct2);
            dbContext.Places.Add(placed2);

            dbContext.Orders.Add(Myorder3);
            dbContext.Products.Add(Myproduct3);
            dbContext.Places.Add(placed3);


            dbContext.SaveChanges();

            // READ operation



            var a = dbContext.Orders
                    .Include(c => c.ID)
                    .Where(c => c.Qty != 0);

            
            return View();
        }
    }
}