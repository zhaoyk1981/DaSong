using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaSongERP.Models
{
    public class OrderModel : Model
    {
        public Guid? ID { get; set; }

        public int? SN { get; set; }

        public DateTime? 进货日期 { get; set; }

        public string 货号 { get; set; }

        public string 商品图片 { get; set; }

        public int? 进货数量 { get; set; }

        public MetaModel 店铺 { get; set; }

        public Guid? 店铺ID
        {
            get
            {
                return this.店铺?.ID;
            }
            set
            {
                if (this.店铺 == null)
                {
                    this.店铺 = new MetaModel();
                }

                this.店铺.ID = value;
            }
        }

        public string JD订单号 { get; set; }

        public string 客人地址 { get; set; }

        public MetaModel 淘宝账号 { get; set; }

        public Guid? 淘宝账号ID
        {
            get
            {
                return this.淘宝账号?.ID;
            }
            set
            {
                if (this.淘宝账号 == null)
                {
                    this.淘宝账号 = new MetaModel();
                }
                this.淘宝账号.ID = value;
            }
        }

        public string 淘宝订单号 { get; set; }

        public string 采购备注 { get; set; }

        public string 订单修改备注 { get; set; }

        public string 来快递单号 { get; set; }

        public DateTime? 发货时间 { get; set; }

        public string 发货备注 { get; set; }

        public UserModel 跟进人 { get; set; }

        public Guid? 跟进人ID
        {
            get
            {
                return this.跟进人?.ID;
            }
            set
            {
                if (this.跟进人 == null)
                {
                    this.跟进人 = new UserModel();
                }

                this.跟进人.ID = value;
            }
        }

        public decimal? 京东价 { get; set; }

        public decimal? 成本价 { get; set; }

        public decimal? 进货金额
        {
            get
            {
                if (!this.进货数量.HasValue || !this.成本价.HasValue)
                {
                    return null;
                }

                return this.成本价.Value * this.进货数量.Value;
            }
        }

        public decimal? 毛利润
        {
            get
            {
                if (!this.进货金额.HasValue || !this.京东价.HasValue)
                {
                    return null;
                }

                return this.京东价.Value * this.进货数量.Value - this.进货金额.Value;
            }
        }

        public UserModel 采购人 { get; set; }

        public Guid? 采购人ID
        {
            get
            {
                return this.采购人?.ID;
            }
            set
            {
                if (this.采购人 == null)
                {
                    this.采购人 = new UserModel();
                }

                this.采购人.ID = value;
            }
        }

        public DateTime? 导入时间 { get; set; }

        public UserModel 电话客服 { get; set; }

        public Guid? 电话客服ID
        {
            get
            {
                return this.电话客服?.ID;
            }
            set
            {
                if (this.电话客服 == null)
                {
                    this.电话客服 = new UserModel();
                }

                this.电话客服.ID = value;
            }
        }
        public string 电话情况 { get; set; }

        public MetaModel 审单操作 { get; set; }

        public Guid? 审单操作ID
        {
            get
            {
                return this.审单操作?.ID;
            }
            set
            {
                if (this.审单操作 == null)
                {
                    this.审单操作 = new MetaModel();
                }

                this.审单操作.ID = value;
            }
        }

        public string 拆包人员备注 { get; set; }

        public string 转发单号 { get; set; }

        public UserModel 拆包人 { get; set; }

        public Guid? 拆包人ID
        {
            get
            {
                return this.拆包人?.ID;
            }
            set
            {
                if (this.拆包人 == null)
                {
                    this.拆包人 = new UserModel();
                }

                this.拆包人.ID = value;
            }
        }

        public DateTime? 拆包时间 { get; set; }

        public MetaModel 售后操作 { get; set; }

        public Guid? 售后操作ID
        {
            get
            {
                return this.售后操作?.ID;
            }
            set
            {
                if (this.售后操作 == null)
                {
                    this.售后操作 = new MetaModel();
                }

                this.售后操作.ID = value;
            }
        }

        public MetaModel 售后原因 { get; set; }

        public Guid? 售后原因ID
        {
            get
            {
                return this.售后原因?.ID;
            }
            set
            {
                if (this.售后原因 == null)
                {
                    this.售后原因 = new MetaModel();
                }

                this.售后原因.ID = value;
            }
        }

        public string 售后备注 { get; set; }

        public UserModel 售后人员 { get; set; }

        public Guid? 售后人员ID
        {
            get
            {
                return this.售后人员?.ID;
            }
            set
            {
                if (this.售后人员 == null)
                {
                    this.售后人员 = new UserModel();
                }

                this.售后人员.ID = value;
            }
        }

        public DateTime? 售后时间 { get; set; }

        public string 客人退回单号 { get; set; }

        public bool? 是否淘宝退回 { get; set; }

        public bool? 售后完结 { get; set; }
    }
}
