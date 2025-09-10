using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizWebAPI
{
    public class AcievementResponse
    {
        public AcievementResponse(Achievement achievement)
        {
            Id = achievement.Id;
            Title = achievement.Title;
            Description = achievement.Description;
            Icon = achievement.Icon;

            UserAchievements = achievement.UserAchievements.ToList().ConvertAll(ua => new UserAchievementResponse(ua));
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }

        public ICollection<UserAchievementResponse> UserAchievements { get; set; }
    }
}
