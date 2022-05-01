using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Roomers_Application.DataAccess;

namespace Roomers_Application.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        private readonly ServiceAccess _service = new ServiceAccess();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult LogOut()
        {
            Session.Clear();
            return RedirectToAction("Index");
        }

        public ActionResult _AuthenticateUser(string loginID, string password)
        {

           var dt = _service.AuthenticateUserCredentials(loginID, password);

           if (dt.Rows.Count > 0)
            { 
                var userID = dt.Rows[0]["UserID"].ToString();
                Session["LoginID"] = loginID;
                Session["UserID"] = userID;
                Session["UserFullName"] = dt.Rows[0]["UserFullName"].ToString();
                Session["UserType"] = dt.Rows[0]["UserType"].ToString();
                Session["UserEmail"] = dt.Rows[0]["Email"].ToString();

                return Json(new { redirectToUrl = Url.Action("Index", "Home") }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("loginfailed", JsonRequestBehavior.AllowGet);
            }            
        }
    }
}