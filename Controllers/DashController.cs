using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Models;
 
namespace Portfolio.Controllers
{
    public class DashController : Controller
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
        public IActionResult ProcessForm(FormViewModel form){
            System.Console.WriteLine("Name: " + form.Name);
            if(ModelState.IsValid){
                System.Console.WriteLine(form.Name + " with email " + form.Email + " says:");
                System.Console.WriteLine(form.Message);
                return View("Thanks");
            }
            else {
                return View("ContactMe");
            }
        }
    }
}