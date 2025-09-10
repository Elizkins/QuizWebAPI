using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizWebAPI
{
    public class UserResponse
    {
        public UserResponse(User user)
        {
            Id = user.Id;
            Name = user.Name;
            Hobby = user.Hobby;
            Organization = user.Organization;
            BirthDate = user.BirthDate;
            Icon = user.Icon;
            IsTeacher = user.IsTeacher;
            Email = user.EmailPassword.Email;
            Password = user.EmailPassword.Password;
            EmailPasswordId = user.EmailPasswordId;
            
            Chats = user.ChatOfUsers.Select(cu => cu.Chat).ToList().ConvertAll(c => new ChatResponse(c));

            if(IsTeacher)
            {
                QuizItems = user.QuizItems.ToList().ConvertAll(q => new QuizItemResponse(q));
            }
            else
            {
                Scores = user.Scores.ToList().ConvertAll(s => new ScoreResponce(s));
            }

            Notifications = user.Notifications.ToList();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Hobby { get; set; }
        public string Organization { get; set; }
        public DateTime BirthDate { get; set; }
        public string Icon { get; set; }
        public bool IsTeacher { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int EmailPasswordId { get; set; }

        public ICollection<ChatResponse> Chats { get; set; }

        public ICollection<QuizItemResponse> QuizItems { get; set; } = new List<QuizItemResponse>();
        public ICollection<ScoreResponce> Scores { get; set; } = new List<ScoreResponce>();

        public ICollection<Notification> Notifications { get; set; }
    }
}
