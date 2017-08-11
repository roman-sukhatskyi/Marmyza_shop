using MarmyzaShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MarmyzaShop.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            //using (var context = new ApplicationDbContext())
            //{
            //    context.Products.Add(new Models.Product.Product()
            //    {
            //        Name = "Продукт",
            //        Code = 1,
            //        Price = 100,
            //        Description = "test"
            //    });
            //    context.SaveChanges();
            //}

            ViewBag.Title = "Marmyza shop";

            return View();
        }
    }
}
