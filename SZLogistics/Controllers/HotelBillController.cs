using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SZLogistics.Controllers
{
    public class HotelBillController : Controller
    {
        public class LoadObject
        {
            public int ReportID;
            public string ProductName;
            public string RetDate;
            public string HotelName;
        }
        // GET: HotelBill
        public ActionResult HotelBill()
        {
            return View();
        }

        public ActionResult PageLoad(string strConn)
        {
            SZLogisiticsDTO.SZLogisticsEFContainer LogisticDB = new SZLogisiticsDTO.SZLogisticsEFContainer();
            SZLogisiticsDTO.DataRet.ReturnValue<List<LoadObject>> rv = new SZLogisiticsDTO.DataRet.ReturnValue<List<LoadObject>>();
            var retReport = from hReport in LogisticDB.T_ProductOrder
                            join HotelInfo in LogisticDB.T_HotelInfo
                            on hReport.F_HotelID equals HotelInfo.F_ID
                            where hReport.F_Status.Contains("已发送") && HotelInfo.F_Name.Contains(strConn)
                            select new LoadObject
                            {
                                ReportID=hReport.F_ID,
                                ProductName = hReport.F_ProductName,
                                RetDate = hReport.F_ImportDate.ToString(),
                                HotelName = HotelInfo.F_Name
                            };

            //Get Provider Info
            rv.data = retReport.ToList<LoadObject>();
            rv.RetStatus = "loading successful!";
            rv.RetValue = "loading successful!";
            JsonSerializerSettings jsSettings = new JsonSerializerSettings();
            jsSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            JsonResult jRe = Json(JsonConvert.SerializeObject(rv, jsSettings), JsonRequestBehavior.AllowGet);
            return jRe;
        }


    }
}