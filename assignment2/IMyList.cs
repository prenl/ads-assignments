namespace assignment2;

public interface IMyList<T>
{
    int Size();
    bool Contains(T item);
    void Add(T item);
    void Add(T item, int index);
    bool Remove(T item);
    T Remove(int index);
    void Clear();
    T Get(int index);
    int IndexOf(T item);
    int LastIndexOf(T item);
    void Sort();
}