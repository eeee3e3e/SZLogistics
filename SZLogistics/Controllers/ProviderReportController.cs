using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SZLogistics.Controllers
{
    public class ProviderReportController : Controller
    {
        public class LoadObject
        {
            //public LoadObject(string strProductName,string strDate,string strProviderName)
            //{
            //    ProductName = strProductName;
            //    RetDate = strDate;
            //    ProviderName = strProductName;
            //}
            public string ProductName;
            public string RetDate;
            public string ProviderName;
        }
        // GET: ProviderReport
        public ActionResult ProviderReport()
        {
            return View();
        }

        [HttpPost]
        public ActionResult PageLoad(string strConn)
        {

            SZLogisiticsDTO.SZLogisticsEFContainer LogisticDB = new SZLogisiticsDTO.SZLogisticsEFContainer();
            SZLogisiticsDTO.DataRet.ReturnValue<List<LoadObject>> rv = new SZLogisiticsDTO.DataRet.ReturnValue<List<LoadObject>>();
            #region 查询例子
            /*var q=      from n in db.NewsModel
              join b in db.BigClassModel on n.BigClassID equals b.BigClassID
              join s in db.SmallClassModel on n.SmallClassID equals s.SmallClassID
              orderby n.AddTime descending
              select new
              {
                  n.NewsID,
                  n.BigClassID,
                  n.SmallClassID,
                  n.Title,
                  b.BigClassName,
                  s.SmallClassName,
              };
               return q.ToList();
               q.Count()//这个就是记录总数*/
            #endregion
            var retReport = from pReport in LogisticDB.T_ProductOrder join ProviderInfo in LogisticDB.T_ProviderInfo
                            on pReport.F_ProviderID equals ProviderInfo.F_ID
                            where pReport.F_Status.Contains("已回复") && ProviderInfo.F_Name.Contains(strConn)
                            select new LoadObject
                            {
                                ProductName=pReport.F_ProductName,
                                RetDate=pReport.F_ImportDate.ToString(),
                                ProviderName=ProviderInfo.F_Name
                            };

            //Get Provider Info
            rv.data = retReport.ToList<LoadObject>();
            #region test code - 0904
            // rv.data = retUnit.ToList<SZLogisiticsDTO.T_Unit>();
            //List<string> lsEx=new List<string>();
            //lsEx.Add("1");
            //lsEx.Add("2");
            //rv.data = lsEx; 
            #endregion
            rv.RetStatus = "loading successful!";
            rv.RetValue = "loading successful!";
            JsonSerializerSettings jsSettings = new JsonSerializerSettings();
            jsSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            JsonResult jRe = Json(JsonConvert.SerializeObject(rv, jsSettings), JsonRequestBehavior.AllowGet);
            return jRe;
        }


    }
}