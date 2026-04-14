using System;

public class Student
{
    public string Name;
    public int RollNo;

    private int marks;

    public int Marks
    {
        get { return marks; }
        set
        {
            if (value < 0 || value > 100)
            {
                throw new ArgumentOutOfRangeException("Marks must be between 0 and 100.");
            }
            marks = value;
        }
    }

    public Student(string name, int rollno, int marks)
    {
        this.Name = name;
        this.RollNo = rollno;
        this.Marks = marks;
    }
}

class StudentMain
{
    public static void Run(string[] args)
    {
        try
        {
            Student s1 = new Student("Ali", 101, 85);
            Console.WriteLine("Marks: " + s1.Marks);

            Student s2 = new Student("Ahmed", 102, 120); 
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}