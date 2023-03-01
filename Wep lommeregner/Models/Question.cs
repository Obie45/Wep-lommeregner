namespace Wep_lommeregner.Models
{
    public class Question
    {
        public int Id {get; set; } 
        public string QuestionText { get; set; }   
        public string Answer1Text { get; set;}
        public string Answer2Text { get; set;}
        public int CorrectAnswer { get; set;}
    }
}
