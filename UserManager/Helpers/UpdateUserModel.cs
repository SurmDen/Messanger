using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManager.Helpers
{
    public class UpdateUserModel
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public string City { get; set; }

        public string Password { get; set; }
    }
}
