using Qlbaihat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Qlbaihat.Controllers
{
    public class BaiHatsController : Controller
    {
        // GET: BaiHats
        public ActionResult BaiHat()
        {
            BaiHatList strBH = new BaiHatList();
            List<QlBaiHat_Model> obj = strBH.getBaiHat(string.Empty);
            return View(obj);
        }
    }
}