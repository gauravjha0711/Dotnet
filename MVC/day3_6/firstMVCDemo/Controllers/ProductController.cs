using Microsoft.AspNetCore.Mvc;
using firstMVCDemo.Models;

namespace firstMVCDemo.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public ActionResult ListProducts()
        {
            List<Product> products = new List<Product>()
            {
                new Product{ProductCode=1,ProductName="pHp",Fees=9000},
                new Product{ProductCode=2,ProductName="AngualrJs",Fees=8000},
                new Product{ProductCode=3,ProductName="CSS 3.0",Fees=75000},
                new Product{ProductCode=4,ProductName="Bootstrap",Fees=1100},
            };
            ViewBag.Products = products;
            return View();
        }
    }
}
