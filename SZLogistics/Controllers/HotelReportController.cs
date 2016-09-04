using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SZLogistics.Controllers
{
    public class HotelReportController : Controller
    {
        public class LoadObject
        {
            public LoadObject(List<SZLogisiticsDTO.T_Unit> vUnit, List<SZLogisiticsDTO.T_ProviderInfo> vProvider)
            {
                UnitItem = vUnit;
                ProviderItem = vProvider;
            }
            public List<SZLogisiticsDTO.T_Unit> UnitItem;
            public List<SZLogisiticsDTO.T_ProviderInfo> ProviderItem;
        }
        // GET: HotelReport
        public ActionResult HotelReport()
        {
            return View();
        }

        public ActionResult PageLoad()
        {
            
            SZLogisiticsDTO.SZ_BuyerEntities LogisticDB = new SZLogisiticsDTO.SZ_BuyerEntities();
            SZLogisiticsDTO.DataRet.ReturnValue<LoadObject> rv = new SZLogisiticsDTO.DataRet.ReturnValue<LoadObject>();
            //Get Unit Info
            var retUnit = from uvr in LogisticDB.T_Unit
                        select uvr;

            var retProvider = from rPrd in LogisticDB.T_ProviderInfo
                              select rPrd;

            //Get Provider Info
            rv.data = new LoadObject(retUnit.ToList<SZLogisiticsDTO.T_Unit>(), retProvider.ToList<SZLogisiticsDTO.T_ProviderInfo>());
            rv.RetStatus = "loading successful!";
            rv.RetValue = "loading successful!";
            JsonResult jRObject= Json(rv.data, JsonRequestBehavior.AllowGet);

            return jRObject;
        }
        /// <summary>
        /// set product report into database add by YangDu 0902
        /// </summary>
        /// <param name="strProductName"> </param>
        /// <param name="strModel"></param>
        /// <param name="strUnit"></param>
        /// <param name="strPrice"></param>
        /// <param name="strBrandName"></param>
        /// <param name="strDate"></param>
        /// <param name="strDeliveryPlace"></param>
        /// <param name="strRemark"></param>
        /// <param name="strProvider"></param>
        /// <returns></returns>
        public ActionResult HotelReportAdd(string strProductName   , 
                                           string strModel         , 
                                           int strUnit             , 
                                           decimal strPrice        , 
                                           string strBrandName     , 
                                           string strDate        , 
                                           string strDeliveryPlace , 
                                           string strRemark        , 
                                           int strProvider      )     
        {
            SZLogisiticsDTO.T_ProductOrder ProductVar = new SZLogisiticsDTO.T_ProductOrder()
            {
                F_ProductName      = strProductName  ,
                F_Model            = strModel        ,
                F_UnitID           = strUnit         ,
                F_Price            = strPrice        ,
                F_Brand            = strBrandName    ,
                F_ImportDate       = Convert.ToDateTime(strDate),         
                DeliveryPlace      = strDeliveryPlace,
                F_Remark           = strRemark       ,
                F_ProviderID       = strProvider     
            };

            SZLogisiticsDTO.SZ_BuyerEntities LogisticDB = new SZLogisiticsDTO.SZ_BuyerEntities();
            SZLogisiticsDTO.DataRet.ReturnValue<string> rv = new SZLogisiticsDTO.DataRet.ReturnValue<string>();
            
            try
            {
                LogisticDB.T_ProductOrder.Add(ProductVar);
                int iChanges=LogisticDB.SaveChanges();
                rv.data = "successful";
                rv.RetStatus = "数据录入成功！";
                rv.RetValue = "数据录入成功！";
            }
            catch (Exception ex)
            {
                rv.RetStatus = "数据录入失败！";
                rv.RetValue = ex.ToString();
            }
            
            return Json(rv, JsonRequestBehavior.AllowGet);
        }
    }
}