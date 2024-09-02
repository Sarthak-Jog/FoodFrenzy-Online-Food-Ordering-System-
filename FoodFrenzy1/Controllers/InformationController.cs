using FoodFrenzy1.Models;
using Microsoft.AspNetCore.Mvc;

namespace FoodFrenzy1.Controllers
{
    public class InformationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public ActionResult ContactUs()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ContactUs(ContactModel contact)
        {
            return View();
        }
        public ActionResult AboutUs()
        {

            return View();
        }
    }
}
