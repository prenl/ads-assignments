using System.Collections;

namespace assignment2;

// MyArrayList extends IEnumerable to be iterable
// MyArrayList can take any objects (T)
public class MyArrayList<T> : IEnumerable<T>, IMyList<T>
{
    // _hiddenArr is the internal array to store all elements
    private T[] _hiddenArr;
    // _length is the actual number of elements in the internal array
    private int _length;

    // Default constructor that creates array with size 5
    public MyArrayList() : this(5)
    {
    }

    // Overloaded constructor that allows to put specific size for array
    public MyArrayList(int initCapacity)
    {
        _hiddenArr = new T[initCapacity];
    }

    // Private method that doubles the size of internal array when it becomes full
    private void IncreaseArray()
    {
        // Doubling the size
        int newSize = _hiddenArr.Length * 2;
        T[] newArr = new T[newSize];

        // Copying an array
        for (int i = 0; i < _hiddenArr.Length; i++)
        {
            newArr[i] = _hiddenArr[i];
        }

        _hiddenArr = newArr;
    }
    
    // Add a single item into Array List
    public void Add(T item)
    {
        // Checks if Array List is full
        if (_length == _hiddenArr.Length)
        {
            // Doubling its size if its full
            IncreaseArray();
        }

        // Add the item to the internal array
        _hiddenArr[_length++] = item;
    }

    // Add items from a collection into Array List
    public void AddAll(IEnumerable<T> collection)
    {
        // Iterate over the items in collection using foreach loop
        foreach (T item in collection)
        {
            // Call the Add method for each item from collection
            Add(item);
        }
    }

    // Add item in specific location (index)
    public void Add(T item, int index)
    {
        // Check if index is out of range
        if (index < 0 || index > _length)
            // Throw an exception
            throw new IndexOutOfRangeException();
        
        // Check if internal array is full
        if (index == _hiddenArr.Length)
            // Doubling its size if its full
            IncreaseArray();
        
        // Shift all elements to the right from index
        for (int i = _length; i > index; i--)
        {
            _hiddenArr[i] = _hiddenArr[i - 1];
        }
    
        // Put item inside internal array
        _hiddenArr[index] = item;
        
        // Incrementing length of Array List
        _length++;
    }
    
    // Replace item in specific location (index)
    public void Replace(T item, int index)
    {
        // Check if the index is out of range
        if (index >= _length)
            // Throw an exception
            throw new IndexOutOfRangeException();

        // Replace the item in internal array
        _hiddenArr[index] = item;
    }

    // Get item at specific location (index)
    public T Get(int index)
    {
        // Check if the index is out of range
        if (index >= _length) 
            throw new IndexOutOfRangeException();

        // Return item at specific location
        return _hiddenArr[index];
    }

    // Get size of Array List
    public int Size()
    {
        // Return length of Array List
        return _length;
    }

    // Index of specific item if found in Array List
    public int IndexOf(T item)
    {
        // Iterate over the items in Array List
        for (int i = 0; i < _length; i++)
        {
            // Check if each item is equal to given item
            if (_hiddenArr[i].Equals(item))
                // Return the index of given item if found
                return i;
        }

        // Return -1 if given item was not found
        return -1;
    }

    // Last index of specific item in Array List
    public int LastIndexOf(T item)
    {
        // Check if each item is equal to given item from tail
        for (int i = _length - 1; i >= 0; i--)
        {
            // Return the last index of given item if found
            if (_hiddenArr[i].Equals(item))
                return i;
        }
        
        // Return -1 if given item was not found 
        return -1;
    }

    // Remove a specific item from Array List
    public bool Remove(T item)
    {
        // Find an index of an item
        int index = IndexOf(item);
        // Check if item is in Array List
        if (index == -1)
            // Return false if item was not found
            return false;
        
        // Call Remove method
        Remove(index);
        
        // Return true to show that item was removed
        return true;
    }
    
    // Remove an item at specific location (index)
    public T Remove(int index)
    {
        // Check if the index is out of range
        if (index >= _length || index < 0)
            // Throw an exception if index is out of range
            throw new IndexOutOfRangeException();
        
        // Create temp variable for returning
        T temp = _hiddenArr[index];
        
        // Shift every item from given to the left
        for (int i = index; i < _length - 1; i++)
        {
            _hiddenArr[i] = _hiddenArr[i + 1];
        }
        
        // Decrement the length of Array List
        _length--;
        
        // Return value if removed from Array List
        return temp;
    }

    // Remove all items in collection from Array List
    public void RemoveAll(IEnumerable<T> collection)
    {
        // Iterate over items in collection
        foreach(T item in collection)
        {
            // Call Remove method for each item
            Remove(item);
        }
    }

    // Clear Array List
    public void Clear()
    {
        _hiddenArr = new T[5];
        _length = 0;
    }

    // Get an Array of items from Array List
    public T[] ToArray()
    {
        // Create new Array with size of Array List
        T[] outputArr = new T[_length];

        // Iterate over items in Array List
        for (int i = 0; i < _length; i++)
        {
            // Copying items from Array List to Array
            outputArr[i] = _hiddenArr[i];
        }

        // Return Array
        return outputArr;
    }

    // Sort method (coming soon)
    public void Sort()
    {
        throw new NotImplementedException();
    }

    // Check if item is in Array List
    public bool Contains(T item)
    {
        // Iterate over items in Array List
        for (int i = 0; i < _length; i++)
        {
            // Check if item equal to given item
            if (_hiddenArr[i].Equals(item))
                // Return true if it is equal (was found)
                return true;
        }
    
        // Return false after iterating (wasn't found)
        return false;
    }

    // IEnumerator to iterate through items of Array List
    public IEnumerator<T> GetEnumerator()
    {
        // Iterating over Array List to yield each item
        for (int i = 0; i < _length; i++)
        {
            yield return _hiddenArr[i];
        }
    }

    // Non-generic IEnumerator
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
    
}