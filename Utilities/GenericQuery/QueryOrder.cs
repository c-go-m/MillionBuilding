using System.Linq.Expressions;
using System.Reflection;
using Utilities.ExtensionMethod;
using Utilities.Objects;
using Utilities.Utilities;
using static Utilities.Utilities.Enumerations;


namespace Utilities.GenericQuery
{
    public static class QueryOrder
    {
        public static IQueryable<T> OrderByGeneric<T>(this IQueryable<T> source, ItemSort sort)
        {
            if (sort.IsNotNull() && !String.IsNullOrEmpty(sort.Name) && !String.IsNullOrEmpty(sort.Direction)) return CreateIQueryable(source, sort);

            return source;
        }

        private static IQueryable<T> CreateIQueryable<T>(IQueryable<T> source, ItemSort sort)
        {
            var entityType = typeof(T);

            PropertyInfo? property = QueryGeneric.GetProperty(sort.Name, entityType);
            LambdaExpression orderByExpression = CreateOrderByExpression(entityType, property);
            string direction = sort.Direction.ToEnum<FilterOrder>() == FilterOrder.Ascending ? ConstantsQuery.OrderAscending : ConstantsQuery.OrderDescending;
            MethodCallExpression resultExpression = CreateOrderByMethodCall(source, entityType, property, orderByExpression, direction);

            return source.Provider.CreateQuery<T>(resultExpression);
        }

        private static MethodCallExpression CreateOrderByMethodCall<T>(IQueryable<T> source, Type entityType, PropertyInfo property, LambdaExpression orderByExpression, string direction)
        {
            return Expression.Call(
                            typeof(Queryable),
                            direction,
                            new Type[] { entityType, property.PropertyType },
                            source.Expression,
                            Expression.Quote(orderByExpression)
                        );
        }

        private static LambdaExpression CreateOrderByExpression(Type entityType, PropertyInfo property)
        {
            var parameter = Expression.Parameter(entityType, "x");
            var propertyAccess = Expression.MakeMemberAccess(parameter, property);
            var orderByExpression = Expression.Lambda(propertyAccess, parameter);
            return orderByExpression;
        }

    }
}
