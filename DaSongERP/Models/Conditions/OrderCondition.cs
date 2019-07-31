using DaSongERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YK.Model;

namespace DaSongERP.Conditions
{
    public class OrderCondition : PagingCondition
    {
        public OrderCondition() : base()
        {
        }

        public Guid? ID { get; set; }

        public int? SN { get; set; }

        public DateTime? 进货日期 { get; set; }

        public string 货号 { get; set; }

        public string 商品图片 { get; set; }

        public int? 进货数量 { get; set; }

        public Guid? 店铺ID { get; set; }

        public string JD订单号 { get; set; }

        public string 客人姓名 { get; set; }

        public string 客人电话 { get; set; }

        public string 客人地址 { get; set; }

        public Guid? 淘宝账号ID { get; set; }

        public string 淘宝订单号 { get; set; }

        public string 采购备注 { get; set; }

        public string 订单修改备注 { get; set; }

        public string 来快递单号 { get; set; }

        public DateTime? 发货时间 { get; set; }

        public string 发货备注 { get; set; }

        public Guid? 跟进人ID { get; set; }

        public decimal? 京东价 { get; set; }

        public decimal? 成本价 { get; set; }

        public Guid? 采购人ID { get; set; }

        public DateTime? 导入时间 { get; set; }

        public Guid? 电话客服ID { get; set; }
        public string 电话情况 { get; set; }

        /// <summary>
        /// 0 没找到， 1 无需导入， 2 已更新
        /// </summary>
        public int? 导入结果 { get; set; }

        public Guid? 审单操作ID { get; set; }

        public string 拆包人员备注 { get; set; }

        public string 转发单号 { get; set; }

        public Guid? 拆包人ID { get; set; }

        public DateTime? 拆包时间 { get; set; }

        public Guid? 售后操作ID { get; set; }

        public Guid? 售后原因ID { get; set; }

        public string 售后备注 { get; set; }

        public Guid? 售后人员ID { get; set; }

        public DateTime? 售后时间 { get; set; }

        public string 客人退回单号 { get; set; }

        public bool? 是否淘宝退回 { get; set; }

        public bool? 售后完结 { get; set; }

        public Guid? 客服ID { get; set; }

        public DateTime? 客服时间 { get; set; }

        public int? RowIndex { get; set; }

        public bool? 已跟进 { get; set; }

        public bool? 已导入 { get; set; }

        public bool? 已拆包 { get; set; }

        public bool? 已售后 { get; set; }

        public bool? Search { get; set; }

        public int? 拆包超时 { get; set; }

        public bool? My { get; set; }

        public void Trim()
        {
            JD订单号 = string.IsNullOrEmpty(JD订单号) ? default(string) : JD订单号;
            客人地址 = string.IsNullOrEmpty(客人地址) ? default(string) : 客人地址;
            来快递单号 = string.IsNullOrEmpty(来快递单号) ? default(string) : 来快递单号;
        }

        public bool? 自采 { get; set; }

        public bool? 高亮 { get; set; }
    }
}
