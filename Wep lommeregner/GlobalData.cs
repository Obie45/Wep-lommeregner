using Wep_lommeregner;
using Wep_lommeregner.Models;

namespace Wep_lommeregner
{
    public static class GlobalData
    {
        public static int QuestionNumber { get; set; }

        public static List<Question>Questions { get; set; }
        public static int Points { get; set; }

        public static void AddQuestions()
        {
            List<Question> Listofquestions = new List<Question>();

            Question question = new Question();

            question.Id = 0;
            question.QuestionText = "Hvor langt væk er månen?";
            question.Answer1Text = "210 000";
            question.Answer2Text = "380 000";
            question.CorrectAnswer = 2;

            Listofquestions.Add(question);

            question = new Question();
            question.QuestionText = "Omkredsen af jordern er?";
            question.Answer1Text = "42000";
            question.Answer2Text = "30000";
            question.CorrectAnswer = 1;

            Listofquestions.Add(question);

            GlobalData.Questions = Listofquestions;
        }
    }
}
