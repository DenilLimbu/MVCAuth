using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCAuthentication.Models;
using System.IO;
using System.Net;
using System.Net.Mail;
using MVCAuthentication.BusinessLayer;

namespace MVCAuthentication.Controllers
{
    public class HomeController : Controller
    {
        IBusinessAuthentication ibus = new BusinessAuthentication();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }

        public ActionResult EplLeague()
        {
            List<EPL> test = ibus.GetTable("EPLeague");
            return View(test);
        }

        public ActionResult SpanishLeague()
        {
            List<EPL> demo = ibus.GetTable("Laliga");
            return View(demo);
        }

        public ActionResult GermanLeague()
        {
            List<EPL> german = ibus.GetTable("GermanLeague");
            return View(german);

        }

        public ActionResult ItalyLeague()
        {
            List<EPL> italy= ibus.GetTable("ItalianLeague");
            return View(italy);

        }

        public ActionResult Ero()
        {
            return View();
        }

        public ActionResult Email()
        {

            LoginViewModel mod = (LoginViewModel)TempData["student"];
            if (mod == null && PermEmail.Email == null )
            {            
                //int den = 0;
                //den = den +1;
                return RedirectToAction("Ero");
            }
            PermEmail.Email = "limbudenil@gmail.com";
            PermEmail.Password = "asdfqw12#";
            TempData["studen"] = mod;
            RedirectToAction("Email", "HomeController");
            return View();
        }

        [HttpPost]
        public ActionResult Email(EmailModel model, List<HttpPostedFileBase> attachments)
        {
            //model is something that is the email attributes

            LoginViewModel mod = (LoginViewModel)TempData["studen"];

            if (PermEmail.Email == null)
            {

                PermEmail.Email = mod.Email;
                PermEmail.Password = mod.Password;

                ViewBag.message = mod.Email;
                ViewBag.ma = mod.Password;
            }


            using (MailMessage mm = new MailMessage(PermEmail.Email, model.To))
            {

                mm.Subject = model.Subject;
                mm.Body = model.Body;

                foreach (HttpPostedFileBase attachment in attachments)
                {
                    if (attachment != null)
                    {
                        string fileName = Path.GetFileName(attachment.FileName);
                        mm.Attachments.Add(new Attachment(attachment.InputStream, fileName));
                    }
                }

                mm.IsBodyHtml = false;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;
                NetworkCredential NetworkCred = new NetworkCredential(PermEmail.Email, PermEmail.Password);
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = NetworkCred;
                smtp.Port = 587;
                smtp.Send(mm);
                ViewBag.Message = "Email has been sent to your mail address";
            }

            return View();
        }

    }
}
    



      //catch(Exception ex)
      //          {
      //              return View("There is an error",new HandleErrorInfo(ex,"HomeController","Email"));
      //          }

      //      }
      //      return View();