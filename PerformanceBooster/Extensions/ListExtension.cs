// Copyright GearEight Games UG (haftungsbeschränkt). All Rights Reserved.

using System;
using System.Collections.Generic;

namespace G8G.PerformanceBooster.Extensions
{
    /// <summary>
    /// An alternative to the <see cref="Collections.BetterList{T}"/> (which should be preferred).
    /// Extends the regular IList with the same method that BetterList uses.
    /// </summary>
    public static class ListExtension
    {
        /// <summary>
        /// Returns the last element in the list.
        /// Default if list is empty.
        /// </summary>
        /// <returns>The last element of the list or the default value, if the list is empty.</returns>
        public static T Last<T>(this IList<T> list) => list.Count == 0 ? default : list[list.Count - 1];

        /// <summary>
        /// Returns the first element in the list.
        /// Default if the list is empty.
        /// </summary>
        /// <returns>The first element in the list or the default value, if the list is empty.</returns>
        public static T First<T>(this IList<T> list) => list.Count == 0 ? default : list[0];

        /// <summary>
        /// Returns the amount of elements that match the predicate.
        /// </summary>
        /// <param name="match">The filter method used as predicate.</param>
        /// <returns>The amount of elements that match the predicate.</returns>
        public static int CountWhere<T>(this IList<T> list, Predicate<T> match)
        {
            if (list.Count == 0)
                return 0;

            int amount = 0;
            for (int i = 0; i < list.Count; ++i)
            {
                if (match(list[i]))
                    ++amount;
            }
            return amount;
        }

        /// <summary>
        /// Returns the first element in the list that matches the predicate.
        /// </summary>
        /// <param name="match">The filter method used as a predicate.</param>
        /// <returns>The first element that matches the predicate.</returns>
        public static T First<T>(this IList<T> list, Predicate<T> match)
        {
            if (list.Count > 0)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    if (match(list[i]))
                        return list[i];
                }
            }
            return default;
        }

        /// <summary>
        /// Swaps two elements in the list by index.
        /// </summary>
        /// <remarks>Does not do any bounds checking.</remarks>
        /// <param name="indexA">The first element to swap</param>
        /// <param name="indexB">The second element to swap</param>
        public static void Swap<T>(this IList<T> list, int indexA, int indexB)
        {
            T temp = list[indexA];
            list[indexA] = list[indexB];
            list[indexB] = temp;
        }

        /// <summary>
        /// Removes the element but does not maintain order.
        /// </summary>
        /// <remarks>
        /// Inspired by the RemoveSwap-method in Unreals TArray, we first swap the requested and the last element and then remove the (new) last element.
        /// Improving performance, but destroying the order of the list.
        /// </remarks>
        /// <param name="element">The element to remove</param>
        /// <returns>True when the element could be successfully found and removed.</returns>
        public static void RemoveSwap<T>(this IList<T> list, T element)
        {
            int elementIndex = list.IndexOf(element);
            T temp = list[elementIndex];
            list[elementIndex] = list[list.Count - 1];
            list[list.Count - 1] = temp;
            list.RemoveAt(list.Count - 1);
        }

        /// <summary>
        /// Removes the element at the given index but does not maintain order.
        /// </summary>
        /// <remarks>
        /// Inspired by the RemoveAtSwap-method in Unreals TArray, we first swap the requested and last element and then remove the (new) last element.
        /// Improving performance, but destroying the order of the list.
        /// </remarks>
        /// <param name="index">The index of the element to remove</param>
        public static void RemoveAtSwap<T>(this IList<T> list, int indexA, int indexB)
        {
            T temp = list[indexA];
            list[indexA] = list[indexB];
            list[indexB] = temp;
            list.RemoveAt(list.Count - 1);
        }

        /// <summary>
        /// Removes the last element.
        /// </summary>
        /// <returns>True when the element could be removed</returns>
        public static void RemoveLast<T>(this IList<T> list) => list.RemoveAt(list.Count - 1);
    }
}
