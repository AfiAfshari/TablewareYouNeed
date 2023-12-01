using BAL;
using EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using TablewareYouNeed.ViewModel;



namespace TablewareYouNeed.Controllers
{
    public class TablewareYouNeedController : Controller
    {
        // GET: TablewareYouNeed
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetTableWareYouNeed()
        {
            try
            {
                var _objBAL = new TablewareYouNeedBAL();
                var lstEntity = new List<TablewareYouNeedEntity>();
                lstEntity = _objBAL.GetProduct();

                if (lstEntity == null || lstEntity.Count <= 0) return Json(Enumerable.Empty<TablewareYouNeedViewModel>(), JsonRequestBehavior.AllowGet);
                var TablewareYouNeedViewModels = lstEntity.Select(item => new TablewareYouNeedViewModel
                {
                    ID = item.ID,
                    Quentity = item.Quentity,
                    ProductName = item.ProductName

                });

                return Json(TablewareYouNeedViewModels, JsonRequestBehavior.AllowGet);
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }
    }
}