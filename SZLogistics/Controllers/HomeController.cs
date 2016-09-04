using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SZLogisiticsDTO.DataRet;

namespace SZLogistics.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult LoginSys(string strUserName, string strPassword)
        {

            ReturnValue<string> rv = new ReturnValue<string>();
            SZLogisiticsDTO.SZ_BuyerEntities  SzBuyerEntities= new SZLogisiticsDTO.SZ_BuyerEntities();
            var cls = (from UsObj in SzBuyerEntities.T_HUserInfo
                       where UsObj.F_UserName == strUserName 
                       select UsObj);
            rv.data = "Status:OK";
            rv.RetStatus = cls.Count<SZLogisiticsDTO.T_HUserInfo>() == 0 ? "失败" : "成功";
            rv.RetValue = cls.Count<SZLogisiticsDTO.T_HUserInfo>() == 0 ? "失败" : "成功";
            return Json(rv,JsonRequestBehavior.AllowGet);
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