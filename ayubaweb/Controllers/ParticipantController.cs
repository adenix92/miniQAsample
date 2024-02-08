using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ayubaweb.Models;
using System.Data.SqlClient;
using System.Configuration;

namespace ayubaweb.Controllers
{
    public class ParticipantController : Controller
    {

        db_a7ad46_qnEntities1 db = new db_a7ad46_qnEntities1();
        // GET: Participant
        public ActionResult Index()
        {
            
        //Auth check here, if the user exist or not     
        
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(Userprofile_class users)
        {


            try
            {
                UserProfile userp = new UserProfile();
                userp.FullName = users.FullName;
                userp.Email = Request.Form["Email"]; //"";
                userp.Country = users.Country;
                userp.AreaSpecialization = users.AreaSpecialization; //"dosomething";
                userp.CurrentAddressOrganization = users.CurrentAddressOrganization; //"dosomethig";
                userp.JobTitle = users.JobTitle; //"YesJob";
                userp.Active = 1;
                userp.DateRegister = DateTime.Now.ToString("dd-MM-yyyy");//"18-11-2022";
                userp.Question1 = Request.Form["Question1"]; //"What is your name";
                userp.Answer1 = users.Answer1;
                userp.Question2 = Request.Form["Question2"]; //"how do You survicve";
                userp.Answer2 = users.Answer2; //"God grace";
                userp.WorkingExperience = Convert.ToInt16(Request.Form["Exp"]);
                db.UserProfiles.Add(userp);
                db.SaveChanges();
                if ((int)userp.UserId > 0)
                {
                    Session["UserId"] = userp.UserId;
                    return RedirectToAction("AreaOrganization");
                }
                else
                {
                    ViewBag.Error = "0 Failed";
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine( ex.Message.ToString());
            }
            
            return View(users);
        }

        
        [Route("Participant/getEmail/{ba?}")]
        public ActionResult getEmail(string ba) {
            //YmF5ZXN0ZGF2aWRAZ21haWwuY29t
            //bayestdavid@gmail.com
            //return ayubaweb.Controllers.dashboardController.Stringbyte__Convertion("bayestdavid@gmail.com");
            //var Id = ayubaweb.Controllers.dashboardController.bytesString_Convertion(ba);
            var Email = ayubaweb.Controllers.dashboardController.bytesString_Convertion(ba);
            //YWRlbmlyYW5AZ21haWwuY29t
            var confirmation = db.EmailConfirmations.SingleOrDefault(x => x.Email ==Email && x.Active == 0);
            //var ema = confirmation.Email;
            try
            {
                var d = string.IsNullOrEmpty(Convert.ToString(confirmation.EmailId)) ? 0 : confirmation.EmailId;
                if (d > 0)
                {

                    confirmation.Active = 1;
                    db.SaveChanges();
                    Session["EmailId"] = confirmation.EmailId;
                    Session["Email"] = confirmation.Email;

                    return RedirectToAction("Index");
                }
                else
                {
                    return RedirectToAction("Error");
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message.ToString())
                    ;
            }
            return RedirectToAction("Error");
        }


        public ActionResult Error()
        {
            return View();
        }

        public ActionResult AreaOrganization()
        {
            if ((int)Session["EmailId"] < 0)
            {
                return RedirectToAction("Error");
            }
            
            string[] size = { "Small", "Medium", "Large","Not sure" };
            string[] employees = { "Less than 20", "20 to 100", "101 to 200", "Less than 200" };
            string[] natures = { "National", "Multi-national", "Not sure", "Others" };


            List<SelectListItem> option = new List<SelectListItem>();

            foreach(var a in size)
            {
                option.Add(new SelectListItem { Text = a, Value = a });
            }
            ViewData["sizeoption"] = option;
           
            List<SelectListItem> op_employee = new List<SelectListItem>();
            foreach (var b in employees)
            {
                op_employee.Add(new SelectListItem { Text = b, Value = b });
            }
            ViewData["employee"] = op_employee;
            //
            List<SelectListItem> op_nation = new List<SelectListItem>();
            foreach(var c in natures)
            {
                op_nation.Add(new SelectListItem { Text = c, Value = c });
            }
            ViewData["nature"] = op_nation;

            //

            List<SelectListItem> YesNo = new List<SelectListItem>() {
                   
                        new SelectListItem { Text="Yes",Value="Yes" },
                        new SelectListItem {Text="No",Value="No" }
                        };
            ViewData["YesNo"] = YesNo;


            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AreaOrganization(SampleOrganization_Class1 sample)
        {
            //
            string[] size = { "Small", "Medium", "Large", "Not sure" };
            string[] employees = { "Less than 20", "20 to 100", "101 to 200", "Less than 200" };
            string[] natures = { "National", "Multi-national", "Not sure", "Others" };


            List<SelectListItem> option = new List<SelectListItem>();

            foreach (var a in size)
            {
                option.Add(new SelectListItem { Text = a, Value = a });
            }
            ViewData["sizeoption"] = option;

            List<SelectListItem> op_employee = new List<SelectListItem>();
            foreach (var b in employees)
            {
                op_employee.Add(new SelectListItem { Text = b, Value = b });
            }
            ViewData["employee"] = op_employee;
            //
            List<SelectListItem> op_nation = new List<SelectListItem>();
            foreach (var c in natures)
            {
                op_nation.Add(new SelectListItem { Text = c, Value = c });
            }
            ViewData["nature"] = op_nation;

            //

            List<SelectListItem> YesNo = new List<SelectListItem>() {

                        new SelectListItem { Text="Yes",Value="Yes" },
                        new SelectListItem {Text="No",Value="No" }
                        };
            ViewData["YesNo"] = YesNo;

            try
            {
                if (ModelState.IsValid)
                {
                    SampleOrganization samp = new SampleOrganization();
                    samp.UserId = Convert.ToInt16(Session["UserId"]);
                    samp.OrganizationName = sample.OrganizationName;
                    samp.Q1 = Request.Form["Q1"];
                    samp.A1 = sample.A1;
                    samp.Q2 = Request.Form["Q2"];
                    samp.A2 = sample.A2;
                    samp.Q3 = Request.Form["Q3"];
                    samp.A4 = sample.A4;
                    samp.Q5 = Request.Form["Q5"];
                    samp.A5 = sample.A5;
                     samp.Q6 = Request.Form["Q6"];
                    samp.A6 = sample.A6;
                    samp.Q7 = Request.Form["Q7"];
                    samp.A7 = sample.A7;
                    samp.DateRegister = DateTime.Now.ToString("dd-MM-yyyy");
                    samp.Active = 1;
                    db.SampleOrganizations.Add(samp);
                    db.SaveChanges();
                    if ((int)samp.SampleId > 0)
                    {
                        //redirect to next
                        return RedirectToAction("Questionnaire");
                    }
                    else
                    {
                        ViewBag.Error = "0 ,Failed";
                    }
                }
            }
            catch (Exception ex)
            {
           
                Console.WriteLine(ex.Message.ToString());
            }

            return View(sample);
            //

        }

        public ActionResult success()
        {
            if ((int)Session["EmailId"] < 0)
            {
                Session.Remove("EmailId");
                Session.Remove("UserId");
            }
            return View();
        }

        public ActionResult Questionnaire()
        {
            if ((int)Session["EmailId"] < 0)
            {
                return RedirectToAction("Error");
            }
            List<Legend> legendList= db.Legends.ToList();
            ViewBag.legendList = new SelectList(legendList, "Symbol", "Descriptions");

            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Questionnaire(QuestionAndAnswer Q)
        {

           

            List<Legend> legendList = db.Legends.ToList();
            ViewBag.legendList = new SelectList(legendList, "Symbol", "Descriptions");

            return View();
        }
    }
}
