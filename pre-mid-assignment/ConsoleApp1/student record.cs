using System;
public class StudentRecord
{
    private string name;
    private string rollNumber;
    private int[] marks;

    public StudentRecord(string name, string rollNumber)
    {
        this.name = name;
        this.rollNumber = rollNumber;
        this.marks = new int[5] { 85, 72, 68, 91, 78 };
    }

    public void setMarks(int index, int marks)
    {
        if (index >= 0 && index < 5)
        {
            if (marks < 0)
                this.marks[index] = 0;
            else if (marks > 100)
                this.marks[index] = 100;
            else
                this.marks[index] = marks;
            Console.WriteLine($"Marks for subject {index + 1} set to {this.marks[index]}");
        }
    }

    public string calculateGrade()
    {
        int sum = 0;
        for (int i = 0; i < 5; i++)
            sum += marks[i];

        double avg = sum / 5.0;

        if (avg >= 85) return "A";
        else if (avg >= 70) return "B";
        else if (avg >= 50) return "C";
        else return "Fail";
    }

    public void AddBonusMarks(int bonus)
    {
        for (int i = 0; i < 5; i++)
        {
            if (marks[i] + bonus <= 100)
                marks[i] += bonus;
            else
                marks[i] = 100;
        }
        Console.WriteLine($"Bonus marks of {bonus} added to all subjects.");
    }
}

class StudentRecordMain
{
    public static void Run(string[] args)
    {
        StudentRecord student = new StudentRecord("John Doe", "CS-001");

        student.setMarks(0, 95);
        student.setMarks(1, -10);
        student.setMarks(2, 150);

        student.AddBonusMarks(10);

        Console.WriteLine($"Grade: {student.calculateGrade()}");
    }
}