using oncast_taos.src.model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace oncast_taos.src
{
    public class OrderingService : IBooksOrder
    {
        public IList<Book> Order(IList<Book> books)
        {
            if (books.Count > 1)
            {
                var b = new Object();

                foreach (Order order in Configuration.Instance.Order)
                    b = (b is IOrderedEnumerable<Book>) ? ThenBy((IOrderedEnumerable<Book>)b, order) : OrderBy(books, order);

                return ((IOrderedEnumerable<Book>)b).ToList<Book>();
            }
            else
                return books;
        }

        private static object GetPropertyValue(object obj, string property)
        {
            System.Reflection.PropertyInfo propertyInfo = obj.GetType().GetProperty(property);
            return propertyInfo.GetValue(obj, null);
        }

        private static IOrderedEnumerable<Book> OrderBy(IList<Book> books, Order order)
        {
            if (order.Direction == OrderDirection.Ascendent)
                return books.OrderBy(x => GetPropertyValue(x, order.Property));
            else
                return books.OrderByDescending(x => GetPropertyValue(x, order.Property));
        }

        private static IOrderedEnumerable<Book> ThenBy(IOrderedEnumerable<Book> books, Order order)
        {
            if (order.Direction == OrderDirection.Ascendent)
                return books.ThenBy(x => GetPropertyValue(x, order.Property));
            else
                return books.ThenByDescending(x => GetPropertyValue(x, order.Property));
        }
    }
}
