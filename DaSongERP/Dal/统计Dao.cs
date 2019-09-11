using DaSongERP.Conditions;
using DaSongERP.Models;
using DaSongERP.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YK;
using YK.Model;
using YK.Mappers;

namespace DaSongERP.Dal
{
    public class 统计Dao : Dao
    {
        public 拆包审单统计Model 统计拆包审单数量(DateTime dateStart, DateTime dateEnd)
        {
            var vm = new 拆包审单统计Model();
            var cmd = ProcCommands.sp_统计拆包审单数量().SetParameterValues(new
            {
                DateStart = dateStart.Date,
                DateEnd = dateEnd.Date
            });
            var ds = DBHelper.ExecuteDataSet(cmd);
            vm.ListByUser = DbMapperUtil.Map<统计项Model<int>>(ds.Tables[0]);
            vm.ListByStatus = DbMapperUtil.Map<统计项Model<int>>(ds.Tables[1]);
            return vm;
        }

        public IList<统计项Model<int>> 统计每日未拆包审单()
        {
            var cmd = ProcCommands.sp_统计每日未拆包审单();
            var list = DBHelper.ExecuteEntityList<统计项Model<int>>(cmd);
            return list;
        }

        public 采购订单统计Model 统计采购订单(DateTime dateStart, DateTime dateEnd)
        {
            var m = new 采购订单统计Model();
            var cmd = ProcCommands.sp_统计采购订单().SetParameterValues(new
            {
                DateStart = dateStart.Date,
                DateEnd = dateEnd.Date
            });
            var ds = DBHelper.ExecuteDataSet(cmd);
            m.ListBy中转仓 = DbMapperUtil.Map<统计项Model<int>>(ds.Tables[0]);
            m.ListBy状态 = new List<统计项Model<int>>();
            m.ListBy状态.Add(DbMapperUtil.Map<统计项Model<int>>(ds.Tables[1]).FirstOrDefault());
            m.ListBy状态.Add(DbMapperUtil.Map<统计项Model<int>>(ds.Tables[2]).FirstOrDefault());
            m.ListBy状态.Add(DbMapperUtil.Map<统计项Model<int>>(ds.Tables[3]).FirstOrDefault());
            m.ListBy状态.Add(DbMapperUtil.Map<统计项Model<int>>(ds.Tables[4]).FirstOrDefault());
            m.ListBy状态.Add(DbMapperUtil.Map<统计项Model<int>>(ds.Tables[5]).FirstOrDefault());
            m.ListBy状态.Add(DbMapperUtil.Map<统计项Model<int>>(ds.Tables[6]).FirstOrDefault());
            m.ListBy员工 = DbMapperUtil.Map<统计项Model<int>>(ds.Tables[7]);
            return m;
        }

        public 销售统计Model 统计销售额(销售统计Condition condition)
        {
            var cmd = ProcCommands.sp_销售统计().SetParameterValues(condition);
            var m = DBHelper.ExecuteEntityList<销售统计Model>(cmd).FirstOrDefault();
            return m;
        }

        public PagedList<热销商品统计Model> 统计热销商品(热销商品统计Condition condition)
        {
            var cmd = ProcCommands.sp_统计热销商品().SetParameterValues(condition);
            var dataSet = DBHelper.ExecuteDataSet(cmd);
            var pagedList = new PagedList<热销商品统计Model>(condition, dataSet);
            var 库存商品List = DbMapperUtil.Map<库存商品Model>(dataSet.Tables[2]);
            foreach (var m in pagedList.DataSource)
            {
                var g = 库存商品List.FirstOrDefault(n => n.货号 == m.货号);
                if (g != null)
                {
                    m.Thumbnails = g.Thumbnails;
                    m.现货数量 = g.现货数量;
                    m.在途数量 = g.在途数量;
                }
            }

            return pagedList;
        }
    }
}
