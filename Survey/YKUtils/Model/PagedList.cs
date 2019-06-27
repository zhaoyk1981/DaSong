using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YK.Mappers;

namespace YK.Model
{
    public class PagedList<T>
        where T : new()
    {
        public PagedList(PagingCondition condition = null, DataSet ds = null)
        {
            if (condition != null)
            {
                this.TimeStamp = condition.TimeStamp;
                this.PageSize = condition.PageSize;
                this.PageIndex = condition.PageIndex.GetValueOrDefault();
                this.PageById = condition.PageById?.ToString();
                this.OrderBy = condition.OrderBy;
                this.OrderByDesc = condition.OrderByDesc;
            }

            this.SetData(ds);
        }

        public long TimeStamp { get; set; }

        public int RecordsCount { get; set; }

        public int PageSize { get; set; }

        public int PageIndex { get; set; }

        public int PageNumber
        {
            get
            {
                return Math.Max(this.PageIndex, 0) + 1;
            }
        }

        public string PageById { get; set; }

        public int DataSourceCount
        {
            get
            {
                return (this.DataSource?.Count).GetValueOrDefault();
            }
        }

        public int PagesCount
        {
            get
            {
                var c = 0;
                if (this.PageSize <= 1)
                {
                    c = this.RecordsCount;
                }
                else
                {
                    c = Convert.ToInt32(Math.Ceiling((double)this.RecordsCount / this.PageSize));
                }

                return Math.Max(c, 1);
            }
        }

        public int RecordNumberStart
        {
            get
            {
                if (this.RecordsCount == 0)
                {
                    return 0;
                }

                var n = this.PageIndex * this.PageSize + 1;
                return Math.Max(n, 0);
            }
        }

        public int RecordNumberEnd
        {
            get
            {
                if (this.RecordsCount == 0)
                {
                    return 0;
                }

                var n = this.RecordNumberStart + this.DataSourceCount - 1;
                return Math.Max(n, 0);
            }
        }

        public bool Paged { get; set; }

        public IList<T> DataSource { get; set; }

        public IList<Guid> IDList { get; set; }

        public void Page()
        {
            if (!this.Paged)
            {
                this.RecordsCount = this.DataSourceCount;
                if (this.PageSize <= 0)
                {
                    return;
                }

                if (this.PageIndex < 0)
                {
                    this.PageIndex = Math.Max(this.PagesCount + this.PageIndex, 0);
                }

                this.PageIndex = Math.Min(this.PageIndex, this.PagesCount - 1);
                this.PageIndex = Math.Max(this.PageIndex, 0);
                this.DataSource = this.DataSource.Skip(this.PageIndex * this.PageSize).Take(this.PageSize).ToList();
                this.Paged = true;
            }
        }

        public Object ToJsonObj(Func<T, object> selector)
        {
            return new
            {
                draw = this.TimeStamp,
                recordsCount = this.RecordsCount,
                recordNumberStart = this.RecordNumberStart,
                recordNumberEnd = this.RecordNumberEnd,
                pageSize = this.PageSize,
                pageIndex = this.PageIndex,
                dataSourceCount = this.DataSourceCount,
                pagesCount = this.PagesCount,
                dataSource = this.DataSource.Select(selector).ToArray()
            };
        }

        public void SetData(DataSet ds)
        {
            if (ds == null)
            {
                this.DataSource = new List<T>();
                this.PageIndex = 0;
                this.RecordsCount = 0;
                this.IDList = new List<Guid>();
                return;
            }

            this.DataSource = DbMapperUtil.Map<T>(ds.Tables[0]);
            var pagingInfo = ds.Tables[1].Rows[0];
            this.PageIndex = (pagingInfo["PageIndex"] as int?).GetValueOrDefault();
            this.RecordsCount = (pagingInfo["RecordsCount"] as int?).GetValueOrDefault();
            this.PageSize = (pagingInfo["PageSize"] as int?).GetValueOrDefault();
            if (ds.Tables.Count > 2)
            {
                this.IDList = DbMapperUtil.MapGuidList(ds.Tables[2]);
            }
            else
            {
                this.IDList = new List<Guid>();
            }
        }

        public string OrderBy { get; set; }

        public bool OrderByDesc { get; set; }

        public object GetCurrentSortPaging()
        {
            return new
            {
                PageIndex = this.PageIndex,
                PageSize = this.PageSize,
                PagesCount = this.PagesCount,
                OrderBy = this.OrderBy,
                OrderByDesc = this.OrderByDesc,
                RecordsCount = this.RecordsCount,
                RecordNumberStart = this.RecordNumberStart,
                RecordNumberEnd = this.RecordNumberEnd,
                DataSourceCount = this.DataSourceCount
            };
        }
    }
}
