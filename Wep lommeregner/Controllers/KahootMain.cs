using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Wep_lommeregner.Models;

namespace Wep_lommeregner.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KahootMain : ControllerBase
    {

        [HttpGet]
        public ReturnPointAndQuestion NextQuestion(int id)
        {

            if(id == 0)
            {
                //reset question
                GlobalData.QuestionNumber = 0;
            }
            else
            {
                // check answer and give points
                int correstAnswer = GlobalData.Questions[GlobalData.QuestionNumber].CorrectAnswer;
                if (id== correstAnswer)
                {
                    //give points
                    GlobalData.Points = GlobalData.Points + 500;
                }

                //add 1 to index
                GlobalData.QuestionNumber = GlobalData.QuestionNumber + 1;
                
            }
            //flyt data
            ReturnPointAndQuestion returnPointAndQuestion = new ReturnPointAndQuestion();
            //...
            //////returnPointAndQuestion.Question = GlobalData.Questions[GlobalData.QuestionNumber];
            //////returnPointAndQuestion.Points = GlobalData.Points;


            if (GlobalData.QuestionNumber == GlobalData.Questions.Count)
            {
                returnPointAndQuestion.Question = new Question();
                returnPointAndQuestion.Question.QuestionText = "NO MORE";
                returnPointAndQuestion.Points = GlobalData.Points;

            }
            else
            {
                returnPointAndQuestion.Question = GlobalData.Questions[GlobalData.QuestionNumber];
                returnPointAndQuestion.Points = GlobalData.Points;
            }


            return returnPointAndQuestion;
            //Question question = new Question();
            //question.Id = 1;
            //question.QuestionText = "Hvor langt væk er månen?";
            //question.Answer1Text = "210 000";
            //question.Answer2Text = "380 000";
            //question.CorrectAnswer = 2;


            //Question question = GlobalData.Questions[GlobalData.QuestionNumber];
            //return question;


            }

        [HttpGet("Result")]

        public decimal Result()
        {
            return GlobalData.Points;
        }


    }
}
