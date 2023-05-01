# Assignment-2 of ADS course
# ASTANA IT UNIVERSITY
### SE-2203, Abdrakhmanov Yelnur 🇰🇿

#

To test this assignment you should run Test.cs file in Test directory
It will create 10000 random students and keys for it
After creating it outputs number of nodes in each bucket

#

MyHashNode class
- `Key` - object field
- `Value` - object field
- `Next` - object field, reference to the next node

#

MyHashTable
- `MyHashTable()` - default constructor, creates MyHashTable with 11 buckets
- `MyHashTable(int M)` - default constructor, creates MyHashTable with M buckets
- `Hash(K key)` - int, finds index of bucket
- `Put(K key, V value)` - void, puts key/value inside hashtable
- `Remove(K key)` - V, removes key/value from hashtable returning value
- `Get(K key)` - V, get value by key
- `Contains(V value)` - bool, finds value in hashtable
- `GetKey(V value)` - K, finds key by value returning key
- `Size()` - int, return amount of items
- `ToString()` - string, shows amount of items in each bucket

#

MyTestingClass
- `GetHashCode()` - creates unique int value using every pole

#

Assignment was done on `C# (.net 7.0)`, using `JetBrains Rider IDE`
