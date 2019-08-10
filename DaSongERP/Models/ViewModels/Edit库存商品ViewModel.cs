using DaSongERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaSongERP.ViewModels
{
    public class Edit库存商品ViewModel : ViewModel
    {
        public 库存商品Model EditModel { get; set; }

        public IList<MetaModel<Guid>> 仓库DataSource { get; set; }
    }
}
