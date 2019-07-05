using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaSongERP.Models
{
    public class UserModel : Model
    {
        public Guid? ID { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string Name { get; set; }

        public int? PermissionID { get; set; }

        public string 权限 { get; set; }
    }
}
