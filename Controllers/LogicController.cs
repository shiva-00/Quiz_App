using System.Net.WebSockets;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using MyApp.Data;
using MyApp.Quizzmodel;

namespace MyApp.LogicalController
{
    public class LogicController : Controller
    {
        private readonly MyDatabase Data;

        public LogicController(MyDatabase _Data)
        {
            Data = _Data;
        }

        [HttpGet]
        public IActionResult Logical(int id)
        {
            var user = Data.Users.FirstOrDefault(U => U.id == id);
            if (user != null)
            {
                var Quiz = new Quizmodel
                {
                    User_Id = id,
                    Score = 0,
                    Subject = "Logical",
                    Questions = new List<Questionmodel>
                    {
                        new Questionmodel
                        {
                            id =1,
                            Question ="Find the missing number: 2, 6, 12, 20, 30, ?",
                            Options = new List<string>{"44","42","52","46"},
                            CorrectAnswer ="42",
                        },
                         new Questionmodel
                        {
                            id =2,
                            Question ="7, 14, 28, 56, ?, 224",
                            Options = new List<string>{"112","114","110","144"},
                            CorrectAnswer ="112",
                        },
                         new Questionmodel
                        {
                            id =3,
                            Question ="If PEN = 35, then BOOK = ?",
                            Options = new List<string>{"44","40","43","55"},
                            CorrectAnswer ="43",
                        },
                         new Questionmodel
                        {
                            id =4,
                            Question ="A man walks 4 km north, then 3 km east. How far is he from the starting point?",
                            Options = new List<string>{"5","7","1","10"},
                            CorrectAnswer ="5",
                        },
                         new Questionmodel
                        {
                            id =5,
                            Question ="A person walks 5 km north, then 4 km south, then 3 km east. Find his distance from starting point.",
                            Options = new List<string>{"4.6km","4km","5.2km","3.16km"},
                            CorrectAnswer ="3.16km",
                        },
                         new Questionmodel
                        {
                            id =6,
                            Question ="A cube has numbers 1 to 6 on faces. If 1 is opposite 6 and 2 opposite 5, which is opposite 3?",
                            Options = new List<string>{"5","4","6","2"},
                            CorrectAnswer ="4",
                        },
                         new Questionmodel
                        {
                            id =7,
                            Question ="A box contains 3 red, 4 blue, 5 green balls. If one ball drawn, probability of red?",
                            Options = new List<string>{"2/4","3/4","3","1/4"},
                            CorrectAnswer ="1/4",
                        },
                         new Questionmodel
                        {
                            id =8,
                            Question ="Lion : Cub :: Dog : ?",
                            Options = new List<string>{"Puppy","Kitten","Calf","Foal"},
                            CorrectAnswer ="Puppy",
                        },
                         new Questionmodel
                        {
                            id =9,
                            Question ="Z, W, T, Q, ?",
                            Options = new List<string>{"M","N","o","P"},
                            CorrectAnswer ="N",
                        },
                         new Questionmodel
                        {
                            id =10,
                            Question ="A man walks 5 km north, 3 km west, 5 km south. Distance from start?",
                            Options = new List<string>{"2","3","4","5"},
                            CorrectAnswer ="3",
                        },
                    }

                };
                return View(Quiz);
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult Logical(Quizmodel quiz)
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