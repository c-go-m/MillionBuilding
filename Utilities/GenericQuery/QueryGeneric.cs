using System.Reflection;
using Utilities.Utilities;

namespace Utilities.GenericQuery
{
    public static class QueryGeneric
    {
        public static PropertyInfo GetProperty(string name, Type entityType)
        {
            var property = entityType.GetProperty(name, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
            if (property == null)
            {
                throw new ArgumentException(string.Format(ConstantsException.PropertyInvalid, name, entityType.Name));
            }

            return property;
        }
    }
}
