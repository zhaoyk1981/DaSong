using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaSongERP.Models
{
    public class 库存动量Model : Model
    {
        public int? ID { get; set; }

        public DateTime? DateCreated { get; set; }

        public string StrDateCreated
        {
            get
            {
                if (!DateCreated.HasValue)
                {
                    return string.Empty;
                }

                return DateCreated.Value.ToString("yyyy-M-d H:mm:ss");
            }
        }

        public 库存商品Model 库存商品 { get; set; }
        public Guid? 库存商品ID
        {
            get
            {
                return 库存商品?.ID;
            }
            set
            {
                if (库存商品 == null)
                {
                    库存商品 = new 库存商品Model();
                }

                库存商品.ID = value;
            }
        }

        public int? 现货数量 { get; set; }

        public int? 在途数量 { get; set; }

        public OrderModel Order { get; set; }
        public Guid? OrderID
        {
            get
            {
                return Order?.ID;
            }
            set
            {
                if (Order == null)
                {
                    Order = new OrderModel();
                }

                Order.ID = value;
            }
        }

        public string JD订单号
        {
            get { return this.Order?.JD订单号; }
        }

        public string Remark { get; set; }

        public UserModel User { get; set; }
        public Guid? UserID
        {
            get
            {
                return User?.ID;
            }
            set
            {
                if (User == null)
                {
                    User = new UserModel();
                }

                User.ID = value;
            }
        }

        public string UserName
        {
            get
            {
                return User?.Name;
            }
        }
    }
}
