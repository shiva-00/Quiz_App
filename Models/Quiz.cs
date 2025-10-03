
namespace MyApp.Quizzmodel
{
    public class Questionmodel
    {
        public int id { get; set; }
        public string Question { get; set; } = string.Empty;
        public List<string> Options { get; set; } = new List<string> ();
        public string? UserOption { get; set; }
        public string CorrectAnswer { get; set; } = string.Empty;
    }

    public class Quizmodel
    {
        public List<Questionmodel> Questions { get; set; } = new List<Questionmodel> ();
        public int Score;
        public string Subject { get; set; } = string.Empty;
        public int User_Id { get; set; }
    }
}