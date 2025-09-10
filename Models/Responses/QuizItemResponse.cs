using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizWebAPI
{
    public class QuizItemResponse
    {
        public QuizItemResponse(QuizItem quizItem, bool isNeedScores = false)
        {
            Id = quizItem.Id;
            Title = quizItem.Title;
            Icon = quizItem.Icon;
            Description = quizItem.Description;
            IsPublished = quizItem.IsPublished;
            CreatorUserId = quizItem.CreatorUserId;

            Questions = quizItem.Questions;

            if (isNeedScores)
            {
                Scores = quizItem.Scores.ToList();
            }
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Icon { get; set; }
        public string Description { get; set; }
        public bool IsPublished { get; set; }
        public int CreatorUserId { get; set; }

        public ICollection<Question> Questions { get; set; }

        public ICollection<Score> Scores { get; set; } = new List<Score>();
    }
}
