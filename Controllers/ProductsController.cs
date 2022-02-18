using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Accounting_of_Goods_ver_2.Models;

namespace Accounting_of_Goods_ver_2.Controllers
{
    public class ProductsController : Controller
    {
        private ProductRelationDBContext db = new ProductRelationDBContext();

        public ActionResult Index(int pg = 1)
        {
            List<Product> prodList = db.Products.ToList();

            const int pageSize = 15;
            if (pg < 1)
                pg = 1;

            int rescCount = prodList.Count();
            var pager = new Pager(rescCount, pg, pageSize);
            int recSkip = (pg - 1) * pageSize;
            var data = prodList.Skip(recSkip).Take(pager.PageSize).ToList();
            this.ViewBag.Pager = pager;

            return View(data);
        }

        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Registration_number,name_of_the_company,Units_of_measurement,Cost_of_change")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.addProducts(product.name_of_the_company, product.Units_of_measurement, product.Cost_of_change);
                ModelState.AddModelError("", "Объект успешно добавлен!");
            }

            return View(product);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Registration_number,name_of_the_company,Units_of_measurement,Cost_of_change")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.UpdProducts(product.Registration_number, product.name_of_the_company, product.Units_of_measurement, product.Cost_of_change);
                ModelState.AddModelError("", "Объект успешно отредактирован!");
            }
            return View(product);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            try
            {
                db.delProducts(product.Registration_number);
                return RedirectToAction("Index");

            } catch(Exception ex) 
            {
                ModelState.AddModelError("", "Ошибка! Объект уже используется в другой таблице!");
            }

            return View(product);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
