using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ayubaweb.Models;

namespace ayubaweb.Controllers
{
    public class thensisController : Controller
    {
        db_a7ad46_qnEntities1 db = new db_a7ad46_qnEntities1();
        // GET: thensis
        public ActionResult Index() { 
        
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(SignIn Key)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var login = db.AdminUsers.SingleOrDefault(x => x.Username == Key.UserName && x.Passwords == Key.Passwords && x.Active==1);
                    if (login.AUId > 0 && login.Active > 0)
                    {
                        Session["Admin"] = login.Username;
                        return Redirect("~/dashboard/InviteByEmail");
                    }
                }
                else
                {
                    ViewBag.Error = "Invalid Username and Password";
                }
            }
            catch (Exception ex)
            {

                ViewBag.Error = ex.Message.ToString();
            }
            //
            return View(Key);
        }

        

    }
}