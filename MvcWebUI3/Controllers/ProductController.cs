using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvcWebUI3.Models;

namespace MvcWebUI3.Controllers
{
    public class ProductController : Controller
    {
        [HttpGet]
        public ViewResult Details(int id )
        {
            var ctx = new NorthwndContext();
            var product = ctx.Products.Include("Category").Include("Supplier")
                .SingleOrDefault(x => x.ProductId == id);
            return View(product);
        }

        [HttpGet]
        public ViewResult New()
        
        {
            var ctx = new NorthwndContext();
            var model = new ProductNewModel();


            model.CategoryList = ctx.Categories.ToList();
            model.SupplierList = ctx.Suppliers.ToList();

            return View(model);
        }
        [HttpPost]
        public ViewResult New(ProductInsertModel data )
        
        {
            //data objesindeki ürün listesini product tablosuna insert edeceğiz 
            //ürünü veri tabanındaki tabloya eklemiş olacağız
            var prd = new Product();
            prd.SupplierId = data.SId;
            prd.UnitPrice = data.Uprice;
            prd.CategoryId = data.CId;
            prd.Discontinued = data.Discontinued;
            prd.ProductName = data.PName;
            prd.UnitsInStock = data.UStock;

            var ctx = new NorthwndContext();
            ctx.Products.Add(prd);
            ctx.SaveChanges();

            var model = new ProductNewModel();


            model.CategoryList = ctx.Categories.ToList();
            model.SupplierList = ctx.Suppliers.ToList();
            model.OperationMessage = "Ürün Adet Başarılı";
            return View(model);
        }

        [HttpGet]
        public ViewResult Edit(int id)
        {
          var ctx = new NorthwndContext();
          var model = new ProductEditModel();
            model.ProductToUpdate=ctx.Products.SingleOrDefault(x => x.ProductId == id);
            model.CategoryList = ctx.Categories.ToList();
            model.SupplierList = ctx.Suppliers.ToList();
           
            return View(model);
        }


        [HttpPost]
        public ViewResult Edit(ProductUpdateModel data )
        {
            var ctx = new NorthwndContext();// veritabanını çağırıyoruz
           
          var prd=  ctx.Products.SingleOrDefault(x => x.ProductId == data.ProductId); // önce veritabanından id yi çekeceğiz

            //veritabanından çekilen ürün formdan gelen data ile maplenir ve böylece olası değişikler veritabanından getirilen ürüne yansıtılmış olur
            prd.SupplierId = data.SId;
            prd.ProductName = data.PName;
            prd.Discontinued = data.Discontinued;
            prd.UnitPrice = data.Uprice;
            prd.CategoryId = data.CId;
            prd.UnitsInStock = data.UStock;

            ctx.Products.Update(prd);
            ctx.SaveChanges();

            var model = new ProductEditModel();

            model.ProductToUpdate = prd;
            model.CategoryList = ctx.Categories.ToList();
            model.SupplierList = ctx.Suppliers.ToList();



            return View(model);
        }


        [HttpGet]
        public ViewResult Delete(int id)
        {
            var ctx = new NorthwndContext();
 

           var prd = 
                ctx.Products.Include("Category")
                .Include("Supplier").SingleOrDefault(x => x.ProductId == id);

            return View(prd);

        }

        public ActionResult DeleteProduct(int id)
        {
            var ctx = new NorthwndContext();

            var prd =
                ctx.Products
                   .SingleOrDefault(x => x.ProductId == id);

            ctx.Products.Remove(prd);
            ctx.SaveChanges();

            return RedirectToAction("Index", "Home");
        }




    }
    


}
