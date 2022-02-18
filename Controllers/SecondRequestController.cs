using Accounting_of_Goods_ver_2.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Accounting_of_Goods_ver_2.Controllers
{
    public class SecondRequestController : Controller
    {
        private ProductRelationDBContext db = new ProductRelationDBContext();

        public ActionResult Index(int pg = 1)
        {
            ViewBag.Retail_outlets_Addressr = new SelectList(db.Retails_outlets, "Address", "Address");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(string Retail_outlets_Addressr)
        {
            return Redirect("SecondRequest/Show?Retail_outlets_Addressr=" + Retail_outlets_Addressr);
        }

        // GET: SecondRequest
        public ActionResult Show(string Retail_outlets_Addressr, int pg = 1)
        {
            SqlParameter parameter = new SqlParameter("@address", Retail_outlets_Addressr);
            List<outputDok_second_Result> listRequest = db.Database.SqlQuery<outputDok_second_Result>("outputDok_second @address", parameter).ToList();

            const int pageSize = 15;
            if (pg < 1)
                pg = 1;

            int rescCount = listRequest.Count();
            var pager = new Pager(rescCount, pg, pageSize);
            int recSkip = (pg - 1) * pageSize;
            var data = listRequest.Skip(recSkip).Take(pager.PageSize).ToList();
            this.ViewBag.Pager = pager;

            return View(data);
        }
    }
}