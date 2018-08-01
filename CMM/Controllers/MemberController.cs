using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CMM.Controllers
{
    public class MemberController : Controller
    {
        // GET: Member
        [HttpGet]
        public ActionResult Registration()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Registration(string memberDetails)
        {
            return View();
        }
    }
}