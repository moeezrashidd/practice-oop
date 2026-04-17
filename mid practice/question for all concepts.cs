using System;

public class StudentClass
{
    public string name;
    public int rollNumber;
    private int marks;

    public int Marks
    {
        get { return marks; }
        set
        {
            if (value < 0 || value > 100)
            {
                Console.WriteLine("Invalid marks. Marks should be between 0 and 100.");
            }
            else
            {
                marks = value;
            }
        }
    }

    public
        StudentClass(string name, int rollNumber)
    {
        this.name = name;
        this.rollNumber = rollNumber;
        this.Marks = 0; 
    }

    public StudentClass(string name, int rollNumber, int marks)
    {
        this.name = name;
        this.rollNumber = rollNumber;
        this.Marks = marks; 
    }
}

public class StudentClassTest
{
    public static void Run(string[] args)
    {
        StudentClass student1 = new StudentClass("Ali", 101);
        StudentClass student2 = new StudentClass("Ahmed", 102, 85);

        Console.WriteLine("Student 1:");
        Console.WriteLine("Name: " + student1.name);
        Console.WriteLine("Roll Number: " + student1.rollNumber);
        Console.WriteLine("Marks: " + student1.Marks);

        Console.WriteLine();

        Console.WriteLine("Student 2:");
        Console.WriteLine("Name: " + student2.name);
        Console.WriteLine("Roll Number: " + student2.rollNumber);
        Console.WriteLine("Marks: " + student2.Marks);
    }
}