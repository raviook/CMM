using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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

            return _userServices.UserAuthentication(formData);
        }
    }
}