using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ErdaldanisEDU.Models
{
    public class LoginState
    {
        public LoginState()
        {

        }
        public bool IsLoginSucces(string user,string pass)
        {
            ErdaldanisEDUdb db = new ErdaldanisEDUdb();
            YoneticiGiris resultUser = db.YoneticiGiris.Where(x => x.username.Equals(user) && x.password.Equals(pass)).FirstOrDefault();
            if(resultUser!=null)
            {
                db.Entry(resultUser).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                HttpContext.Current.Session.Add("ActiveUser",user);
                HttpContext.Current.Session.Add("UserID", resultUser.Id.ToString());
                return true;
            }
            return false;

        }
    }
    public class ControlLogin:ActionFilterAttribute,IActionFilter
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            try
            {

            
            if (!string.IsNullOrEmpty(HttpContext.Current.Session["UserID"].ToString()))
            {
                base.OnActionExecuting(filterContext);
            }
            else
            {
                HttpContext.Current.Response.Redirect("/Login/Index");
            }
            }
            catch(Exception)
            {
                HttpContext.Current.Response.Redirect("/Login/Index");
            }
        }
        

    }
}