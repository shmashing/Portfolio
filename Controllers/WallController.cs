using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Models;
using System.Net;
 
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
                return View("Thanks");
            }
            return View("ContactMe");
        }
    }
}