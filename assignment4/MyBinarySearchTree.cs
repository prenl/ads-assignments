using System.Collections;

namespace assignment4;

public class MyBinarySearchTree<K, V> : IEnumerable<K> where K : IComparable<K>
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
        MyNode<K, V>? parent = null; // Create parent variable

        // Iterate through MyBST while not found
        while (!temp.Key.Equals(key))
        {
            // Check if given key is less/more than current's key
            switch (key.CompareTo(temp.Key))
            {
                case < 0: // less
                    parent = temp; // Set parent's reference to current node
                    temp = temp.Left; // Move to the left side of MyBST
                    break;
                case > 0: // more
                    parent = temp; // Set parent's reference to current node
                    temp = temp.Right; // Move to the right side of MyBST
                    break;
            }
        }

        // Check if node has no left and right
        if (temp.Left == null && temp.Right == null)
        {
            // Check if node is parent's left or right reference
            if (parent.Left != null && parent.Left.Equals(temp))
                parent.Left = null; // Set parent's left reference as null
            else if (parent.Right != null && parent.Right.Equals(temp))
                parent.Right = null; // Set parent's right reference as null
        }
        // if node has only left or right
        else if (temp.Left == null || temp.Right == null)
        {
            // Check if missing reference is left
            if (temp.Left == null)
            {
                // Check if parent's left reference is current node
                if (parent.Left.Equals(temp))
                    parent.Left = temp.Right; // Set parent's left reference as current's right reference
                else
                    parent.Right = temp.Right; // Set parent's right reference as current's right reference
            }
            // Missing reference is right
            else
            {
                // Check if parent's left reference is current node
                if (parent.Left.Equals(temp))
                    parent.Left = temp.Left; // Set parent's left reference as current's left reference
                else
                    parent.Right = temp.Left; // Set parent's right reference as current's left reference
            }
        }
        // If node has both left and right references
        else
        {
            MyNode<K, V> removed = temp; // Save reference to node that will be deleted
            temp = temp.Right; // Move to the right side of MyBST

            // Iterate throught MyBST to find needed node
            while (temp.Left != null)
            {
                parent = temp; // Set parent as current
                temp = temp.Left; // Move to the left side of MyBST
            }

            parent.Left = null; // Delete node
            removed = temp; // Replace deleted node by found node (173 line)
        }
    }

    // Converts data to Arraylist
    private void FillArray(MyNode<K, V> node, ArrayList list)
    {
        if (node == null) return;

        FillArray(node.Left, list);
        list.Add(node);
        FillArray(node.Right, list);
    }

    public IEnumerator<K> GetEnumerator()
    {
        if (Empty()) yield break;

        ArrayList nodes = new ArrayList();
        FillArray(_root, nodes);

        foreach (MyNode<K, V> node in nodes)
            yield return node.Key;
    }   

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}