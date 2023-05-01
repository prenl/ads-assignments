namespace assignment3;

public class MyTestingClass
{
    private int _idGen = 0;
    private int _id;
    private string _name;
    private string _secondname;
    
    public MyTestingClass()
    {
        _id = _idGen++;
    }

    public MyTestingClass (string name, string secondname) : this()
    {
        _name = name;
        _secondname = secondname;
    }
    
    public override int GetHashCode()
    {
        int hashCode = 13;

        hashCode *= 31 + _id;
        foreach (char b in _name)
        {
            hashCode += b;
        }
        
        
        hashCode *= 31;
        foreach (char a in _secondname)
        {
            hashCode += a;
        }

        
        hashCode *= 31;
        Console.WriteLine(hashCode);
        return hashCode;
    }

    public override string ToString()
    {
        return "{id=" + _id + ", fname='" + _name + "', lname='" + _secondname + "'}";
    }
}