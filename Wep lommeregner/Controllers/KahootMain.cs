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
                //reset questionc and points
                GlobalData.QuestionNumber = 0;
                GlobalData.Points = 0;
                //maketime!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
              

            }
            else
            {
                // check answer and give points
                int correstAnswer = GlobalData.Questions[GlobalData.QuestionNumber].CorrectAnswer;
                if (id== correstAnswer)
                {
                    //give points
                    var diff = DateTime.Now - GlobalData.Time;
                    var scc = diff.TotalSeconds;
                    GlobalData.Points = GlobalData.Points + Math.Round(4500/scc) + 500;

                    //+ TID !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                }

                //add 1 to index
                GlobalData.QuestionNumber = GlobalData.QuestionNumber + 1;
                
            }
            //flyt data
            ReturnPointAndQuestion returnPointAndQuestion = new ReturnPointAndQuestion();
            //...



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

            GlobalData.Time = DateTime.Now;
            return returnPointAndQuestion;


            }
            
        [HttpGet("Result")]

        public double Result()
        {
            return GlobalData.Points;
        }


    }
}
