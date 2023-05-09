namespace assignment4;

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

    private MyNode<T>? _root;
    private int _size;

    public bool Empty()
    {
        return _root == null;
    }

}