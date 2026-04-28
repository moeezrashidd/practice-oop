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

	public abstract void Role()
	{
		string role = "Employee";
		Console.WriteLine("Role: " + role);
	}
	};
}
