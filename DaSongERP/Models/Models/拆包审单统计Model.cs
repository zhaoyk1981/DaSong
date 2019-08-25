using DaSongERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaSongERP.Models
{
    public class 拆包审单统计Model : Model
    {
        public IList<统计项Model<int>> ListByUser { get; set; }

        public IList<统计项Model<int>> ListByStatus { get; set; }

        public string By员工
        {
            get
            {
                if(ListByUser == null)
                {
                    return string.Empty;
                }

                return string.Join("<br />", ListByUser.Select(m => $"<b>{m.Name}:</b> {m.Count.ToString("F0")}件"));
            }
        }

        public string By状态
        {
            get
            {
                if (ListByStatus == null)
                {
                    return string.Empty;
                }

                return string.Join("<br />", ListByStatus.Select(m => $"<b>{m.Name}:</b> {m.Count.ToString("F0")}件"));
            }
        }
    }
}
