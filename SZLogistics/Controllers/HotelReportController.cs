using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SZLogistics.Controllers
{
    public class HotelReportController : Controller
    {
        // GET: HotelReport
        public ActionResult HotelReport()
        {
            return View();
        }

        public ActionResult HotelReportAdd()
        {
            return View();
        }
    }
}