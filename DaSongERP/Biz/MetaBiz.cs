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
    }
}
