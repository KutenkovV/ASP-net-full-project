using Accounting_of_Goods_ver_2.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Accounting_of_Goods_ver_2.Controllers
{
    public class FirstRequestController : Controller
    {
        private ProductRelationDBContext db = new ProductRelationDBContext();

        public ActionResult Index(int pg = 1)
        {
            List<outputDok_first_Result> listRequest = db.Database.SqlQuery<outputDok_first_Result>("outputDok_first").ToList();

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
