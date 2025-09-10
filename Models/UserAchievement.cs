using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizWebAPI
{
    public partial class UserAchievement
    {
        public int Id { get; set; }
        public int AchievementId { get; set; }
        public int UserId { get; set; }
        public virtual Achievement Achievement { get; set; }
        public virtual User User { get; set; }
    }
}
