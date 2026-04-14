using System;

public class Book
{
    public string Title;
    public string Author;
    public int Year;


    public Book(string title)
    {
        this.Title = title;
    }


    public Book(string title, string author)
    {
        this.Title = title;
        this.Author = author;
    }

    
    public Book(string title, string author, int year)
    {
        this.Title = title;
        this.Author = author;
        this.Year = year;
    }

   
    public void Display()
    {
        Console.WriteLine("Title: " + Title);
        Console.WriteLine("Author: " + Author);
        Console.WriteLine("Year: " + Year);
        
    }
}

class BookMain
{
    public static void Run(string[] args)
    {
        Book b1 = new Book("The Great Gatsby");
        Book b2 = new Book("To Kill a Mockingbird", "Harper Lee");
        Book b3 = new Book("Way to Hell", "Moeez Rashid", 2025);

        b1.Display();
        b2.Display();
        b3.Display();
    }
}