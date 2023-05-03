namespace assignment4;

public class MyBinarySearchTree<T> where T : IComparable<T>
{
    public class MyNode<T> where T : IComparable<T>
    {
        public T Data;
        public MyNode<T> Left;
        public MyNode<T> Right;
        
        public MyNode(T data)
        {
            Data = data;
        }
    }

    private MyNode<T>? _root;
    private int _size;

    public bool Empty()
    {
        return _root == null;
    }

    public MyNode<T> Insert(T value, MyNode<T>? current)
    {
        if (current == null)
            return new MyNode<T>(value);

        if (value.Equals(current.Data))
        {
            current.Right = Insert(value, current.Right);
        }
        else
        {
            current.Left = Insert(value, current.Left);
        }

        return null;
    }
    
}