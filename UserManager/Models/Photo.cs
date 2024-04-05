using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManager.Models
{
    public class Photo
    {
        public long Id { get; set; }

        public string Path { get; set; }

        public bool IsMain { get; set; } = false;

        public long UserId { get; set; }

        public User User { get; set; }
    }
}
