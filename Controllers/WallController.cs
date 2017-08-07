using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
 
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
        public IActionResult projects()
        {
            return View("projects");
        }

        [HttpGet]
        [Route("contact_me")]
        public IActionResult contactMe()
        {
            return View("contact_me");
        }

        [HttpPost]
        [Route("form_submission")]
        public IActionResult thankYou(){
            return View("thanks");
        }
    }
}