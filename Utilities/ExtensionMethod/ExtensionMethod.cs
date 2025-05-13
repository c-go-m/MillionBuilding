using System.Runtime.CompilerServices;
using Utilities.Utilities;

namespace Utilities.ExtensionMethod
{
    public static class ExtensionMethod
    {
        public static string ValidateValue(this string? value, [CallerMemberName] string callerName = "") =>
            string.IsNullOrEmpty(value)
                ? throw new InvalidOperationException(string.Format(ConstantsException.ValueInvalid, value, callerName))
                : value;

        public static int ValidateValue(this int? value, [CallerMemberName] string callerName = "") =>
            value == null
                ? throw new InvalidOperationException(string.Format(ConstantsException.ValueInvalid, value, callerName))
                : value.Value;

        public static bool IsNotNull<T>(this T? valid) where T : class => valid != null;

        public static string Encript(this string data) => Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(data));

        public static T ToEnum<T>(this string valor) where T : struct, Enum
        {
            if (Enum.TryParse<T>(valor, true, out var result))
            {
                return result;
            }
            return Enum.GetValues(typeof(T)).Cast<T>().First();
        }
    }
}
