using DaSongERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaSongERP.ViewModels
{
    public class EditUserViewModel : ViewModel
    {
        public UserModel User { get; set; }

        public IList<PermissionModel> PermissionDataSource { get; set; }
    }
}
