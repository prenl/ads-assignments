namespace assignment3;

public class MyHashTable<K, V>
{
    private class HashNode<K, V>
    {
        private K _key;
        private V _value;

        public HashNode(K key, V value)
        {
            this._key = key;
            this._value = value;
        }

        public override string ToString()
        {
            return "{ " + _key + " " + _value + " }";
        }
    }

    private HashNode<K, V>[] _chainArray;
    private int _m = 11;
    private int size;
    
    


}