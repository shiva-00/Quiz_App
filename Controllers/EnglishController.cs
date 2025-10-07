using Microsoft.AspNetCore.Mvc;
using MyApp.Data;
using MyApp.Quizzmodel;

namespace MyApp.English_Controller
{
    public class EnglishController : Controller
    {
        private readonly MyDatabase Data;
        public EnglishController(MyDatabase _Data)
        {
            Data = _Data;
        }

        [HttpGet]
        public IActionResult English(int id)
        {
            var user = Data.Users.FirstOrDefault(U => U.id == id);
            if (user != null)
            {
                var Quiz = new Quizmodel
                {
                    User_Id = id,
                    Score = 0,
                    Subject = "English",
                    Questions = new List<Questionmodel>
                    {
                        new Questionmodel
                        {
                            id = 1,
                            Question ="She _____ to school Everyday",
                            Options = new List<string>{"go","went","goes","going"},
                            CorrectAnswer  = "goes"

                        },
                        new Questionmodel
                        {
                            id = 2,
                            Question ="I have ___ apple.",
                            Options = new List<string>{"a","an","the","one"},
                            CorrectAnswer  = "an"
                        },
                        new Questionmodel
                        {
                            id =3,
                            Question="What is the synonym of \"Assist\" ",
                            Options=new List<string>{"Help","Delay","Abstruct","Nurture"},
                            CorrectAnswer = "Help"
                        },
                        new Questionmodel
                        {
                            id =4,
                            Question="What is the opposite word for \"Artificial\" ",
                            Options=new List<string>{"Unnatural","weird","Fake","Natural"},
                            CorrectAnswer = "Natural"
                        },
                        new Questionmodel
                        {
                            id =5,
                            Question="What is the Plural word for \"Knife\" ",
                            Options=new List<string>{"Knives","Knifes","Sword","Kniv"},
                            CorrectAnswer = "Knives"
                        },
                        new Questionmodel
                        {
                            id =6,
                            Question="If I ____ rich, I would travel the world",
                            Options=new List<string>{"were","was","is","am"},
                            CorrectAnswer = "were"
                        },
                        new Questionmodel
                        {
                            id =7,
                            Question="We ____ friends for many years: form the sentence",
                            Options=new List<string>{"has been","have been","were","are"},
                            CorrectAnswer = "have been"
                        },
                        new Questionmodel
                        {
                            id =8,
                            Question="What is the synonym of \"Big\"",
                            Options=new List<string>{"Huge","Small","Tiny","Weak"},
                            CorrectAnswer = "Huge"
                        },
                        new Questionmodel
                        {
                            id =9,
                            Question="Which of the following words start with an vowel",
                            Options=new List<string>{"Rice","Dog","Cannon","Outstanding"},
                            CorrectAnswer = "Outstanding"
                        },
                        new Questionmodel
                        {
                            id = 10,
                            Question="How many vowels and Consonents Present in the Alphabets",
                            Options=new List<string>{"10,16","3,23","7,19","5,21"},
                            CorrectAnswer = "5,21"
                        },
                        new Questionmodel
                        {
                            id = 11,
                            Question ="Choose the correct sentence",
                            Options = new List<string>{"He don’t like coffee","He doesn’t like coffee","He doesn’t likes coffee","He not like coffee"},
                            CorrectAnswer="He doesn’t like coffee"
                        },
                        new Questionmodel
                        {
                            id = 12,
                            Question ="Choose the correct Tense:  \"I ____ him yesterday \"",
                            Options = new List<string>{"meet","meets","meeting","met"},
                            CorrectAnswer="met"
                        },
                        new Questionmodel
                        {
                            id = 13,
                            Question ="Identify the error : \"The information are correct\"",
                            Options = new List<string>{"The","information","are","correct"},
                            CorrectAnswer="are"
                        },
                        new Questionmodel
                        {
                            id = 14,
                            Question ="Choose the correct sentence:",
                            Options = new List<string>{"He is reading an book","He is reading book","He is reading a book","He is book reading"},
                            CorrectAnswer="He is reading a book"
                        },
                        new Questionmodel
                        {
                            id = 15,
                            Question ="The future tene of \"He drank water\"",
                            Options = new List<string>{"He is drinking water","He will drink water","He has been drinking water","He should drink water"},
                            CorrectAnswer="He will drink water"
                        },
                        new Questionmodel
                        {
                            id = 16,
                            Question ="Which of the following word is correct ",
                            Options = new List<string>{"Converstion","Convertion","covertion","Conversation"},
                            CorrectAnswer="Conversation"
                        },
                        new Questionmodel
                        {
                            id = 17,
                            Question ="How many vowels in the word \"Constitution\"",
                            Options = new List<string>{"5","6","4","7"},
                            CorrectAnswer="5"
                        },
                        new Questionmodel
                        {
                            id = 18,
                            Question ="Every students in the class has submitted their homework.: Identify the incorrect word",
                            Options = new List<string>{"their","students","the","has"},
                            CorrectAnswer="students"
                        },
                        new Questionmodel
                        {
                            id = 19,
                            Question ="He is writing a book : Identify verb in the sentence",
                            Options = new List<string>{"he","book","a","writing"},
                            CorrectAnswer="writing"
                        },
                        new Questionmodel
                        {
                            id = 20,
                            Question ="\"He got fired yesterday\": Identify the Tense:",
                            Options = new List<string>{ "past","future","present","None"},
                            CorrectAnswer="past"
                        },
                    }

                };
                return View(Quiz);
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult English(Quizmodel quiz)
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