using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaSongERP.Models
{
    public class 采购订单统计Model : Model
    {
        public IList<统计项Model<int>> ListBy中转仓 { get; set; }

        public IList<统计项Model<int>> ListBy状态 { get; set; }

        public IList<统计项Model<int>> ListBy员工 { get; set; }

        public string By中转仓
        {
            get
            {
                if (ListBy中转仓 == null)
                {
                    return string.Empty;
                }

                return string.Join("<br />", ListBy中转仓.Select(m => $"<b>{m.Name}:</b> {m.Count.ToString("F0")}件"));
            }
        }

        public string By状态
        {
            get
            {
                if (ListBy状态 == null)
                {
                    return string.Empty;
                }

                return string.Join("<br />", ListBy状态.Select(m => $"<b>{m.Name}:</b> {m.Count.ToString("F0")}件"));
            }
        }

        public string By员工
        {
            get
            {
                if (ListBy员工 == null)
                {
                    return string.Empty;
                }

                return string.Join("<br />", ListBy员工.Select(m => $"<b>{m.Name}:</b> {m.Count.ToString("F0")}件"));
            }
        }
    }
}
