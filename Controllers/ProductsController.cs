using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GAMECRUD.Entities;

namespace GAMECRUD.Controllers
{
    public class ProductsController : Controller
    {
        [Authorize]
        // GET: Menus
        public ActionResult Index()
        {
            List<Product> p;
            using (var r = new ProductEntities())
            {
                p = r.Products.ToList();
            }
            return View(p);
        }

        [HttpGet]
        [ActionName("Create")]
        public ActionResult Create_Get()
        {
            return View();
        }

        [HttpPost]
        [ActionName("Create")]
        public ActionResult Create_Post()
        {
            var productsmodel = new Product();
            TryUpdateModel(productsmodel);

            using (var r = new ProductEntities())
            {
                r.Products.Add(productsmodel);
                r.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Details(string code)
        {
            var productmodel = new Product();
            TryUpdateModel(productmodel);

            using (var r = new ProductEntities())
            {
                productmodel = r.Products.FirstOrDefault(x => x.ProductId == code);
            }

            return View(productmodel);
        }

        [HttpGet]
        [ActionName("Edit")]
        public ActionResult Edit_Get(string code)
        {
            var productmodel = new Product();
            TryUpdateModel(productmodel);

            using (var r = new ProductEntities())
            {
                productmodel = r.Products.Where(x => x.ProductId == code).FirstOrDefault();
            }

            return View(productmodel);
        }

        [HttpPost]
        [ActionName("Edit")]
        public ActionResult Edit_Post(string code)
        {
            var productmodel = new Product();
            TryUpdateModel(productmodel);

            using (var r = new ProductEntities())
            {
                var m = r.Products.Where(x => x.ProductId == code).FirstOrDefault();
                TryUpdateModel(m);
                r.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        [ActionName("Delete")]
        public ActionResult Delete_Get(string code)
        {
            var productmodel = new Product();
            TryUpdateModel(productmodel);

            using (var r = new ProductEntities())
            {
                productmodel = r.Products.FirstOrDefault(x => x.ProductId == code);
            }

            return View(productmodel);
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult Delete_Post(string code)
        {
            var productmodel = new Product();
            TryUpdateModel(productmodel);

            using (var r = new ProductEntities())
            {
                var m = r.Products.Remove(r.Products.FirstOrDefault(x => x.ProductId == code));
                TryUpdateModel(m);
                r.SaveChanges();
            }

            return RedirectToAction("Index");
        }

    }
}