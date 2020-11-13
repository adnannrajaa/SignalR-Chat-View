using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRChat.Models
{
    public class Contact
    {
        [Key]
        public int id { get; set; }
        public int user_id { get; set; }
    }

    public class Connection
    {
        public string ConnectionID { get; set; }
        public string UserAgent { get; set; }
        public bool Connected { get; set; }
    }

    public class ConversationRoom
    {
        [Key]
        public string RoomName { get; set; }
    }
}
