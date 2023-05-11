using System.Collections;

namespace assignment4;

public class MyBinarySearchTree<K, V> : IEnumerable where K : IComparable<K>
{
    public class MyNode<K, V> where K : IComparable<K>
    {
        public K Key;
        public V Value;
        public MyNode<K, V> Left, Right, Parent;
        
        public MyNode(K key, V value)
        {
            Key = key;
            Value = value;
        }

        public override string ToString()
        {
            return "{key='" + Key + "', value='" + Value + "'}";
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
            _size = 1; // Set size as 1
            return; // The end of the method
        }

        MyNode<K, V>? temp = _root; // Create variable to iterate through MyBST
        MyNode<K, V>? parent = null;

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
                _size++;
                return; // The end of the method
            }
        }

        // Check whether given key is more than parent's key
        if (key.CompareTo(parent.Key) > 0)
        {
            parent.Right = new MyNode<K, V>(key, value); // Set parent's right reference to node with given key/value
            parent.Right.Parent = parent; // Set new node's parent reference
        }
        // Check whether given key is less than parent's key
        else
        {
            parent.Left = new MyNode<K, V>(key, value); // Set parent's left reference to node with given key/value
            parent.Left.Parent = parent; // Set new node's parent reference
        }
        
        _size++; // Increment size
    }

    // Method takes key and gives value
    public V? Get(K key)
    {
        // Check if root is null
        if (Empty()) 
            return default; // default
        
        MyNode<K, V>? temp = _root; // Create new variable to iterate through MyBST

        // Iterate through MyBST
        while (temp != null)
        {
            // Check if given key is equal/less/more than current's key
            switch (key.CompareTo(temp.Key))
            {
                case 0: // equals
                    return temp.Value; // Return value of key
                case < 0: // less
                    temp = temp.Left; break; // Move to the left side of MyBST
                case > 0: // more
                    temp = temp.Right; break; // Move to the right side of MyBST
            }
        }
        
        // Return default value if not found
        return default;
    }
    
    // Method takes key and removes from MyBST
    // Visualization: https://imgur.com/a/YFpB5PU
    public void Delete(K key)
    {
        // Check whether root is null
        if (Empty()) return;
        
        MyNode<K, V>? temp = _root; // Create new variable to iterate through MyBST

        // Iterate through MyBST while not found
        while (!temp.Key.Equals(key))
        {
            if (temp.Left == null || temp.Right == null) throw new KeyNotFoundException("The given key is not found in BST.");
            
            // Check if given key is less/more than current's key
            switch (key.CompareTo(temp.Key))
            {
                case < 0: // less
                    temp.Parent = temp; // Set parent's reference to current node
                    temp = temp.Left; // Move to the left side of MyBST
                    break;
                case > 0: // more
                    temp.Parent = temp; // Set parent's reference to current node
                    temp = temp.Right; // Move to the right side of MyBST
                    break;
            }
        }

        // Check if node has no left and right
        if (temp.Left == null && temp.Right == null)
        {
            // Check if node is parent's left or right reference
            if (temp.Parent.Left != null && temp.Parent.Left.Equals(temp))
                temp.Parent.Left = null; // Set parent's left reference as null
            else if (temp.Parent.Right != null && temp.Parent.Right.Equals(temp))
                temp.Parent.Right = null; // Set parent's right reference as null
        }
        // if node has only left or right
        else if (temp.Left == null || temp.Right == null)
        {
            // Check if missing reference is left
            if (temp.Left == null)
            {
                // Check if parent's left reference is current node
                if (temp.Parent.Left.Equals(temp))
                {
                    temp.Parent.Left = temp.Right; // Set parent's left reference as current's right reference
                    temp.Parent.Left.Parent = temp.Parent; // Set new parent reference
                }
                else
                {
                    temp.Parent.Right = temp.Right; // Set parent's right reference as current's right reference
                    temp.Parent.Right.Parent = temp.Parent;
                }            
            }
            // Missing reference is right
            else
            {
                // Check if parent's left reference is current node
                if (temp.Parent.Right.Equals(temp))
                {
                    temp.Parent.Right = temp.Left; // Set parent's right reference as current's left reference
                    temp.Parent.Right.Parent = temp.Parent;
                }
                else
                {
                    temp.Parent.Left = temp.Left; // Set parent's left reference as current's left reference
                    temp.Parent.Left.Parent = temp.Parent;
                }
            }
        }
        // If node has both left and right references
        else
        {
            MyNode<K, V> removed = temp; // Save reference to node that will be deleted
            temp = temp.Right; // Move to the right side from removed

            // Iterate throught MyBST to find needed node
            while (temp.Left != null)
            {
                temp = temp.Left; // Move to the left side of MyBST
            }

            temp.Parent.Left = null; // Delete node
            temp.Left = removed.Left;
            temp.Right = removed.Right;

            if (removed.Key.CompareTo(removed.Parent.Key) > 0)
                removed.Parent.Right = temp;
            else 
                removed.Parent.Left = temp;
        }
        
        _size--; // Decrement size
    }

    // Method returns amount of nodes
    public int Size()
    {
        return _size;
    }
    
    // Method returns min node
    public KeyValuePair<K, V> Min()
    {
        // Check whether root is empty
        if (Empty()) return default;
        
        MyNode<K, V> temp = _root; // Iterator
        while (temp.Left != null) // Iteration through MyBST
        {
            temp = temp.Left; // Move to the left
        }
        
        // Return most left node's information
        return new KeyValuePair<K, V>(temp.Key, temp.Value); 
    }
    
    // Method returns max node
    public KeyValuePair<K, V> Max()
    {
        // Check whether root is empty
        if (Empty()) return default;
        
        MyNode<K, V> temp = _root; // Iterator
        while (temp.Right != null) // Iteration through MyBST
        {
            temp = temp.Right; // Move to the left
        }
        
        // Return most left node's information
        return new KeyValuePair<K, V>(temp.Key, temp.Value); 
    }

    // Method takes arraylist and root node and fills with items in MyBST
    // It will divide BST on smaller BST while they won't have only root and then add them
    private void InOrderTraversal(ArrayList list, MyNode<K, V> node)
    {
        // Check if current node is the last
        if (node == null) return;
            
        InOrderTraversal(list, node.Left); // Call method with left side of MyBST
        list.Add(new KeyValuePair<K, V>(node.Key, node.Value)); // Add root of original MyBST
        InOrderTraversal(list, node.Right); // Call method with right side of MyBST
        
    }

    // Iterator
    public IEnumerator<KeyValuePair<K, V>> GetEnumerator()
    {
        ArrayList list = new ArrayList(); // Create list for key/value in MyBST
        InOrderTraversal(list, _root); // Fill Array in order traversal

        // Iterate and return
        foreach (KeyValuePair<K, V> keyvalue in list)
            yield return keyvalue;
    }   

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}