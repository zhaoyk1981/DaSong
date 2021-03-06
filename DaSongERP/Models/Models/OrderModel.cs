﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaSongERP.Models
{
    public class OrderModel : Model
    {
        public Guid? ID { get; set; }

        public int? RowIndex { get; set; }

        public int? RowNumber
        {
            get
            {
                return RowIndex.HasValue
                           ? RowIndex.Value + 1
                           : default(int?);
            }
        }

        public bool? 高亮 { get; set; }

        public DateTime? 进货日期 { get; set; }

        public string Str进货日期
        {
            get
            {
                return this.进货日期.HasValue
                           ? this.进货日期.Value.ToString("yyyy-MM-dd HH:mm")
                           : string.Empty;
            }
        }

        public string 货号 { get; set; }

        public string 规格 { get; set; }

        public Guid? 库存商品ID { get; set; }

        public string 商品图片 { get; set; }

        public int? 进货数量 { get; set; }

        public int? 入库数量 { get; set; }

        public int 待入库数量
        {
            get { return 进货数量.GetValueOrDefault() - 入库数量.GetValueOrDefault(); }
        }

        public string 店铺 { get; set; }

        public string 店铺名称 { get; set; }

        public string 京东仓 { get; set; }

        public string JD订单号 { get; set; }

        public string 客人姓名 { get; set; }

        public string 客人电话 { get; set; }
        public string 客人地址 { get; set; }

        public string 淘宝账号 { get; set; }

        public string 淘宝订单号 { get; set; }

        public string 采购备注 { get; set; }

        public string 订单修改备注 { get; set; }

        public string 来快递 { get; set; }

        public string 来快递单号 { get; set; }

        public string Baidu来快递单号
        {
            get
            {
                var list = (来快递单号 ?? string.Empty).Split(" ,;".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                                                  .Select(m => m.Replace("\"", "")
                                                                .Trim())
                                                  .Select(m => $"<a target=\"_blank\" href=\"https://www.baidu.com/s?wd={m}\">{m}</a>")
                                                  .ToList();

                return string.Join("<br/>", list);
            }
        }

        public DateTime? 发货时间 { get; set; }

        public string 发货备注 { get; set; }

        public UserModel 跟进人 { get; set; }

        public Guid? 跟进人ID
        {
            get { return this.跟进人?.ID; }
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

        public decimal? 订单金额
        {
            get
            {
                if (!京东价.HasValue || !this.进货数量.HasValue)
                {
                    return null;
                }

                return 京东价.Value * 进货数量.Value;
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
        public string 电话备注 { get; set; }

        /// <summary>
        /// 0 没找到， 1 无需导入， 2 已更新
        /// </summary>
        public int? 导入结果 { get; set; }

        public 审单操作Model 审单操作 { get; set; }

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
                    this.审单操作 = new 审单操作Model();
                }

                this.审单操作.ID = value;
            }
        }

        public string 拆包人员备注 { get; set; }

        public string 转发单号 { get; set; }

        public string Baidu转发单号
        {
            get
            {
                var list = (转发单号 ?? string.Empty).Trim().Split(" ,;".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                    .Select(m => m.Replace("\"", "").Trim())
                    .Select(m => $"<a target='_blank' id='lbl转发单号{ID}' href='https://www.baidu.com/s?wd={m.Trim()}'>{m.Trim()}</a>&nbsp;<a href='javascript: void(0)' class='btn-copy-clipboard' data-clipboard-target='#lbl转发单号{ID}'>复制</a>").ToList();
                return string.Join("<br/>", list);
            }
        }

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

        public MetaModel<Guid> 售后操作 { get; set; }

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
                    this.售后操作 = new MetaModel<Guid>();
                }

                this.售后操作.ID = value;
            }
        }

        public MetaModel<Guid> 售后原因 { get; set; }

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
                    this.售后原因 = new MetaModel<Guid>();
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

        public string 淘宝退回单号 { get; set; }

        public bool? 售后完结 { get; set; }

        public UserModel 客服 { get; set; }

        public Guid? 客服ID
        {
            get
            {
                return this.客服?.ID;
            }
            set
            {
                if (this.客服 == null)
                {
                    this.客服 = new UserModel();
                }

                this.客服.ID = value;
            }
        }

        public DateTime? 客服时间 { get; set; }

        public bool? 订单终结 { get; set; }

        public string 订单终结备注 { get; set; }

        public bool? 已跟进 { get; set; }

        public bool? 已导入 { get; set; }

        public bool? 已拆包 { get; set; }

        public string Str已拆包 => this.已拆包.GetValueOrDefault() ? "已拆包" : "未拆";


        public bool? 已售后 { get; set; }

        public bool? 自采 { get; set; }

        public bool? 现货 { get; set; }

        public decimal? 退款金额 { get; set; }

        public string 中转仓 { get; set; }

        public bool? 在途待发 { get; set; }

        public bool? 未发货退款 { get; set; }

        public bool? 换货 { get; set; }
    }
}
