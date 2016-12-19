using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SeleniumTestApp.Controllers
{
    public class TestScenarioController : Controller
    {
        // GET: TestScenario
        public ActionResult Index()
        {

            if (TempData.Keys.Contains("LogoutMessage"))
            {
                ViewBag.Message = TempData["LogoutMessage"];
                TempData.Remove("LougoutMessage");
            }

            return View();
        }

        [HttpPost, ActionName("Index")]
        public ActionResult IndexPost()
        {
            return RedirectToAction("Step1");
        }

        public ActionResult Step1()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Step1(string txtUsername, string txtPassword, string txtCode)
        {
            if (txtUsername.Trim().ToLower() == "admin" &&
               txtPassword.Trim().ToLower() == "password" &&
               txtCode.Trim().ToLower() == "12345")
            {
                return RedirectToAction("Step2");
            }
            else
            {
                ViewBag.Error = "Login failed.";
                return View();
            }
        }

        public ActionResult Step2()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Step2(string txtPassword, string ActionType)
        {
            #region validation checks
            if (txtPassword.Trim().ToLower() != "password")
            {
                ViewBag.Error = "Invalid Password.";
                return View();
            }
            if (string.IsNullOrEmpty(ActionType))
            {
                ViewBag.Error = "Invalid Action Type Selected.";
                return View();
            }
            #endregion

            if (ActionType == "1")
            {
                return RedirectToAction("LogOut");
            }
            else
            {
                return RedirectToAction("Step1");
            }   
        }

        public ActionResult LogOut()
        {
            return View();
        }

        [HttpPost, ActionName("LogOut")]
        public ActionResult LogOutPost()
        {
            TempData["LogoutMessage"] = "LogOut Successfull.";
            return RedirectToAction("Index");
        }
    }
}