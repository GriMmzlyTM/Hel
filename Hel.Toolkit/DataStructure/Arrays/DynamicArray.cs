using System;

namespace Hel.Toolkit.DataStructure.Arrays
{
    /// <summary>
    /// Dynamically sized array.
    ///
    /// When this array's size is reached it automatically expands.
    /// The main difference between this and a list is the way data is stored and assigned.
    /// A DynamicArray is JUST an array. It does not sort your data in any way. This means a DynamicArray has the same
    /// performance as a regular array compared to a List.
    /// In exchange for higher performance (Insert for example) this data structure is more difficult to use and manipulate than a list.
    ///
    /// Use this for performance-critical logic, or when you need your data to maintain its index as well as fast insert times.
    /// </summary>
    /// <typeparam name="TDataType">The data stored in the array</typeparam>
    public class DynamicArray<TDataType>
    {
        private TDataType[] _array;
        private int _size;

        /// <summary>
        /// The size of the array
        /// </summary>
        public int Size => _size;

        public DynamicArray(int capacity)
        {
            _array = new TDataType[capacity];
            _size = capacity;
        }

        public void Clear()
        {
            Array.Clear(_array, 0, _size);
        }
        
        /// <summary>
        /// Double array size if required and queue fresh free ids
        /// </summary>
        private void ExpandArray(int minSize)
        {
            _size = (_size * 2 >= minSize) ? _size * 2 : minSize;
            Array.Resize(ref _array, _size);
        }

        public void ReducePastIndex(int index)
        {
            _size = index + 1;
            Array.Resize(ref _array, _size);
        }
        
        /// <summary>
        /// Retrieve or assign data to the array.
        /// Will automatically expand the array if required.
        ///
        /// Getting an invalid index will return null.
        /// </summary>
        /// <param name="index"></param>
        public TDataType this[int index]
        {
            get => index >= _size ? default : _array[index];
            set
            {
                if (index >= _size)
                {
                    ExpandArray(index + 1);
                }

                _array[index] = value;
            }
        }
    }
}