using System.Collections;

namespace assignment2;

// MyLinkedList extends IEnumerable to be iterable
// MyLinkedList can take any objects (T)
public class MyLinkedList<T> : IEnumerable<T>, IMyList<T>
{
    
    // Private class inside Linked List that defines the node structure
    private class MyNode
    {
        
        public readonly T Data; // Data stored inside the node
        public MyNode Prev; // Reference to previous node
        public MyNode Next; // Reference to next node

        public MyNode(T data)
        {
            this.Data = data;
        }
        
    }

    private MyNode _head; // Reference to the first node
    private MyNode _tail; // Reference to the last node
    private int _length; // The number of nodes in Linked List

    // Add item to the end of Linked List
    public void Add(T item)
    {
        // Create new node with item inside (as data)
        MyNode newNode = new MyNode(item);
        
        // Check if Linked List is empty
        if (_length == 0)
        {
            // Put new node as first and last node of linked list if its empty
            _head = newNode;
            _tail = newNode;
        }
        else
        {
            // Set the previous node of the new node to the tail
            newNode.Prev = _tail;
            
            // Reference to the next node in the current tail to the new node
            _tail.Next = newNode;
            
            // Update the current tail to new node
            _tail = newNode;
        }

        // Increment the length of Linked List
        _length++;
    }

    // Add items from collection to the end of Linked List
    public void AddAll(IEnumerable<T> collection)
    {
        // Iterate over the items in collection
        foreach (T item in collection)
        {
            // Call Add method for every item in the collection
            Add(item);
        }
    }

    // Add new item to the start of Linked List
    public void AddFirst(T item)
    {
        // Call Add method at specific index
        Add(item, 0);
    }

    // Clear Linked List
    public void Clear()
    {
        _length = 0;
        _head = null;
        _tail = null;
    }

    // Add item at specific index
    public void Add(T item, int index)
    {
        // Check if index is out of range
        if (index < 0 || index > _length)
        {
            // Throw an exception
            throw new IndexOutOfRangeException();
        }

        // Create new node with given item as data
        MyNode newNode = new MyNode(item);
        
        // Check if given index is 0
        if (index == 0)
        {
            // Place current head as a reference to the next node of new node
            newNode.Next = _head;
            
            // Place new node as a reference to the previous node of current head
            _head.Prev = newNode;
            
            // Update current head node
            _head = newNode;
        }
        
        // Check if index is equal to the length of Linked List
        else if (index == _length)
        {
            // Place current tail as a reference to the previous node of new node
            newNode.Prev = _tail;
            
            // Place new node as a reference to the next node of current tail
            _tail.Next = newNode;
            
            // Update current tail node
            _tail = newNode;
        }
        else
        {
            // Find node at given index using iteration
            MyNode temp = _head;
            for (int i = 0; i < index; i++)
            {
                temp = temp.Next;
            }
            
            // Place current node as a reference to the new node's next node
            newNode.Next = temp;
            // Place current node's previous node as a reference to the new node's previous node
            newNode.Prev = temp.Prev;
            
            // Update current node's previous and next node
            temp.Prev.Next = newNode;
            temp.Next.Prev = newNode;
        }
    
        // Incrementing length of Linked List
        _length++;
    }

    // Replace item at specific index
    public void Replace(T item, int index)
    {
        // Check if index is out of range
        if (index < 0 || index >= _length)
            throw new IndexOutOfRangeException();

        // Create new node with given item as data
        MyNode newNode = new MyNode(item);
        // Find node at given index using iteration
        MyNode temp = _head;
        for (int i = 0; i < index; i++)
        {
            temp = temp.Next;
        }
        
        // Check if given index is linked list's head
        if (temp.Prev == null)
        {
            // Change references to and for the next node 
            newNode.Next = temp.Next;
            temp.Next.Prev = newNode;
            // Update current head of Linked List
            _head = newNode;
        }
        
        // Check if given index is linked list's tail
        else if (temp.Next == null)
        {
            // Replace references to and for the previous node
            newNode.Prev = temp.Prev;
            temp.Prev.Next = newNode;
            // Update current tail of Linked List
            _tail = newNode;
        }
        else
        {
            // Replacing the references for the previous and next nodes
            newNode.Prev = temp.Prev;
            newNode.Next = temp.Next;
            newNode.Prev.Next = newNode;
            newNode.Next.Prev = newNode;
        }
    }
    
    // Get the item at specific index
    public T Get(int index) 
    {
        // Check if index is out of range
        if (index >= _length)
            throw new IndexOutOfRangeException();
        
        // Find node at given index using iteration
        MyNode temp = _head;
        for (int i = 0; i < index; i++) {
            temp = temp.Next;
        }
        
        // Return data inside found node
        return temp.Data;
    }

    // Get head's data
    public T GetFirst()
    {
        return _head.Data;
    }

    // Get tail's data
    public T GetLast()
    {
        return _tail.Data;
    }

    // Remove item at specific index
    public T Remove(int index)
    {
        // Check if index is out of range
        if (index < 0 || index >= _length)
            throw new IndexOutOfRangeException();

        // Find node at given index using iteration 
        MyNode temp = _head;
        for (int i = 0; i < index; i++)
        {
            temp = temp.Next;
        }

        // Check if there is reference to the next node in found node
        if (temp.Next != null)
        {
            temp.Next.Prev = temp.Prev;
        }
        // Check if found node is the head of Linked List
        if (temp.Prev == null)
        {
            _head = temp.Next;
        }
        else
        {
            temp.Prev.Next = temp.Next;
        }
        
        // Decrement the length of Linked List
        _length--;
        
        // Return removed item
        return temp.Data;
    }

    public bool Remove(T item)
    {
        // Find node with given data using iteration
        MyNode temp = _head;
        for (int i = 0; i < _length; i++)
        {
            if (temp.Data.Equals(item))
            {
                break;
            }
            temp = temp.Next;
        }
        
        // Check if item was found
        if (temp == null)
            return false;
        
        // Check if there is reference to the next node in found node
        if (temp.Next != null)
        {
            temp.Next.Prev = temp.Prev;
        }
        // Check if found node is the head of Linked List
        if (temp.Prev == null)
        {
            _head = temp.Next;
        }
        else
        {
            temp.Prev.Next = temp.Next;
        }

        // Decrement the length of Linked List
        _length--;
        
        // Return true to confirm that item was removed
        return true;
    }

    // Check if Linked List has specific item
    public bool Contains(T item)
    {
        // Iterate over nodes in Linked List
        MyNode temp = _head;
        for (int i = 0; i < _length; i++)
        {
            // Check if each node's data is equal to given data
            if (temp.Data.Equals(item))
                // Return true if found
                return true;

            temp = temp.Next;
        }
        // Return false after iteration if was not found
        return false;
    }
    
    // Find index of given item
    public int IndexOf(T item)
    {
        // Iterate over nodes in Linked List
        MyNode temp = _head;
        for (int i = 0; i < _length; i++)
        {
            // Check if each node's data is equal to given data
            if (temp.Data.Equals(item))
                // Return the index of given item
                return i;

            temp = temp.Next;
        }

        // Return -1 if item was not found
        return -1;
    }
    
    // Find last index of given item
    public int LastIndexOf(T item)
    {
        // Iterate over nodes in Linked List from tail
        MyNode temp = _tail;
        for (int i = _length - 1; i >= 0; i--)
        {
            // Check if each node's data is equal to given data
            if (temp.Data.Equals(item))
                // Return the index of given item
                return i;

            temp = temp.Prev;
        }
        
        // Return -1 if item was not found
        return -1;
    }

    // Get the length of Linked List
    public int Size()
    {
        return _length;
    }
    
    // IEnumerator to iterate through nodes' data in Linked List
    public IEnumerator<T> GetEnumerator()
    {
        var temp = _head;

        while (temp != null)
        {
            yield return temp.Data;
            temp = temp.Next;
        }
    }
    
    // Non-generic IEnumerator
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
    
}