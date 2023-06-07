using System;
using System.Linq;

namespace TruckRegistration.Domain.Utils.Extensions
{
    public static class RandomExtension
    {
        public static T RandomEnum<T>() where T : struct, IConvertible
        {
            if (!typeof(T).IsEnum) { throw new Exception("random enum variable is not an enum"); }

            var values = Enum.GetValues(typeof(T));
            return (T)values.GetValue(new Random().Next(values.Length));
        }

        public static string RandomString(string[] items)
        {
            if (!items.Any()) { throw new Exception("random string not contains items to sort"); }

            return (string)items.GetValue(new Random().Next(items.Length));
        }

        public static int RandomInt(int[] items = null, int initialValue = 1, int endValue = 100)
        {
            if (items != null && items.Any())
            {
                return (int)items.GetValue(new Random().Next(items.Length));
            }

            return new Random().Next(initialValue, endValue);
        }
    }
}
