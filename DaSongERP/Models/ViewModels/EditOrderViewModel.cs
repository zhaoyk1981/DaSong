using DaSongERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaSongERP.ViewModels
{
    public class EditOrderViewModel : ViewModel
    {
        public IList<MetaModel> 店铺DataSource { get; set; }
        public IList<MetaModel> 淘宝账号DataSource { get; set; }

        public IList<MetaModel> 审单操作DataSource { get; set; }

        public OrderModel Order { get; set; }

    }
}
