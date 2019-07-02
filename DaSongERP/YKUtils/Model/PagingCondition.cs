using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace YK.Model
{
    public class PagingCondition
    {
        public PagingCondition()
        {
            var strDefaultPageSize = ConfigurationManager.AppSettings["DefaultPageSize"];
            if (!string.IsNullOrEmpty(strDefaultPageSize))
            {
                int pageSize;
                if (int.TryParse(ConfigurationManager.AppSettings["DefaultPageSize"], out pageSize))
                {
                    this.PageSize = pageSize;
                }
            }
        }

        public static PagingCondition ParseFromJqueryDataTables(NameValueCollection collection)
        {
            const string COLUMN_DATA = "columns[{0}][data]";
            const string COLUMN_NAME = "columns[{0}][name]";
            const string COLUMN_SEARCHABLE = "columns[{0}][searchable]";
            const string COLUMN_ORDERABLE = "columns[{0}][orderable]";
            const string COLUMN_SEARCH_VALUE = "columns[{0}][search][value]";
            const string COLUMN_SEARCH_REGEX = "columns[{0}][search][regex]";
            const string ORDER_COLUMN = "order[{0}][column]";
            const string ORDER_DIR = "order[{0}][dir]";

            var pc = new PagingCondition();
            pc.ThenByList = new List<ColumnOrder>();
            pc.Columns = new List<Column>();
            int tmp;
            if (int.TryParse(collection["draw"], out tmp))
            {
                pc.TimeStamp = tmp;
            }

            if (int.TryParse(collection["start"], out tmp))
            {
                pc.Start = tmp;
            }

            if (int.TryParse(collection["length"], out tmp))
            {
                pc.PageSize = tmp;
            }

            pc.SearchValue = collection["search[value]"];
            pc.SearchRegex = collection["search[regex]"];
            var i = 0;
            while (collection.AllKeys.Contains(string.Format(COLUMN_NAME, i)))
            {
                var col = new Column()
                {
                    Name = collection[string.Format(COLUMN_NAME, i)],
                    Data = collection[string.Format(COLUMN_DATA, i)],
                    Searchable = string.Compare(collection[string.Format(COLUMN_SEARCHABLE, i)], "true", true) == 0,
                    Orderable = string.Compare(collection[string.Format(COLUMN_ORDERABLE, i)], "true", true) == 0,
                    SearchValue = collection[string.Format(COLUMN_SEARCH_VALUE, i)],
                    SearchRegex = collection[string.Format(COLUMN_SEARCH_REGEX, i)]
                };

                pc.Columns.Add(col);
                i++;
            }

            i = 0;
            while (collection.AllKeys.Contains(string.Format(ORDER_COLUMN, i)))
            {
                var colOrder = new ColumnOrder()
                {
                    ColumnIndex = int.Parse(collection[string.Format(ORDER_COLUMN, i)]),
                    IsDesc = string.Compare(collection[string.Format(ORDER_DIR, i)], "desc", true) == 0
                };

                colOrder.ColumnName = pc.Columns[colOrder.ColumnIndex].Name;
                pc.ThenByList.Add(colOrder);
                i++;
            }

            return pc;
        }

        public long TimeStamp { get; set; }

        public string SearchValue { get; set; }

        public string SearchRegex { get; set; }

        public IList<ColumnOrder> ThenByList { get; set; } = new List<ColumnOrder>();

        public string OrderBy { get; set; }

        public bool OrderByDesc { get; set; }

        public int Start { get; set; }

        public int PageSize { get; set; }

        public int? PageIndex { get; set; }

        public object PageById { get; set; }

        public int Top
        {
            get { return this.Start + this.PageSize; }
        }

        public IList<Column> Columns { get; set; }

        public class Column
        {
            public string Data { get; set; }
            public string Name { get; set; }
            public bool Searchable { get; set; }
            public bool Orderable { get; set; }
            public string SearchValue { get; set; }
            public string SearchRegex { get; set; }
        }

        public class ColumnOrder
        {
            public int ColumnIndex { get; set; }
            public string ColumnName { get; set; }
            public bool IsDesc { get; set; }
        }
    }
}
