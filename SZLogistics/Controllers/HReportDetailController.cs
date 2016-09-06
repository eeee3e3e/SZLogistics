using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SZLogistics.Controllers
{
    public class HReportDetailController : Controller
    {
        // GET: HReportDetail
        public ActionResult HReportDetail()
        {
            return View();
        }

        public class LoadObject
        {
            public string HotelName;
            public string ProductName;
            public string Model;
            public string Unit;
            public string Price;
            public string Brand;
            public string PublishDate;
            public string Address;
            public string Remark;
        }

        public ActionResult PageLoad(int ReportID)
        {
            SZLogisiticsDTO.SZLogisticsEFContainer LogisticDB = new SZLogisiticsDTO.SZLogisticsEFContainer();
            SZLogisiticsDTO.DataRet.ReturnValue<List<LoadObject>> rv = new SZLogisiticsDTO.DataRet.ReturnValue<List<LoadObject>>();
            var retReport = from hReport in LogisticDB.T_ProductOrder
                            join HotelInfo in LogisticDB.T_HotelInfo
                            on hReport.F_HotelID equals HotelInfo.F_ID
                            join UnitInfo in LogisticDB.T_Unit
                            on hReport.F_UnitID equals UnitInfo.F_ID
                            where hReport.F_ID== ReportID
                            select new LoadObject
                            {
                                HotelName = HotelInfo.F_Name,
                                ProductName = hReport.F_ProductName,
                                Model = hReport.F_Model,
                                Unit= UnitInfo.F_Name,
                                Price=hReport.F_Price.ToString(),
                                Brand=hReport.F_Brand,
                                PublishDate=hReport.F_ImportDate.ToString(),
                                Address=hReport.DeliveryPlace,
                                Remark=hReport.F_Remark
                            };

            //Get Provider Info
            rv.data = retReport.ToList<LoadObject>();
            rv.RetStatus = "1";
            rv.RetValue = "loading successful!";
            JsonSerializerSettings jsSettings = new JsonSerializerSettings();
            jsSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            JsonResult jRe = Json(JsonConvert.SerializeObject(rv, jsSettings), JsonRequestBehavior.AllowGet);
            return jRe;
        }

        public ActionResult ReportUpdates(int strReportID,string strRemark)
        {
            SZLogisiticsDTO.SZLogisticsEFContainer LogisticDB = new SZLogisiticsDTO.SZLogisticsEFContainer();
            SZLogisiticsDTO.DataRet.ReturnValue<string> rv = new SZLogisiticsDTO.DataRet.ReturnValue<string>();
            var retReport = (from hReport in LogisticDB.T_ProductOrder
                            where hReport.F_ID == strReportID
                            select hReport).FirstOrDefault();
            retReport.F_Remark = strRemark;
            retReport.F_Status = "已回复";
            rv.data = LogisticDB.SaveChanges().ToString();
            return Json(rv, JsonRequestBehavior.AllowGet);
        }
    }
}