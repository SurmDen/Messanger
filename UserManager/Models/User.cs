using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManager.Models
{
    public class User
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Role { get; set; }

        public string Password { get; set; }

        public string City { get; set; }

        public int Age { get; set; }

        public int LastSeenNoticesCount { get; set; }

        public List<Like> Likes { get; set; }

        public List<Subscriber> Subscribers { get; set; }

        public List<Photo> Photos { get; set; }

        public List<Notice> Notices { get; set; }
    }
}
