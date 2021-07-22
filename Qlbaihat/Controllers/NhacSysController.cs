using Qlbaihat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Qlbaihat.Controllers
{
    public class NhacSysController : Controller
    {
        // GET: NhacSys
        public ActionResult Nhacsy()
        {
            NhacSyList strNS = new NhacSyList();
            List<QlNhacSy> obj = strNS.getNhacSy(string.Empty);

            return View(obj);
        }
    }
}