namespace assignment3;

public class MyHashTable<K, V>
{
    // HashNode class -> stores key, value and pointer to the next bucket or item
    private class MyHashNode<K, V>
    {
        public K Key;
        public V Value;
        public MyHashNode<K, V>? Next;

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
    
    // Chain of buckets
    private MyHashNode<K, V>[] _chainArray;
    // Default amount of buckets
    private int M = 11;
    // Amount of items in whole HashTable
    private int Size;

    // Non default constructor that takes M - amount of buckets after creating HashTable
    public MyHashTable(int m)
    {
        M = m;
        _chainArray = new MyHashNode<K, V>[M];
        Size = 0;
    }
    
    // Default constructor creates 11 buckets
    public MyHashTable() : this(11)
    {
    }

    // Method takes key and return bucket's number that will take this item
    private int Hash(K key)
    {
        // Get HashCode from object
        int index = key.GetHashCode();
        // Find index of bucket
        index %= M;
        
        // Return index
        return index;
    }

    
}