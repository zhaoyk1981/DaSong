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
        public IList<审单操作Model> 审单操作DataSource { get; set; }

        public IList<MetaModel<Guid>> 售后操作DataSource { get; set; }

        public IList<MetaModel<Guid>> 售后原因DataSource { get; set; }

        public IList<快递Model> 来快递DataSource { get; set; }

        public IList<MetaModel<Guid>> 中转仓DataSource { get; set; }

        public OrderModel Order { get; set; }

    }
}
