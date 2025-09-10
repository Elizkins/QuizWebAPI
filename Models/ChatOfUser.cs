using Newtonsoft.Json;
using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace QuizWebAPI
{
    public partial class ChatOfUser
    {
        public int Id { get; set; }
        public int ChatId { get; set; }
        public int UserId { get; set; }
        [JsonIgnore]
        public virtual Chat Chat { get; set; }
        [JsonIgnore]
        public virtual User User { get; set; }
    }
}
