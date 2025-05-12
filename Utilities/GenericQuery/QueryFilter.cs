using System.Linq.Expressions;
using Utilities.Objects;
using Utilities.Utilities;
using static Utilities.Utilities.Enumerations;

namespace Utilities.GenericQuery
{
    public static class QueryFilter
    {
        public static IQueryable<T> FilterGeneric<T>(this IQueryable<T> source, IEnumerable<ItemFilter> filters)
        {
            if (filters.Any()) return CreateIQueryable(source, filters);
            
            return source;            
        }

        private static IQueryable<T> CreateIQueryable<T>(IQueryable<T> source, IEnumerable<ItemFilter> filters)
        {
            var parameter = Expression.Parameter(typeof(T), "x");
            Expression? finalExpression = null;

            finalExpression = CreateFilterExpression<T>(filters, parameter, finalExpression);

            if (finalExpression == null) return source;            

            var lambda = Expression.Lambda<Func<T, bool>>(finalExpression, parameter);
            return source.Where(lambda);
        }

        private static Expression? CreateFilterExpression<T>(IEnumerable<ItemFilter> filters, ParameterExpression parameter, Expression? finalExpression)
        {
            foreach (var filter in filters)
            {
                if (string.IsNullOrEmpty(filter.Name) || filter.Value == null) continue;
                
                var entityType = typeof(T);
                var property = QueryGeneric.GetProperty(filter.Name, entityType);                               

                var member = Expression.Property(parameter, property);
                var constant = Expression.Constant(Convert.ChangeType(filter.Value.ToString(), property.PropertyType));
                Expression? expression = null;
                expression = CreateFilterCondition(filter, member, constant);

                finalExpression = finalExpression == null ? expression : Expression.AndAlso(finalExpression, expression);
            }

            return finalExpression;
        }

        private static Expression CreateFilterCondition(ItemFilter filter, MemberExpression member, ConstantExpression constant)
        {
            Expression? expression;
            switch (filter.Operator)
            {
                case FilterOperation.Equals:
                    expression = Expression.Equal(member, constant);
                    break;
                case FilterOperation.NotEquals:
                    expression = Expression.NotEqual(member, constant);
                    break;
                case FilterOperation.Mayor:
                    expression = Expression.GreaterThan(member, constant);
                    break;
                case FilterOperation.Minor:
                    expression = Expression.LessThan(member, constant);
                    break;
                case FilterOperation.MayorEquals:
                    expression = Expression.GreaterThanOrEqual(member, constant);
                    break;
                case FilterOperation.MinorEquals:
                    expression = Expression.LessThanOrEqual(member, constant);
                    break;
                case FilterOperation.Contains:
                    expression = Expression.Call(member, typeof(string).GetMethod("Contains", new[] { typeof(string) })!, constant);
                    break;
                default:                    
                    throw new ArgumentException(string.Format(ConstantsException.OperationInvalid,filter.Operator));
            }

            return expression;
        }
    }
}
