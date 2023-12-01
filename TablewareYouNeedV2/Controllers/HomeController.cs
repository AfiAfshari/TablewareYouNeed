using BusinessAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TablewareYouNeedV2.ViewModels;

namespace TablewareYouNeedV2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
     
            try
            {
                var _objBAL = new TablewareYouNeedBAL();
                var lstEntity = _objBAL.GetProducts();

                var tablewareYouNeedViewModels = lstEntity.Select(item => new ProductViewModel
                {
                    ID = item.ID,
                    Quentity = item.Quentity,
                    ProductName = item.ProductName

                });

                return View(tablewareYouNeedViewModels);
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}