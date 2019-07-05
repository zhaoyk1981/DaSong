using DaSongERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaSongERP.ViewModels
{
    public class UserListViewModel : ViewModel
    {
        public string Search { get; set; }
        public IList<UserModel> Users { get; set; }
    }
}
