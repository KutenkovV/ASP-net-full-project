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
    public class EntrancesController : Controller
    {
        private ProductRelationDBContext db = new ProductRelationDBContext();

        // GET: Entrances
        public ActionResult Index(int pg = 1)
        {
            List<Entrance> entrances = db.Entrances.ToList();

            const int pageSize = 15;
            if (pg < 1)
                pg = 1;

            int rescCount = entrances.Count();
            var pager = new Pager(rescCount, pg, pageSize);
            int recSkip = (pg - 1) * pageSize;
            var data = entrances.Skip(recSkip).Take(pager.PageSize).ToList();
            this.ViewBag.Pager = pager;

            return View(data);
        }

        // GET: Entrances/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Entrance entrance = db.Entrances.Find(id);
            if (entrance == null)
            {
                return HttpNotFound();
            }
            return View(entrance);
        }

        // GET: Entrances/Create
        public ActionResult Create()
        {
            ViewBag.Products_Registration_number = new SelectList(db.Products, "Registration_number", "Registration_number");
            ViewBag.Warehouse_Number = new SelectList(db.Warehouses, "Number", "Number");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Products_Registration_number,Warehouse_Number,Product_quantity,delivery_date")] Entrance entrance)
        {
            if (ModelState.IsValid)
            {
                db.addEntrance(entrance.Products_Registration_number, entrance.Warehouse_Number, entrance.Product_quantity, entrance.delivery_date);
                ModelState.AddModelError("", "Объект успешно добавлен!");
            }

            ViewBag.Products_Registration_number = new SelectList(db.Products, "Registration_number", "name_of_the_company", entrance.Products_Registration_number);
            ViewBag.Warehouse_Number = new SelectList(db.Warehouses, "Number", "full_name_of_the_torekeeper", entrance.Warehouse_Number);
            return View(entrance);
        }

        // GET: Entrances/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Entrance entrance = db.Entrances.Find(id);
            if (entrance == null)
            {
                return HttpNotFound();
            }

            return View(entrance);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Products_Registration_number,Warehouse_Number,Product_quantity,delivery_date")] Entrance entrance)
        {
            if (ModelState.IsValid)
            {
                db.UpdEntrance(entrance.ID, entrance.Product_quantity, entrance.delivery_date);
                ModelState.AddModelError("", "Объект успешно отредактирован!");
            }

            return View(entrance);
        }

        // GET: Entrances/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Entrance entrance = db.Entrances.Find(id);
            if (entrance == null)
            {
                return HttpNotFound();
            }
            return View(entrance);
        }

        // POST: Entrances/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Entrance entrance = db.Entrances.Find(id);
            try
            {
                db.delEntrance(entrance.ID);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Ошибка! Объект уже используется в другой таблице!");
            }

            return View(entrance);
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
