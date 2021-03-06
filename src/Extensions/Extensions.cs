using Newtonsoft.Json;
using QuickDotNetUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickDotNetUI.Extensions
{
    internal static class StringExtensions
    {
        public static bool IsEqualIgnoreCase(this string str, string copareString) => str.Equals(copareString, StringComparison.InvariantCultureIgnoreCase);
    }
    internal static class ArrayExtensions
    {
        public static bool IsNull(this IEnumerable<object> array) => array == null;
        public static bool IsEmpty(this IEnumerable<object> array) => !array.Any();
        public static bool IsNullOrEmpty(this IEnumerable<object> array) => IsNull(array) || IsEmpty(array);
        public static bool IsNotNullAndNotEmpty(this IEnumerable<object> array) => !IsNull(array) && !IsEmpty(array);

        public static bool IsNull(this ICollection<object> array) => array == null;
        public static bool IsEmpty(this ICollection<object> array) => !array.Any();
        public static bool IsNullOrEmpty(this ICollection<object> array) => IsNull(array) || IsEmpty(array);
        public static bool IsNotNullAndNotEmpty(this ICollection<object> array) => !IsNull(array) && !IsEmpty(array);
    }
    internal static class TypeExtension 
    {
        public static bool IsNumbericType(this Type type) 
        {
            if (type.IsNullable())
                type = Nullable.GetUnderlyingType(type);

            switch (Type.GetTypeCode(type))
            {
                case TypeCode.Byte:
                case TypeCode.SByte:
                case TypeCode.UInt16:
                case TypeCode.UInt32:
                case TypeCode.UInt64:
                case TypeCode.Int16:
                case TypeCode.Int32:
                case TypeCode.Int64:
                case TypeCode.Decimal:
                case TypeCode.Double:
                case TypeCode.Single:
                    return true;
                default:
                    return false;
            }
        }
        public static bool IsNullable(this Type type)
        {
            return Nullable.GetUnderlyingType(type) != null;
        }
        public static bool IsEqualTypeIgnoreNullable(this Type type, Type compareType)
        {
            Type type1 = type.IsNullable() ? Nullable.GetUnderlyingType(type) : type;
            Type type2 = compareType.IsNullable() ? Nullable.GetUnderlyingType(compareType) : compareType;
            return type1 == type2;
        }

        public static T Clone<T>(this T source)
        {
            // Don't serialize a null object, simply return the default for that object
            if (Object.ReferenceEquals(source, null))
            {
                return default(T);
            }

            var deserializeSettings = new JsonSerializerSettings { ObjectCreationHandling = ObjectCreationHandling.Replace };
            var serializeSettings = new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore };
            return JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(source, serializeSettings), deserializeSettings);
        }
    }
}
