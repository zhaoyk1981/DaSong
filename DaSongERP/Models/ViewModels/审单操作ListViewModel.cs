using DaSongERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YK.Model;

namespace DaSongERP.ViewModels
{
    public class 审单操作ListViewModel : PagedListViewModel
    {
        public PagedList<审单操作Model> MetaList { get; set; }
    }
}
