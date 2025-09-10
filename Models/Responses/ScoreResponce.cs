using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizWebAPI
{
    public class ScoreResponce
    {
        public ScoreResponce(Score score)
        {
            Id = score.Id;
            UserId = score.UserId;
            QuizItemId = score.QuizItemId;
            PointsCount = score.PointsCount;

            var quizItem = new QuizItemResponse(score.QuizItem);
            quizItem.Questions.Clear();
            QuizItem = quizItem;
        }

        public int Id { get; set; }
        public int UserId { get; set; }
        public int QuizItemId { get; set; }
        public int PointsCount { get; set; }

        public QuizItemResponse QuizItem { get; set; }
    }
}
