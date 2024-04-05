using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManager.Helpers
{
    public class MessageModel
    {
        public string UserName { get; set; }

        public string Context { get; set; }

        public long DialogId { get; set; }
    }
}
