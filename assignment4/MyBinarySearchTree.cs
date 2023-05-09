﻿namespace assignment4;

public class MyBinarySearchTree<K, V> where K : IComparable<K>
{
    public class MyNode<K, V> where K : IComparable<K>
    {
        public K Key;
        public V Value;
        public MyNode<K, V> Left, Right;
        
        public MyNode(K key, V value)
        {
            Key = key;
            Value = value;
        }
    }

    private MyNode<K, V>? _root;
    private int _size;
    
    // Default constructor that initializes size and root
    public MyBinarySearchTree()
    {
        _size = 0;
        _root = null;
    }

    // Method that check if MyBST is empty
    public bool Empty()
    {
        return _root == null;
    }

    // Method takes key/value and puts inside MyBST
    public void Put(K key, V value)
    {
        // Check if root is null
        if (Empty())
        {
            _root = new MyNode<K, V>(key, value); // Create new node with given key/value and put as root
            return; // The end of the method
        }

        MyNode<K, V>? temp = _root; // Create variable to iterate through MyBST
        MyNode<K, V>? parent = null; // Create parent variable to check whether its more or less than temp

        // Iterate through MyBST
        while (temp != null)
        {
            // Check if given key is more than current key
            if (key.CompareTo(temp.Key) > 0)
            {
                parent = temp; // Set reference of parent to current node
                temp = temp.Right; // Move to the right side of Tree
            }
            // Check if given key is less than current key
            else if (key.CompareTo(temp.Key) < 0)
            {
                parent = temp; // Set reference of parent to current node
                temp = temp.Left; // Move to the left side of Tree
            }
            // If given key is equal to current's key
            else
            {
                temp.Value = value; // Set new value for node
                return; // The end of the method
            }
        }

        // Check whether given key is more than parent's key
        if (key.CompareTo(parent.Key) > 0)
            parent.Right = new MyNode<K, V>(key, value); // Set parent's right reference to node with given key/value
        // Check whether given key is less than parent's key
        else
            parent.Left = new MyNode<K, V>(key, value); // Set parent's left reference to node with given key/value
    }
    
    

}