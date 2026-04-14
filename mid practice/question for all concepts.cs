using System;

 class Student
{	
	public string name;
	public int rollNumber;
	private int marks;

	public int Marks { 
		get { return marks; }

		set
		{
			if (value <0 || value >100)
			{
				Console.WriteLine("Invalid marks. Marks should be between 0 and 100.");
			}
			else
			{
				marks = value;
            }
        }
    }

	public Student(string name, int rollNumber)
	{
		this.name = name;
		this.rollNumber = rollNumber;
		this.Marks = 0; // Default marks

    }

	public Student(string name, int rollNumber, int marks)
	{
		this.name = name;
		this.rollNumber = rollNumber;
		this.Marks = marks; // Use the property to set marks with validation
    }

}
