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

        public 销售统计ViewModel Get销售统计ViewModel()
        {
            var vm = new 销售统计ViewModel()
            {
                日期 = DateTime.Now.Date,
                运费 = 12
            };
            return vm;
        }

        public 销售统计Model 统计销售额(销售统计Condition condition)
        {
            condition.DateStart = condition.DateStart.Value.Date;
            switch (condition.DateType)
            {
                case "日":
                    condition.DateEnd = condition.DateStart.Value.AddDays(1);
                    break;
                case "月":
                    condition.DateStart = new DateTime(condition.DateStart.Value.Year, condition.DateStart.Value.Month, 1);
                    condition.DateEnd = condition.DateStart.Value.AddMonths(1);
                    break;
            }

            return this.统计Dao.统计销售额(condition);
        }

        public PagedList<热销商品统计Model> 统计热销商品(热销商品统计Condition condition)
        {
            condition.DateStart = condition.DateStart.Value.Date;
            condition.DateEnd = condition.DateEnd.Value.Date.AddDays(1);
            return this.统计Dao.统计热销商品(condition);
        }

        public 热销商品统计ViewModel Get热销商品统计ViewModel()
        {
            var vm = new 热销商品统计ViewModel()
            {
                DateStart = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1)
            };
            vm.DateEnd = vm.DateStart.Value.AddMonths(1).AddDays(-1);
            vm.List = new PagedList<热销商品统计Model>()
            {
                PageSize = 100
            };
            return vm;
        }

    }
}
