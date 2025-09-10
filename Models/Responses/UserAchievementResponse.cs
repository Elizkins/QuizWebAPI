using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizWebAPI
{
    public class UserAchievementResponse
    {

        public UserAchievementResponse(UserAchievement userAchievement)
        {
            Id = userAchievement.Id;
            AchievementId = userAchievement.AchievementId;
            UserId = userAchievement.UserId;

            var achievement = userAchievement.Achievement;
            achievement.UserAchievements.Clear();
            Achievement = achievement;
        }

        public int Id { get; set; }
        public int AchievementId { get; set; }
        public int UserId { get; set; }
        public Achievement Achievement { get; set; }
    }
}
