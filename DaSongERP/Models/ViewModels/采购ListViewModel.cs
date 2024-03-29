﻿using DaSongERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YK;
using YK.Model;

namespace DaSongERP.ViewModels
{
    public class 采购ListViewModel : PagedListViewModel
    {
        public PagedList<OrderModel> Orders { get; set; }

        public IList<MetaModel<Guid>> 中转仓DataSource { get; set; }

        public string 货号 { get; set; }
    }
}
