using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManager.Models
{
    public class Subscriber
    {
        public long Id { get; set; }

        public string SubName { get; set; }

        public long SubId { get; set; }

        public bool IsFriend { get; set; } = false;

        public long UserId { get; set; }

        public User User { get; set; }
    }
}
