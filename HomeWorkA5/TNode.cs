using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWorkA5
{
    class TNode<T>
    {
        /// <summary>
        /// Array for stack
        /// </summary>
        private T[] arr;

        /// <summary>
        /// Count elements in array
        /// </summary>
        private int count;

        /// <summary>
        /// Initialize TNode with default size 10
        /// </summary>
        public TNode()
        {
            arr = new T[10];
        }

        /// <summary>
        /// Initialize TNode with requested size
        /// </summary>
        /// <param name="length">size of stack</param>
        public TNode(int length)
        {
            arr = new T[length];
        }

        /// <summary>
        /// Property Count of elements
        /// </summary>
        public int Count
        {
            get { return count; }
        }

        /// <summary>
        /// Property Check if stack is empty
        /// </summary>
        public bool IsEmpty
        {
            get { return count == 0; }
        }

        // Method Resize
        private void Resize(int max)
        {
            // make temp array
            T[] tempItems = new T[max];

            // copy values from curernt array to temparray
            for (int i = 0; i < count; i++)
                tempItems[i] = arr[i];

            // copy temp array to current array
            arr = tempItems;

            // Console.WriteLine(" Memory usage changed.");
        }

        /// <summary>
        /// Method Push
        /// </summary>
        /// <param name="item">array (stack)</param>
        public void Push(T item)
        {
            // if stack is full increase stack by 33%
            if (count == arr.Length)
            {
                Resize(arr.Length + arr.Length / 3);
                // Console.WriteLine($" Increasing memory usage by {count / 3}...");
            }

            // add new item in stack
            arr[count++] = item;
        }

        /// <summary>
        /// Method Pop
        /// </summary>
        public T Pop()
        {
            // Exception if stack is empty
            // use it for try-catch exception message
            if (IsEmpty)
                throw new InvalidOperationException("Stack is empty");

            T item = arr[--count];

            arr[count] = default(T); // reset link

            // Resize array
            if (count > 0 && count < arr.Length - 10)
            {
                Resize(arr.Length - 10);
                // Console.WriteLine($" Decreasing memory usage by 10...");
            }

            // return array
            return item;
        }

        /// <summary>
        /// Method Peek
        /// </summary>
        public T Peek()
        {
            return arr[count - 1];
        }
    }
}
