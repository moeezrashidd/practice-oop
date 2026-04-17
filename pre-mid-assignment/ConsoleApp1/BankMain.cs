using System;

public class Account
{
	private int age {get;set;}
	private string name {get;set;}
	private double blance {get;set;}
	private int accnum { get;set;}
	public static int totalAccounts = 0;

	public double Blance
	{
		get { return blance;}

		set
		{
			if(value < 0)
			{
				Console.WriteLine("Invalid Blance");
			}
			else
			{
				this.blance = value;
			}
		}
	}

	public Account(int age, string name, double blance , int accNum)
	{
		this.age = age;
		this.name = name;
		this.Blance = blance;
		this.accnum = accNum;
		totalAccounts++;
	}

	public void Deposit(double bal)
	{
		if(bal <= 0)
		{
			Console.WriteLine("Invalid Blance");
		}
		else
		{
			this.blance += bal;
			Console.WriteLine("blance is added successfully");
		}
	}

	public void Withdraw(double widraw)
	{
		if (widraw <= 0 || widraw > blance)
		{
			Console.WriteLine("Invalid or insufficient blance..");
		}
		else 
		{ 
			blance -= widraw;
			Console.WriteLine("Blance is widrawl is successfully;;");
		}
	}
}


class BankMain
{
    public static void Run(string[] args)
    {
        Console.WriteLine("=== BANKING SYSTEM ===\n");
        Account myAccount = new Account(25, "John Doe", 1000, 123456);
        Console.WriteLine("\n--- Transactions ---");
        myAccount.Deposit(500);
        myAccount.Withdraw(300);
         myAccount.Withdraw(2000);
        myAccount.Deposit(-100);
        myAccount.Withdraw(-50);
        Console.WriteLine("\n--- Final Account Status ---");
        Account anotherAccount = new Account(30, "Jane Smith", 5000, 789012);
        Console.WriteLine($"\nTotal accounts created in system: {Account.totalAccounts}");

        
    }
}
