using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ayubaweb.Models;
using System.Net.Mail;
using System.Text;

namespace ayubaweb.Controllers
{
    public class dashboardController : Controller
    {
        //instance connection of database go here conn
        // GET: dashboard
                
        public ActionResult Index()
        {
            if (Session["Admin"] != null)
            {
                return View();
            }
            else
            {
                return Redirect("~/thensis/Index");
            }
        }

        public ActionResult InviteByEmail() {
            if (Session["Admin"] != null)
            {
                List<EmailRecords> EmailList = new List<EmailRecords>();

                EmailList = db.EmailConfirmations.Select(a => new EmailRecords { Email = a.Email, EmailId = a.EmailId, Active = a.Active, DateRegister = a.DateRegister }).ToList();
                ViewBag.EmailList = EmailList;
                return View();
            }
            else
            {
                return Redirect("~/thensis/Index");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult InviteByEmail(InviteEmails Items)
        {
            EmailConfirmation em = new EmailConfirmation();
           
            try
            {
                List<EmailRecords> EmailList = new List<EmailRecords>();
                EmailList = db.EmailConfirmations.Select(a => new EmailRecords { Email = a.Email, EmailId = a.EmailId, Active = a.Active, DateRegister = a.DateRegister }).ToList();
                ViewBag.EmailList = EmailList;

                if (ModelState.IsValid)
            {
                em.Email = Items.Email;
                em.Active = 0;
                em.DateRegister = DateTime.Now.ToString();
                    db.EmailConfirmations.Add(em);
                db.SaveChanges();
                if ((int)em.EmailId > 0) {
                    //sending email
                    var from = "";
                    MailMessage mail = new MailMessage();
                    mail.To.Add(Items.Email);
                     mail.From = new MailAddress(from);
                     mail.Subject = "Challenges of IoT Adoption";
                        var emailconv = Stringbyte__Convertion(Items.Email);
                    string Body = "<div><h3>Hi</h3><p>Stakeholder Participation Invitation" 
                            +"Letter</p><p align=\"justify\">You have been requested to kindly participate as a stakeholder in making choices"
                            +"among challenges/factors that are affecting the company’s ability "
                            +"to fully adopting one or more of the numerous technologies that uses "
                            +"or connects to the internet either directly or indirectly "
                           +" to contribute in the operations of the company.</p>"
                           + "<p align=\"justify\">The process involves completing structured "
                           + "questionnaire on your preferences regarding "
                           +"most important, yet lest difficult among major"
                           +"challenges/factors that affect adoption of technologies" 
                           +"of internet of things by your institution/company. "
+ "</p>Your participation in the as a stakeholder in this decision event will be of great" 
+"importance to assist the company in ensuring that it channels its limited resources in solving"
+"challenges/factors that are most important yet less "
+"difficult to solve to cut up expenses and enhance its productivity."
+ "To begin, please click the link below."
+ "<p><a href=\"http://questionnaire.minpip.com/Participant/getEmail/" + emailconv+"\" style=\"display:inline-block; font-weight:400; line-height:1.5; color:#212529;text-align:center;text-decoration:none;vertical-align:middle;cursor:pointer;-webkit-user-select:none;-moz-user-select:none;user-select:none;background-color:transparent;border:1px solid transparent;padding:.375rem .75rem;font-size:1rem;border-radius:.25rem;transition:color .15s ease-in-out,background-color .15s ease-in-out,border-color .15s ease-in-out,box-shadow .15s ease-in-out;color:#fff;background-color:#0d6efd;border-color:#0d6efd;\">Click Here</a></p></div>";
                    mail.Body = Body;
                    mail.IsBodyHtml = true;
                    SmtpClient smtp = new SmtpClient();
                    smtp.Host = "" //host;
                    smtp.Port = ;//port number
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new System.Net.NetworkCredential("password", "password"); // Enter seders User name and password  
                    smtp.EnableSsl = false;
                    smtp.Send(mail);
                        //add email here


                        


                        ViewBag.Error = "Record Successful";
                        ViewBag.color = "text text-success";



                    //
                }
                else
                {
                    ViewBag.Error = "Invalid Record";
                        ViewBag.color = "text text-danger";
                }


                
                
            }
            else
            {
                    ViewBag.Error =bytesString_Convertion("SW52YWxpZCBJbnB1dA==");
                }
            //
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message.ToString();
                ViewBag.color = "text text-danger";
            }
            return View(Items);
        }

        public static string Stringbyte__Convertion(string Parameter)
        {
            byte[] b = Encoding.ASCII.GetBytes(Parameter);
            return Convert.ToBase64String(b);
        }

        public static string bytesString_Convertion(string Parameter)
        {
            byte[] s = Convert.FromBase64String(Parameter);
            return Encoding.ASCII.GetString(s);
        }


    }
}
