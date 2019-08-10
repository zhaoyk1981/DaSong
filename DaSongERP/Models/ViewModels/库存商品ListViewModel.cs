using DaSongERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YK.Model;

namespace DaSongERP.ViewModels
{
    public class 库存商品ListViewModel : PagedListViewModel
    {
        public PagedList<库存商品Model> ModelList { get; set; }

        public IList<MetaModel<Guid>> 仓库DataSource { get; set; }
    }
}
