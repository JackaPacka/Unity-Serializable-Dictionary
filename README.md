# SerializableDictionary<TKey, TValue>

A serializable dictionary that can be used with Unity's serialization system.

## Features

- **Serialization**: The dictionary can be serialized into two lists for Unity's serialization system.
- **Enumeration**: The dictionary can be iterated over using a `foreach` loop.
- **Key-Value Pair Management**: The dictionary supports adding, removing, and checking the existence of key-value pairs.
- **Capacity Management**: The dictionary supports ensuring a certain capacity and trimming excess capacity.
- **Conversion**: The dictionary can be converted into a list or an array of key-value pairs.

## Usage

```csharp
var dictionary = new SerializableDictionary<string, int>();
dictionary.Add("apple", 1);
dictionary.Add("banana", 2);

foreach (var kvp in dictionary)
{
    Debug.Log($"Key: {kvp.Key}, Value: {kvp.Value}");
}
```

## Constructors

The SerializableDictionary<TKey, TValue> class provides several constructors to create a new instance:  
- SerializableDictionary(): Creates a new instance of the SerializableDictionary<TKey, TValue> class.
- SerializableDictionary(int capacity): Creates a new instance of the SerializableDictionary<TKey, TValue> class with the specified capacity.
- SerializableDictionary(int capacity, IEqualityComparer<TKey> comparer): Creates a new instance of the SerializableDictionary<TKey, TValue> class with the specified capacity and comparer.
- SerializableDictionary(IEqualityComparer<TKey> comparer): Creates a new instance of the SerializableDictionary<TKey, TValue> class with the specified comparer.
- SerializableDictionary(Dictionary<TKey, TValue> dictionary): Creates a new instance of the SerializableDictionary<TKey, TValue> class by copying the elements from the specified dictionary.
- SerializableDictionary(Dictionary<TKey, TValue> dictionary, IEqualityComparer<TKey> comparer): Creates a new instance of the SerializableDictionary<TKey, TValue> class by copying the elements from the specified dictionary and using the specified comparer.
- SerializableDictionary(IEnumerable<KeyValuePair<TKey, TValue>> enumerable): Creates a new instance of the SerializableDictionary<TKey, TValue> class by copying the elements from the specified enumerable collection of key-value pairs.
- SerializableDictionary(IEnumerable<KeyValuePair<TKey, TValue>> enumerable, IEqualityComparer<TKey> comparer): Creates a new instance of the SerializableDictionary<TKey, TValue> class by copying the elements from the specified enumerable collection of key-value pairs and using the specified comparer.

## Methods

The SerializableDictionary<TKey, TValue> class provides several methods to manipulate the dictionary:
- TryGetValue(TKey key, out TValue value): Tries to get the value associated with the specified key.
- Add(TKey key, TValue value): Adds the specified key and value to the dictionary.
- TryAdd(TKey key, TValue value): Attempts to add the specified key and value to the dictionary.
- Remove(TKey key): Removes the value with the specified key from the dictionary.
- Clear(): Removes all keys and values from the dictionary.
- ContainsKey(TKey key): Determines whether the dictionary contains the specified key.
- ContainsValue(TValue value): Determines whether the dictionary contains the specified value.
- EnsureCapacity(int capacity): Ensures that the dictionary can hold up to a specified number of entries without any further expansion of its backing storage.
- TrimExcess(): Removes all keys and values from the dictionary that are not being used, minimizing the dictionary's memory footprint.
- TrimExcess(int capacity): Sets the capacity of this dictionary to hold up a specified number of entries without any further expansion of its backing storage, removing all keys and values from the dictionary that are not being used.
- ToList(): Converts the dictionary into a List of KeyValuePair objects.
- ToArray(): Converts the dictionary into an array of KeyValuePair objects.