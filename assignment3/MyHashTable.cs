﻿namespace assignment3;

public class MyHashTable<K, V>
{
    // HashNode class -> stores key, value and pointer to the next bucket or item
    private class MyHashNode<K, V>
    {
        public K Key;

        public V Value;

        // Reference to the next node
        public MyHashNode<K, V>? Next;

        // Constructor that takes key/value and put inside node
        public MyHashNode(K key, V value)
        {
            Key = key;
            Value = value;
        }

        public override string ToString()
        {
            return "{ " + Key + " " + Value + " }";
        }
    }

    private MyHashNode<K, V>[] _chainArray; // Chain of buckets
    private int M = 11; // Default amount of buckets
    private int _size; // Amount of items in whole HashTable

    // Non default constructor that takes M - amount of buckets after creating HashTable
    public MyHashTable(int m)
    {
        M = m;
        _chainArray = new MyHashNode<K, V>[M]; // Create M amounts of bucket
        _size = 0;
    }

    // Default constructor creates 11 buckets
    public MyHashTable() : this(11)
    {
    }

    // Method takes key and return bucket's number that will take this item
    private int Hash(K key)
    {
        int index = key.GetHashCode(); // Get HashCode from object
        index %= M; // Find index of bucket
        return index; // Return index
    }

    // Method takes key/value and put inside HashTable
    public void Put(K key, V value)
    {
        int index = Hash(key); // Find index of bucket
        MyHashNode<K, V> newNode = new MyHashNode<K, V>(key, value); // Create new node with given data
        newNode.Next = _chainArray[index]; // Set new node's next reference to head of bucket
        _chainArray[index] = newNode; // Set new node as head of bucket
        _size++; // Increment size
    }

    // Method takes key return value
    public V? Get(K key)
    {
        int index = Hash(key); // Find index of bucket
        MyHashNode<K, V>? temp = _chainArray[index]; // Take head of list as temp

        // Iterate through list while key is not equal to given
        while (temp != null)
        {
            // Check if key equals to given
            if (temp.Key.Equals(key))
                return temp.Value; // Return Value if found

            temp = temp.Next;
        }

        // Return default if not found
        return default;
    }

    // Method takes key to remove from HashTable and return value
    public V? Remove(K key)
    {
        int index = Hash(key); // Find index of bucket
        MyHashNode<K, V>? current = _chainArray[index]; // Take head of list as temp
        MyHashNode<K, V>? prev = null;

        // Iterate through list while key is not equal to given
        while (current != null)
        {
            // Check if key equals to given
            if (current.Key.Equals(key))
            {
                // Check if previous is null
                if (prev == null) 
                {
                    _chainArray[index] = current.Next; // Set current's next as head of bucket
                }
                // If next is null
                else if (current.Next == null)
                {
                    prev.Next = null; // Set previous' next reference as null
                }
                // If previous and next are not null
                else 
                {
                    prev.Next = current.Next; // Set previous' next reference to current's next
                }
                
                _size--; // Decrement the size of table
                return current.Value; // Return value of removed key
            }
            
            prev = current;
            current = current.Next;
        }

        // Return default (null) if not found
        return default;
    }
    
    // Method takes value and return true if found
    public bool Contains(V value)
    {
        MyHashNode<K, V>? temp; // Create temp value to iterate buckets
        
        // For each loop through every bucket in HashTable
        foreach (MyHashNode<K, V> head in _chainArray)
        {
            temp = head;
            
            // Iteration through bucket's items
            while (temp != null)
            {
                // Check if value equals to given
                if (temp.Value.Equals(value))
                {
                    return true; // Return true if found
                }
                
                temp = temp.Next;
            }
        }
        
        return false; // Return false if not found
    }

    // Method takes value and returns key if found
    public K? GetKey(V value)
    {
        MyHashNode<K, V> temp;
        
        // For each loop through every bucket in HashTable
        foreach (MyHashNode<K, V> head in _chainArray)
        {
            temp = head;
            
            // Iteration through bucket's items
            while (temp != null)
            {
                // Check if value equals to given
                if (temp.Value.Equals(value))
                {
                    return temp.Key; // Return key if found
                }
                
                temp = temp.Next;
            }
        }

        return default; // Return null if not found
    }

    // Method returns size
    public int Size()
    {
        return _size;
    }

    public override string ToString()
    {
        string output = "";
        int counter;

        MyHashNode<K, V>? temp;

        for (int i = 0; i < M; i++)
        {
            counter = 0;
            temp = _chainArray[i];

            while (temp != null)
            {
                counter++;
                temp = temp.Next;
            }
            output += "Bucket №" + i + ": " + counter + "\n";
        }

        return output;
    }
    
}