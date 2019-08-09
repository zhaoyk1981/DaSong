using DaSongERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaSongERP.ViewModels
{
    public class 拆包审单统计ViewModel : ViewModel
    {
        public IList<统计项Model<int>> ListByUser { get; set; }

        public IList<统计项Model<int>> ListByStatus { get; set; }
    }
}
