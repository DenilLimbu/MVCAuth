using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCAuthentication.Models;
using System.IO;
using System.Net;
using System.Net.Mail;

namespace MVCAuthentication.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Email()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Email(EmailModel model, List<HttpPostedFileBase> attachments)
        {



            LoginViewModel mod = (LoginViewModel)TempData["student"];

            ViewBag.message = mod.Email;
            ViewBag.ma = mod.Password;

            using (MailMessage mm = new MailMessage(mod.Email, model.To))
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
                NetworkCredential NetworkCred = new NetworkCredential(mod.Email, mod.Password);
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