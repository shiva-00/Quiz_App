using Microsoft.AspNetCore.Mvc;
using MyApp.Model;
using MyApp.Data;
using MyApp.Quizzmodel;

namespace MyApp.MathematicsController
{
    public class MathController : Controller
    {
        private readonly MyDatabase Data;

        public MathController(MyDatabase _Data)
        {
            Data = _Data;
        }

        [HttpGet]
        public IActionResult Mathematics_Easy(int id)
        {
            var user = Data.Users.FirstOrDefault(U => U.id == id);
            if (user != null)
            {
                var Quiz = new Quizmodel
                {
                    User_Id = id,
                    Subject = "Mathematics",
                    Score = 0,
                    Questions = new List<Questionmodel>
                    {
                        new Questionmodel
                        {
                            id = 1,
                            Question = "What is 5 + 5 ",
                            Options = new List<string>{"3","10","20","4"},
                            CorrectAnswer = "10"
                        },
                        new Questionmodel
                        {
                            id =2,
                            Question = "What is result of Multiplication : 19 x 7 ",
                            Options = new List<string>{"133","134","135","136"},
                            CorrectAnswer = "133"
                        },
                        new Questionmodel
                        {
                            id =3,
                            Question = "What is SQRT of 25",
                            Options = new List<string>{"10","6","5","4"},
                            CorrectAnswer = "5"
                        },
                        new Questionmodel
                        {
                            id =4,
                            Question = "A dozen bananas cost ₹96. What is the cost of one banana?",
                            Options = new List<string>{"6","5","8","10"},
                            CorrectAnswer = "8"
                        },
                        new Questionmodel
                        {
                            id =5,
                            Question =" What is the Resul of the following Fraction \"5/8 + 6/9 :  \" ",
                            Options = new List<string>{"33/24","35/27","30/72","31/24"},
                            CorrectAnswer = "31/24"
                        },
                         new Questionmodel
                        {
                            id =6,
                            Question =" A man can Travell 5 km in 1 hour. How far will he travel in 2.5 hours ",
                            Options = new List<string>{"11.5","12.5","13.5","15"},
                            CorrectAnswer = "12.5"
                        },
                         new Questionmodel
                        {
                            id =7,
                            Question ="There are 10 books left in the book shop and shopkeeper decides to sell them. the total cost of books are Rs/-600.  Among Them Two of the books are damaged, so, the shopkeeper decided to sell those 2 books for the half its original price. What is the total amount the buyer has to pay for all the ten books",
                            Options = new List<string>{"540","480","520","550"},
                            CorrectAnswer = "540"
                        },
                         new Questionmodel
                        {
                            id =8,
                            Question ="What is 12% of 1250",
                            Options = new List<string>{"125","105","150","145.7"},
                            CorrectAnswer = "150"
                        },
                         new Questionmodel
                        {
                            id =9,
                            Question ="A shirt costs RS/-750. The shopkeeper offered them a discount of 15%. What is the cost of the shirt.",
                            Options = new List<string>{"637.50","637","635","650"},
                            CorrectAnswer = "637.50"
                        },
                         new Questionmodel
                        {
                            id =10,
                            Question ="What is the average of following : 10,20,15,30,25",
                            Options = new List<string>{"10", "15","20","25"},
                            CorrectAnswer = "20"
                        }
                        
                    }
                };
                return View(Quiz);

            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult Mathematics_Easy(Quizmodel quiz)
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