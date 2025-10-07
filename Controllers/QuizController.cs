using Microsoft.AspNetCore.Mvc;
using MyApp.Data;
using MyApp.Model;
using MyApp.Quizzmodel;

namespace MyApp.QzController
{
    public class QuizController : Controller
    {
        private readonly MyDatabase Data;
        public QuizController(MyDatabase _Data)
        {
            Data = _Data;
        }

        [HttpGet]
        public IActionResult Mathematics(int id)
        {
            var user = Data.Users.FirstOrDefault(U => U.id == id);
            if (user != null)
            {
                return View(user);
            }
            return NotFound();
        }
        [HttpPost]
        public IActionResult Mathematics(User model, string Sub)
        {
            var user = Data.Users.FirstOrDefault(U => U.id == model.id);
            if (user != null)
            {
                if (Sub == "Math")
                    return RedirectToAction("Mathematics","Math", new { id = model.id });
            }
            return NotFound();
        }


        [HttpGet]
        public IActionResult English(int id)
        {
            var user = Data.Users.FirstOrDefault(U => U.id == id);
            if (user != null)
            {
                return View(user);
            }
            return NotFound();

        }

        [HttpPost]
        public IActionResult English(User model, string Sub)
        {
            var user = Data.Users.FirstOrDefault(U => U.id == model.id);
            if (user != null)
            {
                if (Sub == "Eng")
                    return RedirectToAction("English","English", new { id = model.id });
            }
            return NotFound();
        }
        [HttpGet]
        public IActionResult General_Knowledge(int id)
        {
            var user = Data.Users.FirstOrDefault(U => U.id == id);
            if (user != null)
            {
                return View(user);
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult General_Knowledge(User model, string Sub)
        {
            var user = Data.Users.FirstOrDefault(U => U.id == model.id);
            if (user != null)
            {
                if (Sub == "GK")
                    return RedirectToAction("Gen_Knowledge","GK", new { id = model.id });
            }
            return NotFound();
        }

        [HttpGet]
        public IActionResult Logical(int id)
        {
            var user = Data.Users.FirstOrDefault(U => U.id == id);
            if (user != null)
            {
                return View(user);
            }
            return NotFound();

        }

        [HttpPost]
        public IActionResult Logical(User model, string Sub)
        {
            var user = Data.Users.FirstOrDefault(U => U.id == model.id);
            if (user != null)
            {
                if (Sub == "Logic")
                    return RedirectToAction("Logical","Logic", new { id = model.id });
            }
            return NotFound();
        }
    }
}




        
