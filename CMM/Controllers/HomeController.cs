using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Dao.Entities;
using Services.UserServices;

namespace CMM.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserServices _userServices;
        public HomeController(IUserServices userServices)
        {
            _userServices = userServices;
        }
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public string Login(string formData)
        {
            Session["Role"] = "Admin";
            FormsAuthentication.SetAuthCookie("admin@gmail.com", true);
            return _userServices.UserAuthentication(formData);
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
    }
}