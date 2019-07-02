using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YK
{
    public static class SystemCollectionsGeneric
    {
        public static DataTable ToDataTable<T>(this IList<T> list)
            where T : struct
        {
            var dt = new DataTable();
            dt.Columns.Add("Id", typeof(T));
            foreach (T itm in list)
            {
                var row = dt.NewRow();
                row[0] = itm;
                dt.Rows.Add(row);
            }

            return dt;
        }
    }
}
