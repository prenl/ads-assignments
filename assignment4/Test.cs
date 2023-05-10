namespace assignment4;

public class Test
{
    public static void Main(string[] args)
    {
        MyBinarySearchTree<int, string> tree = new MyBinarySearchTree<int, string>();
        
        Console.WriteLine("Empty? " + tree.Empty());
        
        tree.Put(1, "one");
        tree.Put(3, "three");
        tree.Put(0, "zero");
        tree.Put(12, "twelve");
        tree.Put(7, "seven");
        tree.Put(11, "eleven");
        
        tree.Delete(11);
        
        Console.WriteLine("Empty? " + tree.Empty());
        
        Console.WriteLine("1 : " + tree.Get(1));

        foreach (int key in tree)
        {
            Console.WriteLine(key);
        }

        Console.WriteLine("Size: " + tree.Size());
    }
}