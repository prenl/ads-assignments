# Assignment-2 of ADS course
# ASTANA IT UNIVERSITY
### SE-2203, Abdrakhmanov Yelnur 🇰🇿

IMyList interface
- `Size()` - int
- `Contains(object item)` - bool
- `Add(object item)` - void
- `Add(object item, int index)` - void
- `Remove(object item)` - object
- `Clear()` - void
- `Get(int index)` - object
- `IndexOf(object item)` - int
- `LastIndexOf(object item)` - int
- `Sort()` - void

MyArrayList class
- `Add(object item)` - void, add element to list
- `Add(object item, int index)` - void, add element at specific index
- `AddAll(IEnumerable<object> list)` - void, add collection of elements to list
- `Replace(object item, int index)` - void, replace element at specific index
- `Get(int index)` - object, return element at given index
- `Size()` - int, return length of list
- `IndexOf(object item)` - int, return index of item in list
- `LastIndexOf(object item)` - int, return last occurance index of item in list
- `Remove(int index)` - object, remove element at specific index
- `Remove(object item)` - bool, remove specific element if found
- `RemoveAll(IEnumerable<object> list)` - void, remove elements of collection from list
- `Clear()` - void, clear list
- `Sort()` - void, bubble sort
- `ToArray()` - array, return array of elements of list
- `Contains(object item)` - bool, return true if item is in list
- List is iterable using IEnumerator

#

MyNode class
- `Data` - object field
- `Prev` - object field, reference to the previous node
- `Next` - object field, reference to the next node

#

MyLinkedList class
- `Add(object item)` - void, add item to the end of the list
- `Add(object item, int index)` - void, add item at specific index
- `AddAll(IEnumerable<object> list)` - void, add items of collection to the end of the list
- `AddFirst(object item)` - void, add item to the head of the list
- `Clear()` - void, clear list
- `Replace(object item, int index)` - void, replace item at specific index
- `Get(int index)` - object, return element at specific index
- `GetFirst()` - object, return head of the list
- `GetLast()` - object, return tail of the list
- `Remove(int index)` - object, remove element at specific index
- `Remove(object item)` - bool, remove specific element if found
- `IndexOf(object item)` - int, return index of item in list
- `LastIndexOf(object item)` - int, return last occurance index of item in list
- `Contains(object item)` - bool, return true if object is in the list
- `Size()` - int, return length of the list
- `Sort()` - void, bubble sort
- List is iterable using IEnumerator

Assignment was done on `C# (.net 7.0)`, using `JetBrains Rider IDE`
