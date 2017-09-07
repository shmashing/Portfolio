using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Models;
using System.Net;
using System;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Threading.Tasks;
 
namespace Portfolio.Controllers
{
    public class WallController : Controller
    {
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View("Index");
        }

        [HttpGet]
        [Route("projects")]
        public IActionResult Projects()
        {
            return View("Projects");
        }

        [HttpGet]
        [Route("contact_me")]
        public IActionResult ContactMe()
        {
            return View("ContactMe");
        }

        [HttpGet]
        [Route("about_me")]
        public IActionResult AboutMe()
        {
            return View("AboutMe");
        }

        [HttpGet]
        [Route("resume")]
        public IActionResult ShowResume()
        {
            return View("Resume");
        }

        [HttpPost]
        [Route("contact_me")]
        public IActionResult ProcessForm(string Name, string Email, string Message){

            System.Console.WriteLine(Name+ ","+ Email+ ", "+ Message);
            bool successfulForm = true;
            if(Name == null){
                successfulForm = false;
                ViewBag.name_error = "Please enter your name.";
            }
            if(Email == null){
                successfulForm = false;
                ViewBag.email_error = "Please enter an email.";
            }
            if(Message == null){
                successfulForm = false;
                ViewBag.msg_error = "Please enter a message for me.";
            }
            if(successfulForm){
                SendMail(Name, Email, Message).Wait();

                return View("Thanks");
            }
            return View("ContactMe");
        }

        static async Task SendMail(string Name, string Email, string Message){
            string apiKey = Environment.GetEnvironmentVariable("SENDGRIDKEY");
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("myportfoliomonkey@gmail.com", "Email Monkey");
            var subject = "Web Monkey Has News";
            var to = new EmailAddress("kyle.mcfar1291@gmail.com", "Kyle");
            var plainTextContent = "New Message from Website!";
            var htmlContent = $"<h3><b>Name</b>: {Name}</h3>  <h3><b>Email</b>: {Email}</h3><p>{Message}";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);
        }
    }
}