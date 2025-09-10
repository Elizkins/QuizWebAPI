using Newtonsoft.Json;
using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace QuizWebAPI
{
    public partial class Question
    {
        public Question()
        {
            Answers = new HashSet<Answer>();
        }

        public int Id { get; set; }
        public string Text { get; set; }
        public string Icon { get; set; }
        public int QuizItemId { get; set; }

        [JsonIgnore]
        public virtual QuizItem QuizItem { get; set; }
        public virtual ICollection<Answer> Answers { get; set; }
    }
}
