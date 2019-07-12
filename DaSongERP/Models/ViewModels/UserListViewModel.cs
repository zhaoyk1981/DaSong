using DaSongERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YK.Model;

namespace DaSongERP.ViewModels
{
    public class UserListViewModel : PagedListViewModel
    {
        public PagedList<UserModel> Users { get; set; }
    }
}
