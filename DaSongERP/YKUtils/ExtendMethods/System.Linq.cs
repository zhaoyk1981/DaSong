using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace YK
{
    public static class SystemLinqExtendMethods
    {
        public static IOrderedQueryable<TSource> SortBy<TSource, TKey>(this IQueryable<TSource> source, Expression<Func<TSource, TKey>> keySelector, bool isDesc = false)
        {
            if (isDesc)
            {
                return source.OrderByDescending(keySelector);
            }

            return source.OrderBy(keySelector);
        }

        public static IOrderedQueryable<TSource> ThenSortBy<TSource, TKey>(this IOrderedQueryable<TSource> source, Expression<Func<TSource, TKey>> keySelector, bool isDesc = false)
        {
            if (isDesc)
            {
                return source.ThenByDescending(keySelector);
            }

            return source.ThenBy(keySelector);
        }

        
    }
}
