using DaSongERP.Conditions;
using DaSongERP.Models;
using DaSongERP.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using YK.Model;

namespace DaSongERP.Biz
{
    public class 统计Biz : Biz
    {
        public 拆包审单统计Model 统计日拆包审单数量(DateTime? date = null)
        {
            var dateStart = date.GetValueOrDefault(DateTime.Now).Date;
            var dateEnd = dateStart.AddDays(1);
            return this.统计Dao.统计拆包审单数量(dateStart, dateEnd);
        }

        public 拆包审单统计Model 统计月拆包审单数量(DateTime? date = null)
        {
            var dateStart = date.GetValueOrDefault(DateTime.Now).Date;
            dateStart = new DateTime(dateStart.Year, dateStart.Month, 1);
            var dateEnd = dateStart.AddMonths(1);
            return this.统计Dao.统计拆包审单数量(dateStart, dateEnd);
        }

        public 采购订单统计Model 统计日采购订单(DateTime? date = null)
        {
            var dateStart = date.GetValueOrDefault(DateTime.Now).Date;
            var dateEnd = dateStart.AddDays(1);
            return this.统计Dao.统计采购订单(dateStart, dateEnd);
        }

        public 采购订单统计Model 统计月采购订单(DateTime? date = null)
        {
            var dateStart = date.GetValueOrDefault(DateTime.Now).Date;
            dateStart = new DateTime(dateStart.Year, dateStart.Month, 1);
            var dateEnd = dateStart.AddMonths(1);
            return this.统计Dao.统计采购订单(dateStart, dateEnd);
        }
    }
}
