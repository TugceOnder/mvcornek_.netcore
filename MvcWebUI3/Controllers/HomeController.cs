using Microsoft.AspNetCore.Mvc;
using MvcWebUI3.Models;
using System.Diagnostics;

namespace MvcWebUI3.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index(int id)  //tıkladığı katogorideki id leri view e göndermiş olurum
        {
            var ctx = new NorthwndContext();

            var indexModel = new IndexModel();

            indexModel.CategoryList = ctx.Categories.ToList(); // bütün her şeyi listelemesi için ToList() kullanılır.
           indexModel.ProductList = ctx.Products.ToList();


            return View(indexModel);
        }

       
    }
}