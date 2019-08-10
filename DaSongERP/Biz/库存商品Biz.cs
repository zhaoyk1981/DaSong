using DaSongERP.Conditions;
using DaSongERP.Models;
using DaSongERP.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YK.Model;

namespace DaSongERP.Biz
{
    public class 库存商品Biz : Biz
    {

        public 库存商品ListViewModel Get库存商品ListViewModel()
        {
            var vm = new 库存商品ListViewModel();
            vm.ModelList = new PagedList<库存商品Model>();
            vm.ModelList.PageSize = 100;
            vm.仓库DataSource = this.MetaDao.GetAll中转仓();
            return vm;
        }

        public PagedList<库存商品Model> Get库存商品List(库存商品Condition condition)
        {
            var list = this.库存商品Dao.Get库存商品List(condition);
            return list;
        }

        public int Create库存商品(库存商品Model model)
        {
            model.ID = Guid.NewGuid();
            var rowCount = this.库存商品Dao.Create库存商品(model);
            return rowCount;
        }

        public int Update库存商品(库存商品Model model)
        {
            var rowCount = this.库存商品Dao.Update库存商品(model);
            return rowCount;
        }

        public int Delete库存商品(Guid id)
        {
            var rowCount = this.库存商品Dao.Delete库存商品(id);
            return rowCount;
        }

        public Edit库存商品ViewModel GetNew库存商品ViewModel()
        {
            var vm = new Edit库存商品ViewModel();
            vm.仓库DataSource = this.MetaDao.GetAll中转仓();
            return vm;
        }

        public Edit库存商品ViewModel GetEdit库存商品ViewModel(Guid id)
        {
            var vm = new Edit库存商品ViewModel();
            vm.EditModel = 库存商品Dao.Get库存商品By(id);
            vm.仓库DataSource = this.MetaDao.GetAll中转仓();
            return vm;
        }

        public IList<库存商品Model> Get库存商品By(库存商品Condition condition)
        {
            var list = this.库存商品Dao.Get库存商品By(condition);
            return list;
        }

        public IList<ListItemModel> Get规格Options(库存商品Condition condition)
        {
            var list = this.Get库存商品By(condition);
            var options = list.Select(m => new ListItemModel()
            {
                Text = $"{m.规格} 现货:{m.现货数量.GetValueOrDefault()} 在途:{m.在途数量.GetValueOrDefault()} 虚拟:{m.虚拟数量.GetValueOrDefault()}",
                Value = m.规格
            }).ToList();

            if (options.Count == 0)
            {
                options.Add(new ListItemModel()
                {
                    Text = "无",
                    Value = string.Empty
                });
            }
            return options;
        }

        public int Save库存动量(库存动量Model model)
        {
            if (!model.库存商品ID.HasValue)
            {
                return 0;
            }

            model.UserID = this.UserID;
            return this.库存商品Dao.Save库存动量(model);
        }

        public int 现货动量(OrderModel order)
        {
            if (!order.现货.GetValueOrDefault())
            {
                return 0;
            }

            var model = new 库存动量Model()
            {
                OrderID = order.ID,
                Remark = "现货卖出",
                现货数量 = -order.进货数量.GetValueOrDefault(),
                库存商品ID = order.库存商品ID
            };

            return this.Save库存动量(model);
        }

        public int 自采在途动量(OrderModel order)
        {
            if (!order.自采.GetValueOrDefault())
            {
                return 0;
            }

            var model = new 库存动量Model()
            {
                OrderID = order.ID,
                Remark = "自采在途",
                在途数量 = order.进货数量.GetValueOrDefault(),
                库存商品ID = order.库存商品ID
            };

            return this.Save库存动量(model);
        }

        public int 自采入库动量(OrderModel order)
        {
            if (!order.自采.GetValueOrDefault())
            {
                return 0;
            }

            var model = new 库存动量Model()
            {
                OrderID = order.ID,
                Remark = "拆包审单入库",
                在途数量 = order.进货数量.GetValueOrDefault() - order.入库数量.GetValueOrDefault(),
                现货数量 = order.入库数量.GetValueOrDefault(),
                库存商品ID = order.库存商品ID
            };

            return this.Save库存动量(model);
        }
    }
}
