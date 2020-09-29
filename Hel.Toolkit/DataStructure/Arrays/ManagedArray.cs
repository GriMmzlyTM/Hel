using System;
using System.Collections.Generic;

namespace Hel.Toolkit.DataStructure.Arrays
{
    /// <summary>
    /// Automatically managed and assigned array.
    /// A ManagedArray is, at its core, just an array and as such it has very similar performance.
    /// Indexes are never sorted or modified.
    /// When an object is removed from the Array, that index is returned to the FreeId queue, allowing it to be recycled
    /// without disturbing the other indexes.
    ///
    /// This is important for data that needs to be retrieved by index key
    /// </summary>
    /// <typeparam name="TDataType"></typeparam>
    public class ManagedArray<TDataType>
    {
        private TDataType[] _array;
        private int _size;

        /// <summary>
        /// Retrieve size of the array
        /// </summary>
        public int Size => _size;
        
        /// <summary>
        /// Retrieve the number of <see cref="TDataType"/> that are allocated in the array
        /// </summary>
        public int DataCount => _size - _freeIds.Count;
        
        /// <summary>
        /// ID's that are available to be allocated
        /// </summary>
        private readonly Queue<int> _freeIds;

        private readonly HashSet<int> _allocatedIds;

        public ManagedArray(int capacity)
        {
            _array = new TDataType[capacity];
            _size = capacity;
            _allocatedIds = new HashSet<int>(capacity);
            _freeIds = new Queue<int>(capacity);
            for (var i = 0; i < 256; i++)
            {
                _freeIds.Enqueue(i);
            }
        }

        public int[] GetNonNullIndexes()
        {
            var indexes = new int[_allocatedIds.Count];
            _allocatedIds.CopyTo(indexes);
            return indexes;
        }

        public void Clear()
        {
            Array.Clear(_array, 0 , _size);
            _freeIds.Clear();
            _allocatedIds.Clear();
            for (var i = 0; i < _size; i++)
            {
                _freeIds.Enqueue(i);
            }
        }
        
        /// <summary>
        /// Double array size if required and queue fresh free ids
        /// </summary>
        private void ExpandArray()
        {
            var oldEntityTypeSize = _size;
            _size *= 2;
            Array.Resize(ref _array, _size);
            for (int i = oldEntityTypeSize + 1; i < _size; i++)
            {
                _freeIds.Enqueue(i);
            }
        }
        
        /// <summary>
        /// Gets a freeid to be allocated, If no free ids are available, expands the array
        /// </summary>
        /// <returns>Available ID</returns>
        private int GenerateId()
        {
            // Free id available -> return 
            if (_freeIds.TryDequeue(out var id))
            {
                return id;
            }
            
            // No free ID -> Expand ids and create more free ids
            ExpandArray();
            return _freeIds.Dequeue();
        }
        
        /// <summary>
        /// Adds the data to the array at the lowest available free ID
        /// </summary>
        /// <param name="data"></param>
        /// <returns>The ID where the data is stored</returns>
        public int Add(TDataType data)
        {
            var entityId = GenerateId();
            _allocatedIds.Add(entityId);
            
            _array[entityId] = data;

            return entityId;
        }

        /// <summary>
        /// Removes data from the ID and frees up the ID associated to be reused later
        /// </summary>
        /// <param name="id">The ID to remove and add to the free IDs queue</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public void Remove(int id)
        {
            if (id >= _size ||
                EqualityComparer<TDataType>.Default.Equals(_array[id], default))
            {
                throw new ArgumentOutOfRangeException($"Cannot remove null or invalid index {id} in array with data type {typeof(TDataType)}, max index is {_size - 1}");
            }
            _freeIds.Enqueue(id);
            _allocatedIds.Remove(id);
            _array[id] = default;
        }

        /// <summary>
        /// Get or modify the values in the array.
        /// Note: You CAN NOT add a value. Trying to add a value to an index where the current value is null will throw an exception.
        /// You CAN override a pre-existing object however. 
        /// </summary>
        /// <param name="index"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public TDataType this[int index]
        {
            get {
                if (index >= _size)
                {
                    throw new ArgumentOutOfRangeException($"Cannot access index {index} in array with data type {typeof(TDataType)}, max index is {_size - 1}");
                }
                return _array[index];
            }
            set
            {
                if (index >= _size ||
                    EqualityComparer<TDataType>.Default.Equals(_array[index], default))
                {
                    throw new ArgumentOutOfRangeException($"Cannot assign index {index} in array with data type {typeof(TDataType)}, max index is {_size - 1}. Please use Add method to allocate dynamically");
                }

                if (EqualityComparer<TDataType>.Default.Equals(value, default))
                {
                    Remove(index);
                    return;
                }
                
                _array[index] = value;
            }
        }
    }
}