using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaSongERP.ViewModels
{
    public class PagedListViewModel : ViewModel
    {
        public string OrderBy { get; set; }

        public bool OrderByDesc { get; set; }
    }
}
