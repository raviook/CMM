using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Services.DemoServices;
namespace CMM.Controllers
{
    public class DemoController : Controller
    {
        private readonly IDemoServices _services;
        public DemoController(IDemoServices services)
        {
            _services = services;
        }
        // GET: Demo
        public ActionResult Index()
        {
            return View();
        }
        public string demoList()
        {
            var result = _services.GetDemoList();
            return result;
        }
    }
}