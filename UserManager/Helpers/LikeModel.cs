using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManager.Helpers
{
    public class LikeModel
    {
        public long CurrentUserId { get; set; }

        public string CurrentUserName { get; set; }

        public long ReceiverId { get; set; }
    }
}
