using Newtonsoft.Json;
using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace QuizWebAPI
{
    public partial class Message
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int SenderUserId { get; set; }
        public int ChatId { get; set; }
        public DateTime Date { get; set; }

        [JsonIgnore]
        public virtual Chat Chat { get; set; }
        public virtual User SenderUser { get; set; }
    }
}
