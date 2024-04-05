using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManager.Models
{
    public class Message
    {
        public long Id { get; set; }

        public string UserName { get; set; }

        public string Context { get; set; }

        public bool IsSeen { get; set; } = false;

        public long DialogId { get; set; }

        public Dialog Dialog { get; set; }
    }
}
