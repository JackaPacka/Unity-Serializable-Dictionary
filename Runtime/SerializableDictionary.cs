using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace JackR
{
    /// <summary>
    /// A serializable dictionary that can be used with Unity's serialization system.
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the dictionary.</typeparam>
    /// <typeparam name="TValue">The type of values in the dictionary.</typeparam>
    [Serializable]
    public class SerializableDictionary<TKey, TValue> : ISerializationCallbackReceiver,
                                                        IEnumerable<KeyValuePair<TKey, TValue>>
    {
        #region Properties

        /// <summary>
        /// Gets the list of keys in the dictionary.
        /// </summary>
        public List<TKey> Keys => keys;
        [SerializeField]
        private List<TKey> keys = new();
        
        /// <summary>
        /// Gets the list of values in the dictionary.
        /// </summary>
        public List<TValue> Values => values;
        [SerializeField]
        private List<TValue> values = new();
        
        /// <summary>
        /// Gets the number of key/value pairs contained in the dictionary.
        /// </summary>
        public int Count => Dictionary.Count;
        
        /// <summary>
        /// Reference to the non-serialized dictionary.
        /// </summary>
        public Dictionary<TKey, TValue> Dictionary
        {
            get;
            private set;
        } = new();
        
        #endregion
        
        #region Serialization

        /// <summary>
        /// Method called by Unity before this object is serialized.
        /// Converts the dictionary into two lists for serialization.
        /// </summary>
        public void OnBeforeSerialize()
        {
            keys.Clear();
            values.Clear();
            
            foreach (var keyValuePair in Dictionary)
            {
                keys.Add(keyValuePair.Key);
                values.Add(keyValuePair.Value);
            }
        }
        
        /// <summary>
        /// Method called by Unity after this object is deserialized.
        /// Converts the two lists back into a dictionary.
        /// </summary>
        public void OnAfterDeserialize()
        {
            Dictionary = new Dictionary<TKey, TValue>();

            for (var i = 0; i != Mathf.Min(keys.Count, values.Count); i++)
                Dictionary.Add(keys[i], values[i]);
        }
        
        #endregion

        #region Enumeration

        /// <summary>
        /// Returns an enumerator that iterates through the dictionary.
        /// </summary>
        /// <returns>An enumerator that can be used to iterate through the dictionary.</returns>
        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator() => Dictionary.GetEnumerator();
        
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion
        
        #region Contructors
        
        public SerializableDictionary() { }
        
        public SerializableDictionary(int capacity)
        {
            Dictionary = new Dictionary<TKey, TValue>(capacity);
        }
        
        public SerializableDictionary(int capacity, IEqualityComparer<TKey> comparer)
        {
            Dictionary = new Dictionary<TKey, TValue>(capacity, comparer);
        }
        
        public SerializableDictionary(IEqualityComparer<TKey> comparer)
        {
            Dictionary = new Dictionary<TKey, TValue>(comparer);
        }
        
        public SerializableDictionary(Dictionary<TKey, TValue> dictionary)
        {
            Dictionary = new Dictionary<TKey, TValue>(dictionary);
        }
        
        public SerializableDictionary(Dictionary<TKey, TValue> dictionary, IEqualityComparer<TKey> comparer)
        {
            Dictionary = new Dictionary<TKey, TValue>(dictionary, comparer);
        }
        
        public SerializableDictionary(IEnumerable<KeyValuePair<TKey, TValue>> enumerable)
        {
            Dictionary = new Dictionary<TKey, TValue>(enumerable);
        }
        
        public SerializableDictionary(IEnumerable<KeyValuePair<TKey, TValue>> enumerable, IEqualityComparer<TKey> comparer)
        {
            Dictionary = new Dictionary<TKey, TValue>(enumerable, comparer);
        }
        
        #endregion
        
        /// <summary>
        /// Tries to get the value associated with the specified key.
        /// </summary>
        /// <param name="key">The key of the value to get.</param>
        /// <param name="value">When this method returns, contains the value associated with the specified key, if the
        /// key is found; otherwise, the default value for the type of the value parameter.</param>
        /// <returns>true if the dictionary contains an element with the specified key; otherwise, false.</returns>
        public bool TryGetValue(TKey key, out TValue value) => Dictionary.TryGetValue(key, out value);
        
        /// <summary>
        /// Adds the specified key and value to the dictionary.
        /// </summary>
        /// <param name="key">The key of the element to add.</param>
        /// <param name="value">The value of the element to add.</param>
        public void Add(TKey key, TValue value) => Dictionary.Add(key, value);
        
        /// <summary>
        /// Attempts to add the specified key and value to the dictionary.
        /// </summary>
        /// <param name="key">The key of the element to add.</param>
        /// <param name="value">The value of the element to add.</param>
        /// <returns>true if the key/value pair was added to the dictionary successfully; otherwise, false.</returns>
        public bool TryAdd(TKey key, TValue value) => Dictionary.TryAdd(key, value);
        
        /// <summary>
        /// Removes the value with the specified key from the dictionary.
        /// </summary>
        /// <param name="key">The key of the element to remove.</param>
        /// <returns>true if the element is successfully found and removed; otherwise, false.</returns>
        public bool Remove(TKey key) => Dictionary.Remove(key);
        
        /// <summary>
        /// Removes all keys and values from the dictionary.
        /// </summary>
        public void Clear() => Dictionary.Clear();
        
        /// <summary>
        /// Determines whether the dictionary contains the specified key.
        /// </summary>
        /// <param name="key">The key to locate in the dictionary.</param>
        /// <returns>true if the dictionary contains an element with the specified key; otherwise, false.</returns>
        public bool ContainsKey(TKey key) => Dictionary.ContainsKey(key);
        
        /// <summary>
        /// Determines whether the dictionary contains the specified value.
        /// </summary>
        /// <param name="value">The value to locate in the dictionary.</param>
        /// <returns>true if the dictionary contains an element with the specified value; otherwise, false.</returns>
        public bool ContainsValue(TValue value) => Dictionary.ContainsValue(value);

        /// <summary>
        /// Ensures that the dictionary can hold up to a specified number of entries without any further expansion of
        /// its backing storage.
        /// </summary>
        /// <param name="capacity">The number of entries.</param>
        /// <returns>The new capacity of this instance.</returns>
        public int EnsureCapacity(int capacity) => Dictionary.EnsureCapacity(capacity);
        
        /// <summary>
        /// Removes all keys and values from the dictionary that are not being used,  minimizing the dictionary's
        /// memory footprint.
        /// </summary>
        public void TrimExcess() => Dictionary.TrimExcess();
        
        /// <summary>
        /// Sets the capacity of this dictionary to hold up a specified number of entries without any further expansion
        /// of its backing storage, removing all keys and values from the dictionary that are not being used.
        /// </summary>
        /// <param name="capacity">The number of entries.</param>
        public void TrimExcess(int capacity) => Dictionary.TrimExcess(capacity);
        
        /// <summary>
        /// Converts the dictionary into a List of KeyValuePair objects.
        /// </summary>
        /// <returns>A List of KeyValuePair objects representing the dictionary.</returns>
        public List<KeyValuePair<TKey, TValue>> ToList() => Dictionary.ToList();
        
        /// <summary>
        /// Converts the dictionary into an array of KeyValuePair objects.
        /// </summary>
        /// <returns>An array of KeyValuePair objects representing the dictionary.</returns>
        public KeyValuePair<TKey, TValue>[] ToArray() => Dictionary.ToArray();
        
        public override string ToString() => Dictionary.ToString();
    }
}
