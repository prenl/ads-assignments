namespace assignment4;

public class Test
{
    public static void FillTree(MyBinarySearchTree<int, string> tree) 
    {
        Console.WriteLine("> Filling the tree...");
        tree.Put(0, "zero");
        tree.Put(11, "eleven");
        tree.Put(3, "three");
        tree.Put(13, "13teen");
        tree.Put(7, "seven");
        tree.Put(12, "eleven");
        Console.WriteLine("> Tree filled.");
    }

    public static void Main(string[] args)
    {
        MyBinarySearchTree<int, string> tree = new MyBinarySearchTree<int, string>();
        
        Console.WriteLine("> Empty? " + tree.Empty());

        FillTree(tree);

        Console.WriteLine("\n> Empty? " + tree.Empty());
        Console.WriteLine("> Maximum value => " + tree.Max());
        Console.WriteLine("> Minimum value => " + tree.Min());
        tree.Delete(3);
        Console.WriteLine("> Key 3 deleted");

        Console.WriteLine("\n> All values => ...");
        foreach (KeyValuePair<int, string> keyvalue in tree)
        {
            Console.WriteLine("> " + keyvalue);
        }

        Console.WriteLine("\n> Items: " + tree.Size());
        Console.WriteLine("");
    }
}