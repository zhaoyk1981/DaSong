using DaSongERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YK;
using YK.Model;

namespace DaSongERP.ViewModels
{
    public class MetaListViewModel : PagedListViewModel
    {
        public PagedList<MetaModel<Guid>> MetaList { get; set; }
    }
}
