using System;
using System.Collections.Generic;

public class Employee
{
    public string Name;
    public int Salary;

    public Employee(string name, int salary)
    {
        Name = name;
        Salary = salary;
    }
}

public class Department
{
    public string DeptName;
    public List<Employee> Employees;

    public Department(string deptName)
    {
        DeptName = deptName;
        Employees = new List<Employee>();
    }

    
    public Department ShallowCopy()
    {
        return (Department)this.MemberwiseClone();
    }

    
    public Department DeepCopy()
    {
        Department copy = new Department(this.DeptName);

        foreach (Employee emp in this.Employees)
        {
            copy.Employees.Add(new Employee(emp.Name, emp.Salary));
        }

        return copy;
    }

    public void Display(string title)
    {
        Console.WriteLine("\n--- " + title + " ---");
        Console.WriteLine("Department: " + DeptName);

        foreach (var emp in Employees)
        {
            Console.WriteLine("Employee: " + emp.Name + " | Salary: " + emp.Salary);
        }
    }
}

class DepartmentMain
{
    public static void Run(string[] args)
    {
       
        Department d1 = new Department("IT");

        d1.Employees.Add(new Employee("Ali", 50000));
        d1.Employees.Add(new Employee("Sara", 60000));

 
        Department d2 = d1.ShallowCopy();

       
        Department d3 = d1.DeepCopy();

        
        d2.Employees[0].Name = "Changed in Shallow Copy";

        
        d3.Employees[1].Name = "Changed in Deep Copy";

        
        d1.Display("Original Department");
        d2.Display("Shallow Copy Department");
        d3.Display("Deep Copy Department");
    }
}