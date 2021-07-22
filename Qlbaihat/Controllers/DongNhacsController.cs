using Qlbaihat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Qlbaihat.Controllers
{
    public class DongNhacsController : Controller
    {
        // GET: DongNhacs
        public ActionResult DongNhac()
        {
            DongNhacList strNS = new DongNhacList();
            List<QlDongNhac> obj = strNS.getDongNhac(string.Empty);

            return View(obj);
        }
    }
}