using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManager.Models
{
    public class Like
    {
        public long Id { get; set; }

        public string LikerName { get; set; }

        public long LikerId { get; set; }

        public long UserId { get; set; }

        public User User { get; set; }
    }
}