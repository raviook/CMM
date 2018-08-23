using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Services.MemberServices;

namespace CMM.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IMemberServices _memberServices;
        public DashboardController(IMemberServices memberServices)
        {
            _memberServices = memberServices;
        }
        // GET: Dashboard
        public ActionResult Index()
        {
            
            if (Session["Authorized"].ToString() == "True")
            {
                return View();
            }
            else
            {
               return  RedirectToAction("Index", "Home");
            }
            
        }
        public ActionResult CreateMember()
        {
            return View();
        }

        [HttpPost]
        public string CreateMember(string memberDetails)
        {
           var memberId= _memberServices.CreateMember(memberDetails);
            return memberId;
        }
        [HttpPost]
        public string ProfilePicUploader(HttpPostedFileBase uploadedFile,string memberId)
        {
            string filePath = string.Empty;
            if (uploadedFile != null)
            {
                string Filename = uploadedFile.FileName;
                string path = Server.MapPath("~/ProfilePic/");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                filePath = path + Path.GetFileName(uploadedFile.FileName);
                string extension = Path.GetExtension(uploadedFile.FileName);
                uploadedFile.SaveAs(filePath);
                var response=_memberServices.UpdateProfilePic(Filename, memberId);
                return response;


            }
            return "null";
        }
        [HttpPost]
        public string MemberDocumentUploader(HttpPostedFileBase uploadedFile, string memberId)
        {
            string filePath = string.Empty;
            if (uploadedFile != null)
            {
                string Filename = uploadedFile.FileName;
                string path = Server.MapPath("~/MemberDocuments/");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                filePath = path + Path.GetFileName(uploadedFile.FileName);
                string extension = Path.GetExtension(uploadedFile.FileName);
                uploadedFile.SaveAs(filePath);
                var response = _memberServices.UploadFile(Filename, memberId);
                return response;


            }
            return "null";
        }
    }
}