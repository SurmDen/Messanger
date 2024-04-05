using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManager.Helpers
{
    public class NoticeModel
    {
        public long CurrentUserId { get; set; }

        public string CurrentUserName { get; set; }

        public string Context { get; set; }

        public long TargetUserId { get; set; }
    }
}
