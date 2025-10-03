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
                if (Sub == "Easy")
                    return RedirectToAction("Mathematics_Easy","Math", new { id = model.id });
                else if (Sub == "Medium")
                    return RedirectToAction("Mathematics_Medium","Math", new { id = model.id });
                else if (Sub == "Difficult")
                    return RedirectToAction("Mathematics_DIfficult", "Math", new { id = model.id });
                else if (Sub == "Advanced")
                    return RedirectToAction("Mathematics_Advanced","Math", new { id = model.id });
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
                if (Sub == "Easy")
                    return RedirectToAction("English_Easy", new { id = model.id });
                else if (Sub == "Medium")
                    return RedirectToAction("English_Medium", new { id = model.id });
                else if (Sub == "Difficult")
                    return RedirectToAction("English_DIfficult", new { id = model.id });
                else if (Sub == "Advanced")
                    return RedirectToAction("English_Advanced", new { id = model.id });
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
                if (Sub == "Easy")
                    return RedirectToAction("General_Knowledge_Easy", new { id = model.id });
                else if (Sub == "Medium")
                    return RedirectToAction("General_Knowledge_Medium", new { id = model.id });
                else if (Sub == "Difficult")
                    return RedirectToAction("General_Knowledge_DIfficult", new { id = model.id });
                else if (Sub == "Advanced")
                    return RedirectToAction("General_Knowledge_Advanced", new { id = model.id });
            }
            return NotFound();
        }
        [HttpGet]
        public IActionResult Aptitude(int id)
        {
            var user = Data.Users.FirstOrDefault(U => U.id == id);
            if (user != null)
            {
                return View(user);
            }
            return NotFound();

        }

        [HttpPost]
        public IActionResult Aptitude(User model, string Sub)
        {
            var user = Data.Users.FirstOrDefault(U => U.id == model.id);
            if (user != null)
            {
                if (Sub == "Easy")
                    return RedirectToAction("Aptitude_Easy", new { id = model.id });
                else if (Sub == "Medium")
                    return RedirectToAction("Aptitude_Medium", new { id = model.id });
                else if (Sub == "Difficult")
                    return RedirectToAction("Aptitude_DIfficult", new { id = model.id });
                else if (Sub == "Advanced")
                    return RedirectToAction("Aptitude_Advanced", new { id = model.id });
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
                if (Sub == "Easy")
                    return RedirectToAction("Logical_Easy", new { id = model.id });
                else if (Sub == "Medium")
                    return RedirectToAction("Logical_Medium", new { id = model.id });
                else if (Sub == "Difficult")
                    return RedirectToAction("Logical_DIfficult", new { id = model.id });
                else if (Sub == "Advanced")
                    return RedirectToAction("Logical_Advanced", new { id = model.id });
            }
            return NotFound();
        }
    }
}




        
