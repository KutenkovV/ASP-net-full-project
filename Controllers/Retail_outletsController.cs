using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Accounting_of_Goods_ver_2.Models;

namespace Accounting_of_Goods_ver_2.Controllers
{
    public class Retail_outletsController : Controller
    {
        private ProductRelationDBContext db = new ProductRelationDBContext();

        // GET: Retail_outlets
        public ActionResult Index(int pg = 1)
        {
            List<Retail_outlets> retail_outlets = db.Retails_outlets.ToList();

            const int pageSize = 15;
            if (pg < 1)
                pg = 1;

            int rescCount = retail_outlets.Count();
            var pager = new Pager(rescCount, pg, pageSize);
            int recSkip = (pg - 1) * pageSize;
            var data = retail_outlets.Skip(recSkip).Take(pager.PageSize).ToList();
            this.ViewBag.Pager = pager;

            return View(data);
        }

        // GET: Retail_outlets/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Retail_outlets retail_outlets = db.Retails_outlets.Find(id);
            if (retail_outlets == null)
            {
                return HttpNotFound();
            }
            return View(retail_outlets);
        }

        // GET: Retail_outlets/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Address,name")] Retail_outlets retail_outlets)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.addRetail(retail_outlets.Address, retail_outlets.name);
                    ModelState.AddModelError("", "Объект успешно добавлен!");
                }

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Дубликат адреса!");
            }

            return View(retail_outlets);
        }

        // GET: Retail_outlets/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Retail_outlets retail_outlets = db.Retails_outlets.Find(id);
            if (retail_outlets == null)
            {
                return HttpNotFound();
            }
            return View(retail_outlets);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Address,name")] Retail_outlets retail_outlets)
        {
            if (ModelState.IsValid)
            {
                db.UpdRetail(retail_outlets.Address, retail_outlets.name);
                ModelState.AddModelError("", "Объект успешно отредактирован!");
            }
            return View(retail_outlets);
        }

        // GET: Retail_outlets/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Retail_outlets retail_outlets = db.Retails_outlets.Find(id);
            if (retail_outlets == null)
            {
                return HttpNotFound();
            }
            return View(retail_outlets);
        }

        // POST: Retail_outlets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Retail_outlets retail_outlets = db.Retails_outlets.Find(id);
            try
            {
                db.delRetail(retail_outlets.Address);
                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Ошибка! Объект уже используется в другой таблице!");
            }

            return View(retail_outlets);
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
