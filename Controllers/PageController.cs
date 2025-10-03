using Microsoft.AspNetCore.Mvc;
using MyApp.Data;
using MyApp.Model;

namespace MyApp.PGController
{
    public class PageController : Controller
    {
        private readonly MyDatabase Data;
        public PageController(MyDatabase _Data)
        {
            Data = _Data;
        }

        [HttpGet]
        public IActionResult WebPage(int Id)
        {
            var user = Data.Users.FirstOrDefault(U => U.id == Id);
            if (user != null)
            {
                return View(user);
            }
            return NotFound();
        }
        [HttpPost]
        public IActionResult WebPage(User model)
        {
            var user = Data.Users.FirstOrDefault(U => U.id == model.id);
            if (user != null)
                return RedirectToAction("Profile", new { id = model.id });
            return NotFound();
        }
        [HttpGet]
        public IActionResult Profile(int id)
        {
            var user = Data.Users.FirstOrDefault(U => U.id == id);
            if (user != null)
            {
                return View(user);
            }
            return NotFound();
        }
        [HttpPost]
        public IActionResult Profile(User model, string subject)
        {
            var user = Data.Users.FirstOrDefault(U => U.id == model.id);
            if (user != null)
            {
                if (subject == "Mathematics")
                    return RedirectToAction("Mathematics","Quiz", new { id = model.id });
                else if (subject == "English")
                    return RedirectToAction("English", "Quiz", new { id = model.id });
                else if (subject == "General_Knowledge")
                    return RedirectToAction("General_Knowledge", "Quiz", new { id = model.id });
                else if (subject == "Aptitude")
                    return RedirectToAction("Aptitude", "Quiz", new { id = model.id });
                else if (subject == "Logical")
                    return RedirectToAction("Logical", "Quiz", new { id = model.id });
            }
            return NotFound();
        }
        
    }
}


