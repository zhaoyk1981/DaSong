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
    public class MetaBiz : Biz
    {

        public IList<MetaModel<Guid>> Get店铺()
        {
            return this.MetaDao.Get店铺();
        }

        public IList<MetaModel<Guid>> Get审单操作()
        {
            return this.MetaDao.Get审单操作();
        }

        public IList<MetaModel<Guid>> Get售后操作()
        {
            return this.MetaDao.Get售后操作();
        }

        public IList<MetaModel<Guid>> Get售后原因()
        {
            return this.MetaDao.Get售后原因();
        }

        public IList<MetaModel<Guid>> Get淘宝账号()
        {
            return this.MetaDao.Get淘宝账号();
        }

        public MetaListViewModel Get审单操作ListViewModel()
        {
            var vm = new MetaListViewModel();
            vm.MetaList = new PagedList<MetaModel<Guid>>();
            vm.MetaList.PageSize = 300;
            return vm;
        }

        public PagedList<MetaModel<Guid>> Get审单操作List(MetaCondition condition)
        {
            var list = this.MetaDao.Get审单操作List(condition);
            return list;
        }

        public int Create审单操作(MetaModel<Guid> meta)
        {
            meta.ID = Guid.NewGuid();
            var rowCount = this.MetaDao.Create审单操作(meta);
            return rowCount;
        }

        public int Update审单操作(MetaModel<Guid> meta)
        {
            var rowCount = this.MetaDao.Update审单操作(meta);
            return rowCount;
        }

        public int Delete审单操作(Guid id)
        {
            var rowCount = this.MetaDao.Delete审单操作(id);
            return rowCount;
        }

        public EditMetaViewModel GetNew审单操作ViewModel()
        {
            var vm = new EditMetaViewModel();
            return vm;
        }

        public EditMetaViewModel GetEdit审单操作ViewModel(Guid id)
        {
            var vm = new EditMetaViewModel();
            vm.Meta = MetaDao.Get审单操作By(id);
            return vm;
        }



        public MetaListViewModel Get售后操作ListViewModel()
        {
            var vm = new MetaListViewModel();
            vm.MetaList = new PagedList<MetaModel<Guid>>();
            vm.MetaList.PageSize = 300;
            return vm;
        }

        public PagedList<MetaModel<Guid>> Get售后操作List(MetaCondition condition)
        {
            var list = this.MetaDao.Get售后操作List(condition);
            return list;
        }

        public int Create售后操作(MetaModel<Guid> meta)
        {
            meta.ID = Guid.NewGuid();
            var rowCount = this.MetaDao.Create售后操作(meta);
            return rowCount;
        }

        public int Update售后操作(MetaModel<Guid> meta)
        {
            var rowCount = this.MetaDao.Update售后操作(meta);
            return rowCount;
        }

        public int Delete售后操作(Guid id)
        {
            var rowCount = this.MetaDao.Delete售后操作(id);
            return rowCount;
        }

        public EditMetaViewModel GetNew售后操作ViewModel()
        {
            var vm = new EditMetaViewModel();
            return vm;
        }

        public EditMetaViewModel GetEdit售后操作ViewModel(Guid id)
        {
            var vm = new EditMetaViewModel();
            vm.Meta = MetaDao.Get售后操作By(id);
            return vm;
        }


        public MetaListViewModel Get售后原因ListViewModel()
        {
            var vm = new MetaListViewModel();
            vm.MetaList = new PagedList<MetaModel<Guid>>();
            vm.MetaList.PageSize = 300;
            return vm;
        }

        public PagedList<MetaModel<Guid>> Get售后原因List(MetaCondition condition)
        {
            var list = this.MetaDao.Get售后原因List(condition);
            return list;
        }

        public int Create售后原因(MetaModel<Guid> meta)
        {
            meta.ID = Guid.NewGuid();
            var rowCount = this.MetaDao.Create售后原因(meta);
            return rowCount;
        }

        public int Update售后原因(MetaModel<Guid> meta)
        {
            var rowCount = this.MetaDao.Update售后原因(meta);
            return rowCount;
        }

        public int Delete售后原因(Guid id)
        {
            var rowCount = this.MetaDao.Delete售后原因(id);
            return rowCount;
        }

        public EditMetaViewModel GetNew售后原因ViewModel()
        {
            var vm = new EditMetaViewModel();
            return vm;
        }

        public EditMetaViewModel GetEdit售后原因ViewModel(Guid id)
        {
            var vm = new EditMetaViewModel();
            vm.Meta = MetaDao.Get售后原因By(id);
            return vm;
        }


        public MetaListViewModel Get中转仓ListViewModel()
        {
            var vm = new MetaListViewModel();
            vm.MetaList = new PagedList<MetaModel<Guid>>();
            vm.MetaList.PageSize = 300;
            return vm;
        }

        public PagedList<MetaModel<Guid>> Get中转仓List(MetaCondition condition)
        {
            var list = this.MetaDao.Get中转仓List(condition);
            return list;
        }

        public int Create中转仓(MetaModel<Guid> meta)
        {
            meta.ID = Guid.NewGuid();
            var rowCount = this.MetaDao.Create中转仓(meta);
            return rowCount;
        }

        public int Update中转仓(MetaModel<Guid> meta)
        {
            var rowCount = this.MetaDao.Update中转仓(meta);
            return rowCount;
        }

        public int Delete中转仓(Guid id)
        {
            var rowCount = this.MetaDao.Delete中转仓(id);
            return rowCount;
        }

        public EditMetaViewModel GetNew中转仓ViewModel()
        {
            var vm = new EditMetaViewModel();
            return vm;
        }

        public EditMetaViewModel GetEdit中转仓ViewModel(Guid id)
        {
            var vm = new EditMetaViewModel();
            vm.Meta = MetaDao.Get中转仓By(id);
            return vm;
        }

        public EditShopViewModel GetNewShopViewModel()
        {
            var vm = new EditShopViewModel();
            return vm;
        }

        public EditShopViewModel GetEditShopViewModel(Guid id)
        {
            var vm = new EditShopViewModel();
            vm.Shop = MetaDao.Get店铺By(id);
            return vm;
        }

        public 店铺ListViewModel Get店铺ListViewModel()
        {
            var vm = new 店铺ListViewModel();
            vm.Shops = new PagedList<店铺Model>();
            vm.Shops.PageSize = 300;
            return vm;
        }

        public PagedList<店铺Model> Get店铺List(ShopCondition condition)
        {
            return this.MetaDao.Get店铺List(condition);
        }

        public int Create店铺(店铺Model shop)
        {
            shop.ID = Guid.NewGuid();
            var rowCount = this.MetaDao.Create店铺(shop);
            return rowCount;
        }

        public int Update店铺(店铺Model shop)
        {
            var rowCount = this.MetaDao.Update店铺(shop);
            return rowCount;
        }

        public int Delete店铺(Guid id)
        {
            var rowCount = this.MetaDao.Delete店铺(id);
            return rowCount;
        }

        //public 店铺Model Get店铺By(Guid id)
        //{
        //    return this.MetaDao.Get店铺By(id);
        //}

        //public IList<店铺Model> GetAll店铺()
        //{
        //    return this.MetaDao.GetAll店铺();
        //}

        public IList<快递Model> GetAll快递()
        {
            return MetaDao.GetAll快递();
        }
    }
}
