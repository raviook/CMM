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
            CMMdbEntities db = new CMMdbEntities();
            var users = db.Users.ToList();
            return View(users);
        }
        public ActionResult MemberDetails(string memberId)
        {
            CMMdbEntities db = new CMMdbEntities();
            var member = db.Users.Where(m => m.MembershipId == memberId).FirstOrDefault();
            return View(member);
        }
        [HttpPost]
        public string Login(string formData)
        {
            
            var response= _userServices.UserAuthentication(formData);
            if (response != "null")
            {
                Session["Authorized"] = "True";
            }
            return response;
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
    }
}