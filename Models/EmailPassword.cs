using Newtonsoft.Json;
using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace QuizWebAPI
{
    public partial class EmailPassword
    {
        public EmailPassword()
        {
            Users = new HashSet<User>();
        }

        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        [JsonIgnore]
        public virtual ICollection<User> Users { get; set; }
    }
}
