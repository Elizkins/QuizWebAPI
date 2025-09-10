using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace QuizWebAPI
{
    public partial class User
    {
        public User()
        {
            ChatOfUsers = new HashSet<ChatOfUser>();
            Messages = new HashSet<Message>();
            QuizItems = new HashSet<QuizItem>();
            Scores = new HashSet<Score>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Hobby { get; set; }
        public string Organization { get; set; }
        public DateTime BirthDate { get; set; }
        public string Icon { get; set; }
        public bool IsTeacher { get; set; }
        public int EmailPasswordId { get; set; }

        public virtual EmailPassword EmailPassword { get; set; }
        [JsonIgnore]
        public virtual ICollection<ChatOfUser> ChatOfUsers { get; set; }
        [JsonIgnore]
        public virtual ICollection<Message> Messages { get; set; }
        public virtual ICollection<Chat> CreatedChats { get; set; }
        public virtual ICollection<QuizItem> QuizItems { get; set; }
        public virtual ICollection<Score> Scores { get; set; }
        public virtual ICollection<Notification> Notifications { get; set; }
        public virtual ICollection<UserAchievement> UserAchievements { get; set; }

    }
}
