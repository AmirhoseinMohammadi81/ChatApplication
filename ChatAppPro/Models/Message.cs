using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatAppPro.Models
{
    public class Message
    {
        public int MessageId { get; set; }
        public string MessageBody { get; set; }
        public string MessageDateTime { get; set; }
        public virtual ChatUser FromUser { get; set; }
    }
}
