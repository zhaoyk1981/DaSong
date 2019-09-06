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
            model.UserID = this.UserID;
            var rowCount = this.库存商品Dao.Create库存商品(model);
            return rowCount;
        }

        public int Update库存商品(库存商品Model model)
        {
            model.UserID = this.UserID;
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
                    Text = "此商品不在库存商品中",
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

        public int 现货动量(OrderModel order, bool update = false)
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

            var kc = this.库存商品Dao.Get库存商品By(order.库存商品ID.Value);
            if (kc == null)
            {
                throw new Exception("现货动量：库存商品不存在");
            }

            if (order.进货数量.GetValueOrDefault() > kc.虚拟数量.GetValueOrDefault())
            {
                if (update)
                {
                    OrderDao.UpdateOrder高亮(order.ID.Value, true);
                }
                else
                {
                    OrderDao.DeleteOrder(order.ID.Value);
                }

                throw new Exception("现货动量：采购数量大于虚拟数量");
            }

            if (order.进货数量.GetValueOrDefault() > kc.现货数量.GetValueOrDefault())
            {
                this.OrderDao.UpdateOrder在途待发(order.ID.Value, true);
            }

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

        public int 入库动量(OrderModel order)
        {
            var model = new 库存动量Model()
            {
                OrderID = order.ID,
                Remark = "拆包审单入库",
                在途数量 = Math.Max(0, order.进货数量.GetValueOrDefault() - order.入库数量.GetValueOrDefault()),
                现货数量 = order.入库数量.GetValueOrDefault(),
                库存商品ID = order.库存商品ID
            };

            return this.Save库存动量(model);
        }

        public Edit库存动量ViewModel GetEdit库存动量ViewModel(Guid id)
        {
            var vm = new Edit库存动量ViewModel();
            vm.库存商品 = this.库存商品Dao.Get库存商品By(id);
            return vm;
        }

        public 库存动量ListViewModel Get库存动量ListViewModel(Guid id)
        {
            var vm = new 库存动量ListViewModel();
            vm.库存商品 = this.库存商品Dao.Get库存商品By(id);
            vm.ModelList = new PagedList<库存动量Model>();
            vm.ModelList.PageSize = 100;
            return vm;
        }

        public PagedList<库存动量Model> Get库存动量List(库存动量Condition condition)
        {
            var list = this.库存商品Dao.Get库存动量List(condition);
            return list;
        }
    }
}
