using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace QuizWebAPI
{
    public partial class Chat
    {
        public Chat()
        {
            ChatOfUsers = new HashSet<ChatOfUser>();
            Messages = new HashSet<Message>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
        public int? CreatorUserId { get; set; }

        [JsonIgnore]
        public virtual User CreatorUser { get; set; }
        [JsonIgnore]
        public virtual ICollection<ChatOfUser> ChatOfUsers { get; set; }
        public virtual ICollection<Message> Messages { get; set; }
    }
}
