using ErdaldanisEDU.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ErdaldanisEDU.Controllers
{
    
    public class LoginController : Controller
    {
        
        // GET: Login
        public ActionResult Index()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Index(string username,string password)
        {
            if(new LoginState().IsLoginSucces(username,password))
            {
                return RedirectToAction("Anasayfa", "Yonetici");
            }

           return RedirectToAction("Index", "Login");

        }
        public ActionResult LogOut()
        {
            Session.Clear();
            return RedirectToAction("Index", "Login");
        }

    }


}