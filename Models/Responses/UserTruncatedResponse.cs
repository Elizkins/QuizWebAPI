using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizWebAPI
{
    public class UserTruncatedResponse
    {
        public UserTruncatedResponse(User user)
        {
            Id = user.Id;
            Name = user.Name;
            Hobby = user.Hobby;
            Organization = user.Organization;
            BirthDate = user.BirthDate;
            Icon = user.Icon;
            EmailPasswordId = user.EmailPasswordId;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Hobby { get; set; }
        public string Organization { get; set; }
        public DateTime BirthDate { get; set; }
        public string Icon { get; set; }
        public int EmailPasswordId { get; set; }
    }
}
