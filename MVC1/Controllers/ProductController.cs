using MVC1.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC1.Models;
using System.Net;
using System.Data.Entity;

namespace MVC1.Controllers
{
    public class ProductController : Controller
    {   // tipo de dato Store Context = y se crea la nueva instancia StoreconText
        // Y se conecta a la base de datos
        private StoreContext db = new StoreContext();
        
        // GET: /Product/
        public ActionResult Index()
        {
            
             return View(db.Products.ToList());
        }

        //
        // GET: /Product/Details/5
        public ActionResult DetailsProduct(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var product = db.Products.Find(id);

            if (product == null)
            {
                return new HttpNotFoundResult();
            }

            return View(product);    
            
            
        }

        //
        // GET: /Product/Create
        public ActionResult CreateProduct()
        {
            return View();
        }

        //
        // POST: /Product/Create
        [HttpPost]
        public ActionResult CreateProduct(Product product)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    db.Products.Add(product);
                    db.SaveChanges();
                    return RedirectToAction("Index");                           
                }
                return View(product);                           
                
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Product/Edit/5
        public ActionResult EditProduct(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var product = db.Products.Find(id);

            if (product == null)
            {
                return new HttpNotFoundResult();
            }

            return View(product);    
        }

        //
        // POST: /Product/Edit/5
        [HttpPost]
        public ActionResult EditProduct(Product product)
        {
            try
            {
                // TODO: Add update logic here
                // siempre hay que hacer esta validaciòn para verificar que sea valido el modelo.
                if (ModelState.IsValid)
                {
                    // Se va a modificar este objeto
                    db.Entry(product).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");                    
                }
                return View(product);
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Product/Delete/5
        public ActionResult DeleteProduct(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var product = db.Products.FirstOrDefault(x => x.ProductID == id);
            

            if (product == null)
            {
                return new HttpNotFoundResult();
            }

            return View(product);
        }

        //
        // POST: /Product/Delete/5
        [HttpPost]
        public ActionResult DeleteProduct(int id, Product product)
        {
            try
            {
                
                // TODO: Add delete logic here Puto :v
                // product = db.Products.FirstOrDefault(x => x.ProductID == id);
                product = db.Products.Find(id);
                db.Products.Remove(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
