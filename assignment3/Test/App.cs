namespace assignment3;

using System;

public class App
{
    public static void Main(string[] args)
    {
        Random random = new Random();
        MyHashTable<MyTestingClass, Student> students = new MyHashTable<MyTestingClass, Student>(7);

        for (int i = 0; i < 10000; i++)
        {
            string fname = "StudentName" + (i + 1);
            string lname = "lastName" + (i + 1);
            students.Put(new MyTestingClass(fname, lname), new Student( random.Next(1, 321321), fname, lname, random.Next(13, 18)));
        }

        Console.WriteLine(students);
        
        
    }
    
}