using Newtonsoft.Json;
using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace QuizWebAPI
{
    public partial class Score
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int QuizItemId { get; set; }
        public int PointsCount { get; set; }

        [JsonIgnore]
        public virtual QuizItem QuizItem { get; set; }
        public virtual User User { get; set; }
    }
}
