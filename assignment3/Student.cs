namespace assignment3;

public class Student
{
    private int _idGen = 0;
    public int Id { get; set; }
    public int Age { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Group { get; set; }
    
    public Student(string firstName, string lastName, string group, int age)
    {
        Id = _idGen++;
        Age = age;
        FirstName = firstName;
        LastName = lastName;
        Group = group;
    }

    public override string ToString()
    {
        return "{id=" + Id + 
               ", age=" + Age + 
               ", first_name='" + FirstName + 
               "', last_name='" + LastName +
               "', group='" + Group + 
               "'}";
    }
}