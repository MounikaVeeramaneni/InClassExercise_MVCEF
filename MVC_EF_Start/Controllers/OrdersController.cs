using Microsoft.AspNetCore.Mvc;
using MVC_EF_Start.DataAccess;
using MVC_EF_Start.Models;
using System.Collections.Generic;
using System.Linq;

namespace MVC_EF_Start.Controllers
{
    public class OrderController : Controller
    {
        public ApplicationDbContext dbContext;

        public OrderController(ApplicationDbContext context)
        {
            dbContext = context;
        }
        public IActionResult Index()
        {
            Store MyStore = new Store
            {
                Name = "Walmart",
                Email = "walmart@walmart.com",
                Phone = 999999999,
                Location = "Tampa"

            };

            Product MyProduct1 = new Product
            {

                Name = "StrawBerries",
                Description = "StrawBerries",
                Price = 15,
                Seller = "Kirkland",
                Store = MyStore

            };
            Product MyProduct2 = new Product
            {
                Name = "BlueBerries",
                Description = "BlueBerries",
                Price = 10,
                Seller = "Kirkland",
                Store = MyStore,

            };

            Order MyOrder = new Order
            {
                OrderDate = System.DateTime.Now,
                OrderMessage = "Mounika's Order",
                OrderTotal = 100
            };

            Orderdetail MyOrderDetail1 = new Orderdetail
            {
                Quantity = 5,
                Product = MyProduct1,
                Order = MyOrder
            };

            Orderdetail MyOrderDetail2 = new Orderdetail
            {
                Quantity = 3,
                Product = MyProduct2,
                Order = MyOrder
            };
            dbContext.Stores.Add(MyStore);
            dbContext.Products.Add(MyProduct1);
            dbContext.Products.Add(MyProduct2);
            dbContext.Orders.Add(MyOrder);
            dbContext.Orderdetails.Add(MyOrderDetail1);
            dbContext.Orderdetails.Add(MyOrderDetail2);

            dbContext.SaveChanges();
            return View();
        }

        public IActionResult ProductList(int ProdID)
        {
            var productList = (from o in dbContext.Orders join od in
                                dbContext.Orderdetails on o.OrderID equals od.Order.OrderID
                               where od.Product.ProductID == ProdID
                               select new { o.OrderID }).ToList();
            
            return View();
        }

        public IActionResult OrderMaxSale(int ProdID)
        {
            var orderList = (from od in dbContext.Orderdetails
                               where od.Quantity == dbContext.Orderdetails.Where
                               (p => p.Product.ProductID == ProdID)
                  .Max(x => x.Quantity)
                               select new { od.Order.OrderID }).ToList();

            return View();
        }

    }
}