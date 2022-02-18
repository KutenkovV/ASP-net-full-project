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
    public class Entrance_2Controller : Controller
    {
        private ProductRelationDBContext db = new ProductRelationDBContext();

        // GET: Entrance_2
        public ActionResult Index(int pg = 1)
        {
            List<Entrance_2> entrance_2 = db.Entrances_2.ToList();

            const int pageSize = 15;
            if (pg < 1)
                pg = 1;

            int rescCount = entrance_2.Count();
            var pager = new Pager(rescCount, pg, pageSize);
            int recSkip = (pg - 1) * pageSize;
            var data = entrance_2.Skip(recSkip).Take(pager.PageSize).ToList();
            this.ViewBag.Pager = pager;

            return View(data);
        }

        // GET: Entrance_2/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Entrance_2 entrance_2 = db.Entrances_2.Find(id);
            if (entrance_2 == null)
            {
                return HttpNotFound();
            }
            return View(entrance_2);
        }

        // GET: Entrance_2/Create
        public ActionResult Create()
        {
            ViewBag.Products_Registration_number = new SelectList(db.Products, "Registration_number", "Registration_number");
            ViewBag.Retail_outlets_Addressr = new SelectList(db.Retails_outlets, "Address", "Address");
            return View();
        }

        // POST: Entrance_2/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Products_Registration_number,Retail_outlets_Addressr,Product_quantity")] Entrance_2 entrance_2)
        {
            if (ModelState.IsValid)
            {
                db.addEntrance2(entrance_2.Products_Registration_number, entrance_2.Retail_outlets_Addressr, entrance_2.Product_quantity);
                //db.SaveChanges();
                ModelState.AddModelError("", "Объект успешно добавлен!");
            }

            ViewBag.Products_Registration_number = new SelectList(db.Products, "Registration_number", "name_of_the_company", entrance_2.Products_Registration_number);
            ViewBag.Retail_outlets_Addressr = new SelectList(db.Retails_outlets, "Address", "name", entrance_2.Retail_outlets_Addressr);
            return View(entrance_2);
        }

        // GET: Entrance_2/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Entrance_2 entrance_2 = db.Entrances_2.Find(id);
            if (entrance_2 == null)
            {
                return HttpNotFound();
            }
            ViewBag.Products_Registration_number = new SelectList(db.Products, "Registration_number", "name_of_the_company", entrance_2.Products_Registration_number);
            ViewBag.Retail_outlets_Addressr = new SelectList(db.Retails_outlets, "Address", "name", entrance_2.Retail_outlets_Addressr);
            return View(entrance_2);
        }

        // POST: Entrance_2/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Products_Registration_number,Retail_outlets_Addressr,Product_quantity")] Entrance_2 entrance_2)
        {
            if (ModelState.IsValid)
            {
                db.UpdEntrance2(entrance_2.ID, entrance_2.Product_quantity);
                //db.SaveChanges();
                ModelState.AddModelError("", "Объект успешно отредактирован!");
            }
            ViewBag.Products_Registration_number = new SelectList(db.Products, "Registration_number", "name_of_the_company", entrance_2.Products_Registration_number);
            ViewBag.Retail_outlets_Addressr = new SelectList(db.Retails_outlets, "Address", "name", entrance_2.Retail_outlets_Addressr);
            return View(entrance_2);
        }

        // GET: Entrance_2/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Entrance_2 entrance_2 = db.Entrances_2.Find(id);
            if (entrance_2 == null)
            {
                return HttpNotFound();
            }
            return View(entrance_2);
        }

        // POST: Entrance_2/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Entrance_2 entrance_2 = db.Entrances_2.Find(id);
            try
            {
                db.delEntrance2(entrance_2.ID);
                //db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Ошибка! Объект уже используется в другой таблице!");
            }

            return View(entrance_2);
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
