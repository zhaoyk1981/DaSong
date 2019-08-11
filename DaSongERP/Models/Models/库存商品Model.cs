using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaSongERP.Models
{
    public class 库存商品Model : Model
    {
        public Guid? ID { get; set; }

        public string 货号 { get; set; }

        public string 规格 { get; set; }

        public string Name { get; set; }

        public string Thumbnails { get; set; }

        public string 仓库 { get; set; }

        public string 库位 { get; set; }

        public int? 现货数量 { get; set; }

        public int? 在途数量 { get; set; }

        public int? 虚拟数量 { get; set; }

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
                return this.User?.Name;
            }
        }

        public DateTime? DateCreated { get; set; }

        public string StrDateCreated
        {
            get
            {
                return DateCreated.HasValue ? DateCreated.Value.ToString("yyyy-M-d H:mm:ss") : string.Empty;
            }
        }
    }
}
