using DaSongERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaSongERP.Biz
{
    public class StockBiz : Biz
    {
        public StockModel Get库存(string 货号)
        {
            return StockDao.Get库存(货号) ?? new StockModel()
            {
                货号 = 货号,
                在途数量 = 0,
                库存数量 = 0
            };
        }
    }
}
