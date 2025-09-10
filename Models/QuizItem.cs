using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace QuizWebAPI
{
    public partial class QuizItem
    {
        public QuizItem()
        {
            Questions = new HashSet<Question>();
            Scores = new HashSet<Score>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Icon { get; set; }
        public string Description { get; set; }
        public string Character { get; set; }
        public bool IsPublished { get; set; }
        public int CreatorUserId { get; set; }

        public virtual User CreatorUser { get; set; }
        public virtual ICollection<Question> Questions { get; set; }
        public virtual ICollection<Score> Scores { get; set; }
    }
}
