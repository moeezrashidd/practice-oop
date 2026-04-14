using System;

public class Employee
{
	public int id;
	public string name;
	public string empType;

    //Default constructor

	public Employee()
	{
		this.id = 0;
		this.name = "Unknown";
		this.empType = "Unknown";
	}
    //Parameterized constructor

	public Employee(int id, string name, string empType)
	{
		this.id = id;
		this.name = name;
		this.empType = empType;
    }

}


class EmployeeMain
{
	public static void Run(string[] args)
	{
		Employee e1 = new Employee();
		Console.WriteLine("Employee 1: ID = " + e1.id + ", Name = " + e1.name + ", Type = " + e1.empType);
		Employee e2 = new Employee(101, "Alice", "Full-Time");
		Console.WriteLine("Employee 2: ID = " + e2.id + ", Name = " + e2.name + ", Type = " + e2.empType);
	}
}
