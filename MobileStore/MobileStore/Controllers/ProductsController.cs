using MobileStore.Contexts;
using MobileStore.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MobileStore.Controllers
{
    public class ProductsController : Controller
    {
        private EFContext context = new EFContext();
        // GET: Products/Index
        public ActionResult Index()
        {
            return View(context.Product.OrderBy(p => p.Brand));
        }
        // GET: Products/Create
        public ActionResult Create()
        {
            return View();
        }
        // Post: Product/Crate
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product)
        {
            context.Product.Add(product);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        // GEt: Product/Edit
        public ActionResult Edit(long? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = context.Product.Find(id);
            if(product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }
        // Post: Product/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                context.Entry(product).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product);
        }

        // GET: Products/Detais
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = context.Product.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Product/Delete
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = context.Product.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // Post: Product/Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(long id)
        {
            Product product = context.Product.Find(id);
            context.Product.Remove(product);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}