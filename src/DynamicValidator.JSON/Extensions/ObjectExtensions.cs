using System;

namespace DynamicValidator.JSON.Extensions
{
    public static class ObjectExtensions
    {
        public static bool IsNumber(this object source)
        {
            return source is int || source is long || source is short || source is decimal || source is double || source is float;
        }

        public static decimal ToNumber(this object source)
        {
            if (source.IsNumber())
                return Convert.ToDecimal(source);

            return 0;
        }
    }
}
