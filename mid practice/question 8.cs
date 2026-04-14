using System;

public class Department
{
    public string empName;
    public string EmpID;
    public int salary;


    public Department (string empName, string EmpID, int salary)
    {
        this.empName = empName;
        this.EmpID = EmpID;
        this.salary = salary;
    }

    public Department DeepCopy() { 
        return new Department (this.empName = empName,this.EmpID = EmpID, this.salary = salary );
    }

}


class DepartmentMain
{
    public static void Run(string[] args)
    {
        Department d1 = new Department("John Doe", "E123", 50000);
        Console.WriteLine("Employee Name: " + d1.empName + ", Employee ID: " + d1.EmpID + ", Salary: " + d1.salary);
        Department d2 = d1; // shallow copy

        Department d3 = d1.DeepCopy(); // deep copy

        Console.WriteLine("Shallow Copy - Employee Name: " + d2.empName + ", Employee ID: " + d2.EmpID + ", Salary: " + d2.salary);
        Console.WriteLine("Deep Copy - Employee Name: " + d3.empName + ", Employee ID: " + d3.EmpID + ", Salary: " + d3.salary);
        d3.empName = "Jane Smith";
        Console.WriteLine("Deep Copy - Employee Name: " + d3.empName + ", Employee ID: " + d3.EmpID + ", Salary: " + d3.salary);
        d1.empName = "John maesh";
        Console.WriteLine("Shallow Copy - Employee Name: " + d2.empName + ", Employee ID: " + d2.EmpID + ", Salary: " + d2.salary);

    }
}