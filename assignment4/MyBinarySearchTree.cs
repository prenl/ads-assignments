namespace assignment4;

public class MyBinarySearchTree<T> where T : IComparable<T>
{
    private class MyNode<T> where T : IComparable<T>
    {
        public T Data;
        public MyNode<T> Left;
        public MyNode<T> Right;
        
        public MyNode(T data)
        {
            Data = data;
        }
    }

    private MyNode<T> _root;
    private int _size;
}