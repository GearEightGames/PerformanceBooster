// Copyright GearEight Games UG (haftungsbeschränkt). All Rights Reserved.

using System;

namespace G8G.PerformanceBooster.Collections
{
    /// <summary>
    /// Represents a variable size last-in-first-out (LIFO) collection of instances of the same specified type.  
    /// Implementation of a stack on top of the <see cref="BetterList{T}"/> 
    /// </summary>
    /// <typeparam name="T">Specifies the type of elements in the <see cref="StackList{T}"/>.</typeparam>
    [Serializable]
    public class StackList<T> : BetterList<T>
    {
        /// <summary>
        /// Inserts an object at the top of the <see cref="StackList{T}"/>.
        /// </summary>
        /// <param name="value">The element to push onto the <see cref="StackList{T}"/></param>
        public void Push(T value) => Add(value);

        /// <summary>
        /// Removes and returns the object at the top of the <see cref="StackList{T}"/>
        /// </summary>
        /// <remarks>
        /// This method is similar to the Peek method, but Peek does not modify the <see cref="StackList{T}"/>.
        /// If type T is a reference type, null can be pushed onto the <see cref="StackList{T}"/> as a placeholder, if needed.
        /// <see cref="StackList{T}"/> is implemented as an IList. This method is an O(1) operation.
        /// </remarks>
        /// <returns>The element at the top of the <see cref="StackList{T}"/></returns>
        public T Pop()
        {
            T last = Last();
            RemoveLast();
            return last;
        }

        /// <summary>
        /// Returns the object at the top of the <see cref="StackList{T}"/> without removing it.
        /// </summary>
        /// <remarks>
        /// This method is similar to the <see cref="StackList{T}.Pop"/> method, but <see cref="StackList{T}.Peek"/> does not modify the <see cref="StackList{T}"/>.
        /// If type T is a reference type, null can be pushed onto the <see cref="StackList{T}"/> as a placeholder, if needed.
        /// This method is an O(1) operation.
        /// </remarks>
        /// <returns>The object at the top of the <see cref="StackList{T}"/>.</returns>
        public T Peek() => Last();
    }
}
