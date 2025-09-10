using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizWebAPI
{
    public class ChatResponse
    {
        public ChatResponse(Chat chat, bool isNeedMessanges = false)
        {
            Id = chat.Id;
            Name = chat.Name;
            Icon = chat.Icon;
            CreatorUserId = chat.CreatorUserId;

            Users = chat.ChatOfUsers.Select(cu => cu.User).ToList().ConvertAll(c => new UserTruncatedResponse(c)).ToList();

            if (isNeedMessanges)
            {
                Messages = chat.Messages;
            }
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
        public int? CreatorUserId { get; set; }

        public ICollection<UserTruncatedResponse> Users { get; set; }

        public ICollection<Message> Messages { get; set; }
    }
}
