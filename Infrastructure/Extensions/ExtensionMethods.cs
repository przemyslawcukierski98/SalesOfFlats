using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Extensions
{
    public static class ExtensionMethods
    {
        public static IQueryable<T> OrderByPropertyName<T>(this IQueryable<T> q, string sortField, bool ascending)
        {
            var parameter = Expression.Parameter(typeof(T), "p");
            var property = Expression.Property(parameter, sortField);
            var lambda = Expression.Lambda(property, parameter);
            string method = ascending ? "OrderBy" : "OrderByDescending";
            Type[] types = new Type[] { q.ElementType, lambda.Body.Type };
            var rs = Expression.Call(typeof(Queryable), method, types, q.Expression, lambda);
            return q.Provider.CreateQuery<T>(rs);
        }
    }
}
