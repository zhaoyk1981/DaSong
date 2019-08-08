using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaSongERP.Models
{
    public class 审单操作Model : MetaModel<Guid>
    {
        public bool? 已完成 { get; set; }

        public string Str已完成
        {
            get
            {
                return this.已完成.GetValueOrDefault() ? "是" : "否";
            }
        }
    }
}
