using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using MyApp.Data;
using MyApp.Quizzmodel;

namespace MyApp.GeneralKnowledgeController
{
    public class GKController : Controller
    {
        private readonly MyDatabase Data;

        public GKController(MyDatabase _Data)
        {
            Data = _Data;
        }

        [HttpGet]
        public IActionResult Gen_Knowledge(int id)
        {
            var user = Data.Users.FirstOrDefault(U => U.id == id);
            if (user != null)
            {
                var Quiz = new Quizmodel
                {
                    User_Id = id,
                    Score = 0,
                    Subject = "General_Knowledge",
                    Questions = new List<Questionmodel>
                    {
                        new Questionmodel
                        {
                            id =1,
                            Question = "Which is the largest ocean in the world ",
                            Options = new List<string>{"Indian Ocean","Arabian sea","Pacific","Atlantic"},
                            CorrectAnswer = "Pacific"
                        },
                        new Questionmodel
                        {
                            id =2,
                            Question = "How many Continents are there :",
                            Options = new List<string>{"5","6","7","10"},
                            CorrectAnswer = "7"
                        },
                        new Questionmodel
                        {
                            id =3,
                            Question = "The largest river in the world: ",
                            Options = new List<string>{"Nile","Niagara","Amazon","Congo"},
                            CorrectAnswer = "Nile"
                        },
                        new Questionmodel
                        {
                            id =4,
                            Question = "The largest desert in the world: ",
                            Options = new List<string>{"Thar","Sahara","Antarctic","Arabian"},
                            CorrectAnswer = "Antarctic"
                        },
                        new Questionmodel
                        {
                            id =5,
                            Question = "Which country is called \" The land of the Midnight Sun\"",
                            Options = new List<string>{"japan","Norway","iceland","Greenland"},
                            CorrectAnswer = "Norway"
                        },
                        new Questionmodel
                        {
                            id =6,
                            Question = "Which is the largest Island in the world",
                            Options = new List<string>{"Iceland","Madagascar","srilanka","Greenland"},
                            CorrectAnswer = "Greenland"
                        },
                        new Questionmodel
                        {
                            id =7,
                            Question = "Which continent has the most countries:",
                            Options = new List<string>{"Asia","Europe","Africa","Australia"},
                            CorrectAnswer = "Africa"
                        },
                        new Questionmodel
                        {
                            id =8,
                            Question = "The land of thousand lakes is called: ",
                            Options = new List<string>{"Finland","Canada","Andaman","Greenaland"},
                            CorrectAnswer = "Finland"
                        },
                        new Questionmodel
                        {
                            id =9,
                            Question = "Tallest moutain in the world",
                            Options = new List<string>{"Annapurna","Everest","K2","Lhotse"},
                            CorrectAnswer = "Everest"
                        },
                        new Questionmodel
                        {
                            id =10,
                            Question = "Name of the deepest place on earth: ",
                            Options = new List<string>{"Tonga Trench","The Mponeng Gold Mine","Mariana Trench"},
                            CorrectAnswer = "Mariana Trench"
                        },

                    }
                };
                return View(Quiz);
            }
            return NotFound();
        }
        [HttpPost]
        public IActionResult Gen_Knowledge(Quizmodel quiz)
        {
            var user = Data.Users.FirstOrDefault(U => U.id == quiz.User_Id);
            if (user != null)
            {
                int score = 0;
                foreach (var Q in quiz.Questions)
                {
                    if (Q.UserOption == Q.CorrectAnswer)
                    {
                        score += 1;
                    }
                }
                quiz.Score = score;
                return View("Result", quiz);
            }
            return NotFound();
        }
        
    }
}