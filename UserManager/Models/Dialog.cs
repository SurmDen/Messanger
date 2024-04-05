using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManager.Models
{
    public class Dialog
    {
        public long Id { get; set; }

        public string ChatName { get; set; }

        public List<Message> Messages { get; set; }
    }
}
