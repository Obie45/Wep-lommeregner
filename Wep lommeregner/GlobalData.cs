using Newtonsoft.Json;
using Wep_lommeregner;
using Wep_lommeregner.Models;

namespace Wep_lommeregner
{
    public static class GlobalData
    {
        public static int QuestionNumber { get; set; }

        public static List<Question>Questions { get; set; }
        public static double Points { get; set; }
        //time!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        public static DateTime Time { get; set; }


        public static void AddQuestions()
        {
            List<Question> Listofquestions = new List<Question>();

            var listoffiles = Directory.EnumerateFiles("c:\\questions");

            foreach (var file in listoffiles)
            {
                var json = File.ReadAllText(file);
                Question question = JsonConvert.DeserializeObject<Question>(json);
                Listofquestions.Add(question);

            }
            if (Listofquestions.Count == 0)
            {
                Question question = new Question();
                    //sætter variabler til spørg2
                question.QuestionText = "Omkredsen af jordern er?";
                question.Answer1Text = "42 000";
                question.Answer2Text = "30 000";
                question.Answer3Text = "49 000";
                question.Answer4Text = "36 000";
                question.CorrectAnswer = 1;
                string json = JsonConvert.SerializeObject(question);
                File.WriteAllText("c:\\questions\\newQuestion.json", json);

                Listofquestions.Add(question);
            }



            //Question question = new Question();

            //question.Id = 0;
            //question.QuestionText = "Hvor langt væk er månen?";
            //question.Answer1Text = "210 000";
            //question.Answer2Text = "380 000";
            //question.Answer3Text = "170 000";
            //question.Answer4Text = "420 000";
            //question.CorrectAnswer = 2;

            //Listofquestions.Add(question);

            //question = new Question();
            //question.QuestionText = "Omkredsen af jordern er?";
            //question.Answer1Text = "42 000";
            //question.Answer2Text = "30 000";
            //question.Answer3Text = "49 000";
            //question.Answer4Text = "36 000";
            //question.CorrectAnswer = 1;

            //Listofquestions.Add(question);

            GlobalData.Questions = Listofquestions;
        }
    }
}
