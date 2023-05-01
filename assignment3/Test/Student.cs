namespace assignment3;

public class Student
{
    public int Id { get; set; }
    public int Age { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    
    public Student(int id, string firstName, string lastName, int age)
    {
        Id = id;
        Age = age;
        FirstName = firstName;
        LastName = lastName;
    }

    public override string ToString()
    {
        return "{id=" + Id + 
               ", age=" + Age + 
               ", first_name='" + FirstName + 
               "', last_name='" + LastName + "'}";
    }
}