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
    public class WarehousesController : Controller
    {
        private ProductRelationDBContext db = new ProductRelationDBContext();

        // GET: Warehouses
        public ActionResult Index(int pg = 1)
        {
            const int pageSize = 15;
            if (pg < 1)
                pg = 1;

            int rescCount = db.Warehouses.Count();
            var pager = new Pager(rescCount, pg, pageSize);
            int recSkip = (pg - 1) * pageSize;
            var data = db.Warehouses.OrderBy(x => x.Number).Skip(recSkip).Take(pager.PageSize).ToList();
            this.ViewBag.Pager = pager;

            return View(data);
        }

        // GET: Warehouses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Warehouse warehouse = db.Warehouses.Find(id);
            if (warehouse == null)
            {
                return HttpNotFound();
            }
            return View(warehouse);
        }

        // GET: Warehouses/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Number,full_name_of_the_torekeeper")] Warehouse warehouse)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.addWarehouse(warehouse.Number, warehouse.full_name_of_the_torekeeper);
                    ModelState.AddModelError("", "Объект успешно добавлен!");
                }

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Дубликат адреса!");
            }

            return View(warehouse);
        }

        // GET: Warehouses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Warehouse warehouse = db.Warehouses.Find(id);
            if (warehouse == null)
            {
                return HttpNotFound();
            }
            return View(warehouse);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Number,full_name_of_the_torekeeper")] Warehouse warehouse)
        {
            if (ModelState.IsValid)
            {
                db.UpdWarehouse(warehouse.Number, warehouse.full_name_of_the_torekeeper);
                ModelState.AddModelError("", "Объект успешно отредактирован!");
            }
            return View(warehouse);
        }

        // GET: Warehouses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Warehouse warehouse = db.Warehouses.Find(id);
            if (warehouse == null)
            {
                return HttpNotFound();
            }
            return View(warehouse);
        }

        // POST: Warehouses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Warehouse warehouse = db.Warehouses.Find(id);
            try
            {
                db.delWarehouse(warehouse.Number);
                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Ошибка! Объект уже используется в другой таблице!");
            }

            return View(warehouse);
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
