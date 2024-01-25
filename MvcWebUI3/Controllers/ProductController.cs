using Microsoft.AspNetCore.Mvc;
using MvcWebUI3.Models;

namespace MvcWebUI3.Controllers
{
    public class ProductController : Controller
    {
        public ViewResult Details(int id )
        {
            var ctx = new NorthwndContext();
            var product = ctx.Products.SingleOrDefault(x => x.ProductId == id);
            return View();
        }
    }
}
