using Microsoft.AspNetCore.Mvc;
using MvcWebUI3.Models;
using System.Diagnostics;

namespace MvcWebUI3.Controllers
{
    public class HomeController : Controller
    {
        //Controllerdaki metodlarada Action method da deriz
        public ViewResult Index(int id)  //tıkladığı katogorideki id leri view e göndermiş olurum
        {
            var ctx = new NorthwndContext(); // veri tabanına bağlanmak için kullanılır.

            var indexModel = new IndexModel();

            indexModel.CategoryList = ctx.Categories.ToList(); // bütün her şeyi listelemesi için ToList() kullanılır.


            if (id == 0)
            {
                indexModel.ProductList = ctx.Products.ToList();  // category id == 0 ise hepsini listele 
                                                                 //  indexModel.TitleOfProductList = "Tüm Ürünler";
                ViewBag.Tugce = "Tüm Ürünler";
                ViewBag.ActiveCategoryName = "Tümü";  // "Tümü" yazısı front end ile aynı olacak
            }
            else
            {
                indexModel.ProductList = ctx.Products.Where(x => x.CategoryId == id).ToList();    //  indexModel.ProductList = ctx.Products.ToList();
                var category = ctx.Categories.SingleOrDefault(x => x.CategoryId == id);

                //indexModel.TitleOfProductList = $"{category.CategoryName} Kategorisindeki Ürünler";
                ViewBag.Tugce = $"{category.CategoryName} Kategorisindeki Ürünler";
                ViewBag.ActiveCategoryName = category.CategoryName; // aktif olan katogori adı 
                
            }


            return View(indexModel);  //data yı wiew e gönderme şekli 
        }

       
        public ViewResult ProductDetail()
        {
            return View();
        }
    }
}