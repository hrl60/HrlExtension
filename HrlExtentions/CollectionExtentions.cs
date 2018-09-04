using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HrlExtentions
{
    public static class CollectionExtentions
    {
        /// <summary>
        /// Check object is in list
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="list"></param>
        /// <returns></returns>
        public static bool In<T>(this T source, params T[] list)
        {
            if (null == source) throw new ArgumentNullException("source");
            return list.Contains(source);
        }
        /// <summary>
        /// Check Object value is between 2 value
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="actual"></param>
        /// <param name="lower"></param>
        /// <param name="upper"></param>
        /// <returns></returns>
        public static bool Between<T>(this T actual, T lower, T upper) where T : IComparable<T>
        {
            return actual.CompareTo(lower) >= 0 && actual.CompareTo(upper) < 0;
        }
        #region Sort
        private static IOrderedQueryable<T> OrderingHelper<T>(IQueryable<T> source, string propertyName, bool descending, bool anotherLevel)
        {
            var param = Expression.Parameter(typeof(T), "p");
            var property = Expression.PropertyOrField(param, propertyName);
            var sort = Expression.Lambda(property, param);

            var call = Expression.Call(
                typeof(Queryable),
                (!anotherLevel ? "OrderBy" : "ThenBy") + (descending ? "Descending" : string.Empty),
                new[] { typeof(T), property.Type },
                source.Expression,
                Expression.Quote(sort));

            return (IOrderedQueryable<T>)source.Provider.CreateQuery<T>(call);
        }
        /// <summary>
        /// Sort Collection By Field Name
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        public static IOrderedQueryable<T> OrderBy<T>(this IQueryable<T> source, string propertyName)
        {
            return OrderingHelper(source, propertyName, false, false);
        }
        /// <summary>
        /// Sort Collection By Field Name
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="propertyName"></param>
        /// <param name="descending"></param>
        /// <returns></returns>
        public static IOrderedQueryable<T> OrderBy<T>(this IQueryable<T> source, string propertyName, bool descending)
        {
            return OrderingHelper(source, propertyName, descending, false);
        }
        /// <summary>
        /// Sort Collection By Field Name
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        public static IOrderedQueryable<T> ThenBy<T>(this IOrderedQueryable<T> source, string propertyName)
        {
            return OrderingHelper(source, propertyName, false, true);
        }
        /// <summary>
        /// Sort Collection By Field Name
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="propertyName"></param>
        /// <param name="descending"></param>
        /// <returns></returns>
        public static IOrderedQueryable<T> ThenBy<T>(this IOrderedQueryable<T> source, string propertyName, bool descending)
        {
            return OrderingHelper(source, propertyName, descending, true);
        }
        #endregion

    }
}
