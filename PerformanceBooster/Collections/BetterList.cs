// Copyright GearEight Games UG (haftungsbeschränkt). All Rights Reserved.

using System;
using System.Collections.Generic;

namespace G8G.PerformanceBooster.Collections
{
    /// <summary>
    /// An improvement on the regular <see cref="BetterList{T}"/> with methods from Linq implemented inline and some new methods that may improve performance overall.
    /// </summary>
    /// <typeparam name="T">The type of elements in the list</typeparam>
    [Serializable]
    public class BetterList<T> : List<T>
    {
        /// <summary>
        /// Returns the last element in the list.
        /// Default if list is empty.
        /// </summary>
        /// <returns>The last element of the list or the default value, if the list is empty.</returns>
        public T Last() => Count == 0 ? default : this[Count - 1];

        /// <summary>
        /// Returns the first element in the list.
        /// Default if the list is empty.
        /// </summary>
        /// <returns>The first element in the list or the default value, if the list is empty.</returns>
        public T First() => Count == 0 ? default : this[0];

        /// <summary>
        /// Returns the amount of elements that match the predicate.
        /// </summary>
        /// <param name="match">The filter method used as predicate.</param>
        /// <returns>The amount of elements that match the predicate.</returns>
        public int CountWhere(Predicate<T> match)
        {
            if (Count == 0)
                return 0;

            int amount = 0;
            for (int i = 0; i < Count; ++i)
            {
                if (match(this[i]))
                    ++amount;
            }
            return amount;
        }

        /// <summary>
        /// Returns the first element in the list that matches the predicate.
        /// </summary>
        /// <param name="match">The filter method used as a predicate.</param>
        /// <returns>The first element that matches the predicate.</returns>
        public T First(Predicate<T> match)
        {
            if (Count > 0)
            {
                for (int i = 0; i < Count; i++)
                {
                    if (match(this[i]))
                        return this[i];
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
        public void Swap(int indexA, int indexB)
        {
            T temp = this[indexA];
            this[indexA] = this[indexB];
            this[indexB] = temp;
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
        public bool RemoveSwap(T element)
        {
            int elementIndex = IndexOf(element);
            if (elementIndex == -1)
                return false;
            RemoveAtSwap(elementIndex);
            return true;
        }

        /// <summary>
        /// Removes the element at the given index but does not maintain order.
        /// </summary>
        /// <remarks>
        /// Inspired by the RemoveAtSwap-method in Unreals TArray, we first swap the requested and last element and then remove the (new) last element.
        /// Improving performance, but destroying the order of the list.
        /// </remarks>
        /// <param name="index">The index of the element to remove</param>
        public void RemoveAtSwap(int index)
        {
            if (Count == 0)
                return;
            Swap(index, Count - 1);
            RemoveLast();
        }

        /// <summary>
        /// Removes the last element.
        /// </summary>
        /// <returns>True when the element could be removed</returns>
        public bool RemoveLast()
        {
            if (Count == 0)
                return false;
            RemoveAt(Count - 1);
            return true;
        }
    }
}
