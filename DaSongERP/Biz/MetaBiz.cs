using DaSongERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
