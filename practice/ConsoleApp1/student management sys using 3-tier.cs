using System;
using System.Collections.Generic;

public class StudentManagementApp
{
    class Student
    {
        public int Id { get; set; }                                         
        public string Name { get; set; }
        public string RollNumber { get; set; }
        public string Course { get; set; }
        public double Percentage { get; set; }

        public Student(int id, string name, string rollNumber, string course, double percentage)
        {
            Id = id;
            Name = name;
            RollNumber = rollNumber;
            Course = course;
            Percentage = percentage;
        }
    }

    class StudentDAL
    {
        private List<Student> students = new List<Student>();

        public bool AddStudent(Student student)
        {
            students.Add(student);
            return true;
        }

        public List<Student> GetAllStudents()
        {
            return students;
        }

        public Student GetStudentByRollNumber(string rollNumber)
        {
            foreach (Student student in students)
            {
                if (student.RollNumber == rollNumber)
                {
                    return student;
                }
            }
            return null;
        }

        public bool DeleteStudent(int id)
        {
            for (int i = 0; i < students.Count; i++)
            {
                if (students[i].Id == id)
                {
                    students.RemoveAt(i);
                    return true;
                }
            }
            return false;
        }

        public double CalculateAveragePercentage()
        {
            if (students.Count == 0)
            {
                return 0;
            }

            double total = 0;
            foreach (Student student in students)
            {
                total += student.Percentage;
            }
            return total / students.Count;
        }
    }

    class StudentBLL
    {
        private StudentDAL dal = new StudentDAL();

        public bool AddStudent(int id, string name, string rollNumber, string course, double percentage)
        {
            // Validation rules
            if (string.IsNullOrEmpty(name))
            {
                Console.WriteLine("Error: Name cannot be empty");
                return false;
            }

            if (string.IsNullOrEmpty(rollNumber))
            {
                Console.WriteLine("Error: Roll number cannot be empty");
                return false;
            }

            if (percentage < 0 || percentage > 100)
            {
                Console.WriteLine("Error: Percentage must be between 0 and 100");
                return false;
            }

            // Check for duplicate roll number
            Student existingStudent = dal.GetStudentByRollNumber(rollNumber);
            if (existingStudent != null)
            {
                Console.WriteLine("Error: Roll number already exists");
                return false;
            }

            Student newStudent = new Student(id, name, rollNumber, course, percentage);
            return dal.AddStudent(newStudent);
        }

        public void DisplayAllStudents()
        {
            List<Student> students = dal.GetAllStudents();

            if (students.Count == 0)
            {
                Console.WriteLine("No students found");
                return;
            }

            Console.WriteLine("\n=== Student List ===");
            foreach (Student student in students)
            {
                Console.WriteLine($"ID: {student.Id} | Name: {student.Name} | Roll No: {student.RollNumber} | Course: {student.Course} | Percentage: {student.Percentage}%");
            }
        }

        public void SearchStudentByRollNumber(string rollNumber)
        {
            if (string.IsNullOrEmpty(rollNumber))
            {
                Console.WriteLine("Error: Roll number cannot be empty");
                return;
            }

            Student student = dal.GetStudentByRollNumber(rollNumber);

            if (student != null)
            {
                Console.WriteLine($"\nStudent Found:");
                Console.WriteLine($"ID: {student.Id}");
                Console.WriteLine($"Name: {student.Name}");
                Console.WriteLine($"Roll Number: {student.RollNumber}");
                Console.WriteLine($"Course: {student.Course}");
                Console.WriteLine($"Percentage: {student.Percentage}%");
            }
            else
            {
                Console.WriteLine("Student not found with roll number: " + rollNumber);
            }
        }

        public bool DeleteStudent(int id)
        {
            if (id <= 0)
            {
                Console.WriteLine("Error: Invalid ID");
                return false;
            }

            bool deleted = dal.DeleteStudent(id);

            if (deleted)
            {
                Console.WriteLine("Student deleted successfully");
            }
            else
            {
                Console.WriteLine("Student not found with ID: " + id);
            }

            return deleted;
        }

        public void CalculateAndDisplayAverage()
        {
            double average = dal.CalculateAveragePercentage();

            if (average == 0 && dal.GetAllStudents().Count == 0)
            {
                Console.WriteLine("No students to calculate average");
            }
            else
            {
                Console.WriteLine($"Class Average Percentage: {average:F2}%");
            }
        }
    }

    public class StudentUI
    {
        public static void Run(string[] args)
        {
            StudentBLL bll = new StudentBLL();
            int nextId = 1;

            while (true)
            {
                Console.WriteLine("\n=== Student Management System ===");
                Console.WriteLine("1. Add New Student");
                Console.WriteLine("2. View All Students");
                Console.WriteLine("3. Search Student by Roll Number");
                Console.WriteLine("4. Delete Student by ID");
                Console.WriteLine("5. Calculate Class Average");
                Console.WriteLine("6. Exit");
                Console.Write("\nSelect option: ");

                string input = Console.ReadLine();
                int choice;

                if (!int.TryParse(input, out choice))
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("\n--- Add New Student ---");

                        Console.Write("Enter Student Name: ");
                        string name = Console.ReadLine();

                        Console.Write("Enter Roll Number: ");
                        string rollNumber = Console.ReadLine();

                        Console.Write("Enter Course: ");
                        string course = Console.ReadLine();

                        Console.Write("Enter Percentage (0-100): ");
                        double percentage;
                        if (!double.TryParse(Console.ReadLine(), out percentage))
                        {
                            Console.WriteLine("Invalid percentage. Student not added.");
                            break;
                        }

                        if (bll.AddStudent(nextId, name, rollNumber, course, percentage))
                        {
                            Console.WriteLine($"Student added successfully with ID: {nextId}");
                            nextId++;
                        }
                        break;

                    case 2:
                        bll.DisplayAllStudents();
                        break;

                    case 3:
                        Console.Write("\nEnter Roll Number to search: ");
                        string searchRoll = Console.ReadLine();
                        bll.SearchStudentByRollNumber(searchRoll);
                        break;

                    case 4:
                        Console.Write("\nEnter Student ID to delete: ");
                        int deleteId;
                        if (int.TryParse(Console.ReadLine(), out deleteId))
                        {
                            bll.DeleteStudent(deleteId);
                        }
                        else
                        {
                            Console.WriteLine("Invalid ID");
                        }
                        break;

                    case 5:
                        bll.CalculateAndDisplayAverage();
                        break;

                    case 6:
                        Console.WriteLine("\nThank you for using Student Management System!");
                        return;

                    default:
                        Console.WriteLine("Invalid option. Please select 1-6");
                        break;
                }
            }
        }
    }
}