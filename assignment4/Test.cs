namespace assignment4;

public class Test
{
    public static void Main(string[] args)
    {
        MyBinarySearchTree<int, string> tree = new MyBinarySearchTree<int, string>();
        
        Console.WriteLine("> Empty? " + tree.Empty());

        Console.WriteLine("> Filling the tree...");
        tree.Put(0, "zero");
        tree.Put(3, "one");
        tree.Put(1, "three");
        tree.Put(13, "13teen");
        tree.Put(7, "seven");
        tree.Put(11, "eleven");
        Console.WriteLine("> Tree filled.");
        
        Console.WriteLine("> Empty? " + tree.Empty());
        Console.WriteLine();
        Console.WriteLine("> Maximum value => " + tree.Max());
        Console.WriteLine("> Minimum value => " + tree.Min());
        Console.WriteLine();

        Console.WriteLine("> All values => ...");
        foreach (KeyValuePair<int, string> keyvalue in tree)
        {
            Console.WriteLine(keyvalue);
        }

        Console.WriteLine("> Size: " + tree.Size());
    }
}