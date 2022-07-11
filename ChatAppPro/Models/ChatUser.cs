using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace ChatAppPro.Models
{
    public class ChatUser:IdentityUser
    {
        public virtual ICollection<Message> Messages { get; set; }

    }
}