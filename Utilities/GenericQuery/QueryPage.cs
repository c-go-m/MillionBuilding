using Utilities.Objects;

namespace Utilities.GenericQuery
{
    public static class QueryPage
    {
        public static IQueryable<T> Page<T>(this IQueryable<T> source, ItemPage pageInfo)
        {
            if (pageInfo == null || pageInfo.Page <= 0 || pageInfo.PageSize <= 0)
            {
                return source;
            }

            int skip = (pageInfo.Page - 1) * pageInfo.PageSize;
            return source.Skip(skip).Take(pageInfo.PageSize);
        }
    }
}
