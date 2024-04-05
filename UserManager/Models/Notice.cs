using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManager.Models
{
    public class Notice
    {
        public long Id { get; set; }

        public string NotifyerName { get; set; }

        public long NotifyerId { get; set; }

        public string Context { get; set; }

        public long UserId { get; set; }

        public User User { get; set; }

    }
}
