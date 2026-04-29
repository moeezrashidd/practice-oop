using System;

public class Person
{
	private string name; 
	protected int age;

	public Person(string name, int age)
	{
		this.name = name;
		this.age = age;
    }

	public void DisplayInfo()
	{
		Console.WriteLine($"Name: {name}, Age: {age}");
    }

	public abstract void Role(string rol)
	{
		string role = rol;
		Console.WriteLine("Role: " + role);
	}

}

public class Employee : Person
{
	protected string salary;
	public Employee(string name, int age, string salary) : base(name, age)
	{
		this.salary = salary;
	}
	public override void Role()
	{
		Console.WriteLine("Role: " + );
	}
}