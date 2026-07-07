using System;
using System.Collections.Generic;

namespace Assignment.Helpers
{
    internal class Algorithms
    {

       public static IEnumerable<T> CustomWhere<T>(IEnumerable<T> collection, Func<T, bool> func)
        {
            foreach (var item in collection)
            {
                if (func(item))
                {
                    yield return item;
                }
            }
        }

        public static T CustomFirstOrDefault<T>(IEnumerable<T> collection, Predicate<T> predicate  )
        {
            foreach (var item in collection)
            {
                if (predicate(item))
                {
                    return item;
                }
            }
            return default;
        }

        public static T CustomFirst<T>(IEnumerable<T> collection, Predicate<T> predicate)
        {
            foreach (var item in collection)
            {
                if (predicate(item))
                {
                    return item;
                }
            }
            throw new InvalidOperationException();
        }

        public static IEnumerable<T> CustomDistinct<T>(IEnumerable<T> collection)
        {
            return new HashSet<T>(collection);
        }

        public static bool CustomAny<T>(IEnumerable<T> collection, Predicate<T> predicate)
        {
            foreach (var item in collection)
            {
                if (predicate(item))
                    return true;
            }
            return false;
        }

        public static bool CustomAll<T>(IEnumerable<T> collection, Predicate<T> predicate)
        {
            foreach (var item in collection)
            {
                if (!predicate(item))
                    return false;
            }
            return true;
        }

        public static int CustomCount<T>(IEnumerable<T> collection, Predicate<T> predicate = null)
        {
            int count = 0;
            foreach (var item in collection)
            {
                if (predicate == null || predicate(item))
                    count++;
            }
            return count;
        }

        public static T CustomSingle<T>(IEnumerable<T> collection, Predicate<T> predicate)
        {
            T result = default;
            bool found = false;
            foreach (var item in collection)
            {
                if (predicate(item))
                {
                    if (found)
                        throw new InvalidOperationException("More than one element found");
                    result = item;
                    found = true;
                }
            }
            if (!found)
                throw new InvalidOperationException("No element found");
            return result;
        }

        public static T CustomSingleOrDefault<T>(IEnumerable<T> collection, Predicate<T> predicate)
        {
            T result = default;
            bool found = false;
            foreach (var item in collection)
            {
                if (predicate(item))
                {
                    if (found)
                        throw new InvalidOperationException("More than one element found");
                    result = item;
                    found = true;
                }
            }
            return result;
        }

        public static IEnumerable<T> CustomOrderBy<T>(IEnumerable<T> collection, Func<T, IComparable> keySelector)
        {
            T[] array = new T[0];
            foreach (var item in collection)
            {
                Array.Resize(ref array, array.Length + 1);
                array[array.Length - 1] = item;
            }

            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = 0; j < array.Length - 1 - i; j++)
                {
                    if (keySelector(array[j]).CompareTo(keySelector(array[j + 1])) > 0)
                    {
                        T temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                    }
                }
            }
            return array;
        }

    }
}
