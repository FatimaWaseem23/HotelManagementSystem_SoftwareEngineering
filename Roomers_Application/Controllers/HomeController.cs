using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Roomers_Application.CrossCutting;
using Roomers_Application.DataAccess;
using static Roomers_Application.Models.Common;

namespace Roomers_Application.Controllers
{
    public class HomeController : Controller
    {
        private readonly ServiceAccess _service = new ServiceAccess();

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (Session["LoginID"] == null)
            {
                Response.Redirect("../Login/");
            }            
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CreateUsers()
        {
            var ds = _service.Get_AllUser();
            return View(ds);
        }

        public ActionResult _CreateUsers(string userLoginID, string userEmailID, string userPassword, string userFullName, string userType)
        {
            var _user = new VMS_Users() { LoginID = userLoginID, Email = userEmailID, Password = userPassword, UserFullName = userFullName, UserType = userType };

            var ds = _service.Insert_NewUser(_user, Session["UserID"].ToString());
            var userStatus = ds.Tables[0].Rows[0][0].ToString();
            return Json(userStatus, JsonRequestBehavior.AllowGet);
         
        }

        public ActionResult _UpdateUsers(int userID, string userEmailID, string userPassword, string userFullName, string userType)
        {
            var _user = new VMS_Users() { UserID = userID, Email = userEmailID, Password = userPassword, UserFullName = userFullName, UserType = userType };

            var ds = _service.Update_ExistingUser(_user, Session["UserID"].ToString());
            var userStatus = ds.Tables[0].Rows[0][0].ToString();
            return Json(userStatus, JsonRequestBehavior.AllowGet);

        }

      
    }
}