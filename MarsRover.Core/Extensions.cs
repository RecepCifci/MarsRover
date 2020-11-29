using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Core
{
    public static class Extensions
    {
        public static T Next<T>(this T sourceEnum) where T : struct
        {
            if (!typeof(T).IsEnum) throw new ArgumentException(String.Format("Invalid Argument: {0}", typeof(T).FullName));

            T[] enumArray = (T[])Enum.GetValues(sourceEnum.GetType());
            int j = Array.IndexOf<T>(enumArray, sourceEnum) + 1;
            return (enumArray.Length == j) ? enumArray[0] : enumArray[j];
        }

        public static T Previous<T>(this T sourceEnum) where T : struct
        {
            if (!typeof(T).IsEnum) throw new ArgumentException(String.Format("Invalid Argument: {0}", typeof(T).FullName));

            T[] enumArray = (T[])Enum.GetValues(sourceEnum.GetType());
            int j = Array.IndexOf<T>(enumArray, sourceEnum) - 1;
            return j < 0 ? enumArray[enumArray.Length - 1] : enumArray[j];
        }
    }
}
