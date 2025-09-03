using Microsoft.AspNetCore.Mvc;
using MyApp.Data;

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
        
    }
}


