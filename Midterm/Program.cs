using System;
using System.IO;
using System.Collections.Generic;
using System.Text.Json;

namespace Midterm
{
    class Program
    {
        static string folderPath = @"C:\Users\eshan\OneDrive\Desktop\MidtermProject";

        static string studentFile = "students.json";
        static string gradeFile = "grades.json";

        static void PrintTop()
        {
            Console.Write("╔");
            for (int i = 0; i < 40; i++) Console.Write("═");
            Console.WriteLine("╗");
        }

        static void PrintSeparator()
        {
            Console.Write("╠");
            for (int i = 0; i < 40; i++) Console.Write("═");
            Console.WriteLine("╣");
        }

        static void PrintBottom()
        {
            Console.Write("╚");
            for (int i = 0; i < 40; i++) Console.Write("═");
            Console.WriteLine("╝");
        }

        static void PrintMenu()
        {
            PrintTop();
            Console.WriteLine("║               MAIN MENU                ║");
            PrintSeparator();
            Console.WriteLine("║ 1. Register Student                    ║");
            Console.WriteLine("║ 2. Enroll Student Subjects             ║");
            Console.WriteLine("║ 3. Enter Grades                        ║");
            Console.WriteLine("║ 4. Show Grade by Student               ║");
            Console.WriteLine("║ 5. Exit                                ║");
            PrintBottom();
        }

        static void Main(string[] args)
        {
            while (true)
            {
                PrintMenu();

                Console.Write("Enter Choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        RegisterStudent();
                        break;

                    case "2":
                        EnrollSubjects();
                        break;

                    case "3":
                        EnterGrades();
                        break;

                    case "4":
                        ShowGrades();
                        break;

                    case "5":
                        Console.WriteLine("\nExiting Program. Goodbye!");
                        return;

                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }

        static void RegisterStudent()
        {
            bool addMore = true;

            while (true)
            {

                string first;
                while (true)
                {
                    Console.Write("First Name: ");
                    first = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(first)) // check if empty
                    {
                        Console.WriteLine("Input cannot be empty.");
                        continue;
                    }

                    bool valid = true;
                    foreach (char c in first)
                    {
                        if (!char.IsLetter(c))
                        {
                            valid = false;
                            break;
                        }
                    }

                    if (valid) break;
                    else Console.WriteLine("Invalid Input. Names cannot contain numbers.");
                }
                string mid;
                while (true)
                {
                    Console.Write("Middle Initial: ");
                    mid = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(mid)) // check if empty
                    {
                        Console.WriteLine("Input cannot be empty.");
                        continue;
                    }

                    if (mid.Length == 1 && char.IsLetter(mid[0]))
                        break;
                    else
                        Console.WriteLine("Invalid Middle Initial. Must be one letter only. ");
                }

                string last;
                while (true)
                {
                    Console.Write("Last Name: ");
                    last = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(last))
                    {
                        Console.WriteLine("Input cannot be empty. ");
                        continue;
                    }

                    bool valid = true;
                    foreach (char c in last)
                    {
                        if (!char.IsLetter(c))
                        {
                            valid = false;
                            break;
                        }
                    }

                    if (valid) break;
                    else Console.WriteLine("Invalid Input. Names cannot contain numbers.");
                }

                DateTime birthdate;
                int age;

                // Birthdate input
                while (true)
                {
                    Console.Write("Birthdate (dd/mm/yyyy): ");
                    string input = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(input))
                    {
                        Console.WriteLine("Input cannot be empty.");
                        continue;
                    }

                    if (!DateTime.TryParse(input, out birthdate))
                    {
                        Console.WriteLine("Invalid birthdate.");
                        continue;
                    }

                    // Calculate age from birthdate
                    int calculatedAge = DateTime.Today.Year - birthdate.Year;
                    if (birthdate > DateTime.Today.AddYears(-calculatedAge))
                        calculatedAge--;

                    if (calculatedAge < 17)
                    {
                        Console.WriteLine("Student must be at least 17 years old.");
                        continue;
                    }

                    break;
                }

                // Age input
                while (true)
                {
                    Console.Write("Age: ");
                    string input = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(input))
                    {
                        Console.WriteLine("Input cannot be empty.");
                        continue;
                    }

                    // Ensure integer only
                    if (!int.TryParse(input, out age))
                    {
                        Console.WriteLine("Invalid input. Whole numbers only.");
                        continue;
                    }

                    if (age < 17)
                    {
                        Console.WriteLine("Age must be 17 or above.");
                        continue;
                    }

                    break; // valid input
                }

                string address;

                while (true)
                {
                    Console.Write("Address: ");
                    address = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(address))
                        Console.WriteLine("Input cannot be empty.");
                    else
                        break;
                }

                string contact;

                while (true)
                {
                    Console.Write("Contact Number: ");
                    contact = Console.ReadLine();

                    // Check empty input first
                    if (string.IsNullOrWhiteSpace(contact))
                    {
                        Console.WriteLine("Input cannot be empty.");
                        continue;
                    }

                    // Check if all digits
                    if (!contact.All(char.IsDigit))
                    {
                        Console.WriteLine("Invalid input. Contact number must contain digits only.");
                        continue;
                    }

                    // Check length
                    if (contact.Length != 11)
                    {
                        Console.WriteLine("Invalid input. Contact number must be 11 digits.");
                        continue;
                    }

                    break;
                }

                string course;
                while (true)
                {
                    Console.Write("Course: ");
                    course = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(course))
                    {
                        Console.WriteLine("Input cannot be empty.");
                        continue;
                    }

                    bool valid = true;

                    foreach (char c in course)
                    {
                        if (!char.IsLetter(c))
                        {
                            valid = false;
                            break;
                        }
                    }

                    if (valid && course.Length > 0)
                        break;
                    else
                        Console.WriteLine("Invalid Course. ");
                }

                int year;

                while (true)
                {
                    Console.Write("Year (1-5): ");
                    string input = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(input))
                    {
                        Console.WriteLine("Input cannot be empty.");
                        continue;
                    }

                    if (!int.TryParse(input, out year))
                    {
                        Console.WriteLine("Invalid input. Whole numbers only.");
                        continue;
                    }

                    if (year < 1 || year > 5)
                    {
                        Console.WriteLine("Invalid input. Year must be 1, 2, 3, 4, or 5.");
                        continue;
                    }

                    break; // valid input
                }

                // SAVE TO FILE
                string birth = birthdate.ToShortDateString();

                var student = new
                {
                    FirstName = first,
                    MiddleInitial = mid,
                    LastName = last,
                    Birthdate = birth,
                    Age = age,
                    Address = address,
                    Contact = contact,
                    Course = course,
                    Year = year
                };

                string json = JsonSerializer.Serialize(student);
                File.AppendAllText(Path.Combine(folderPath, studentFile), json + Environment.NewLine);

                Console.WriteLine("Student Registered!");

                while (true)
                {
                    Console.Write("Do you want to register another student? (Y/N): ");
                    string choice = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(choice))
                    {
                        Console.WriteLine("Invalid input. Please enter Y or N.");
                        continue;
                    }

                    choice = choice.Trim().ToUpper();

                    if (choice == "Y")
                    {
                        break; // break inner loop, outer loop repeats → register another student
                    }
                    else if (choice == "N")
                    {
                        return; // exit Register Student
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter Y or N.");
                    }
                }
            }
        }

        static void EnrollSubjects()
        {
            // Predefined subjects in a List<string>
            List<string> allowedSubjects = new List<string>
    {
        "Theo 102A", "IT 104B", "Rizal 101A", "IT 106A",
        "GEC 104A", "GEC 103A", "PE 102A", "COMP 102IT",
        "IT 104A", "IT 105A"
    };

            while (true) // Loop to allow enrolling multiple subjects
            {
                // STUDENT LAST NAME
                string name;
                while (true)
                {
                    Console.Write("Student Last Name: ");
                    name = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(name))
                    {
                        Console.WriteLine("Input cannot be empty.");
                        continue;
                    }

                    if (!name.All(char.IsLetter))
                    {
                        Console.WriteLine("Invalid Last Name.");
                        continue;
                    }

                    break;
                }

                // SUBJECT ID
                int id;
                while (true)
                {
                    Console.Write("Subject ID: ");
                    string input = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(input))
                    {
                        Console.WriteLine("Input cannot be empty.");
                        continue;
                    }

                    if (!int.TryParse(input, out id))
                    {
                        Console.WriteLine("Invalid input. Numbers only.");
                        continue;
                    }

                    if (id < 1)
                    {
                        Console.WriteLine("Invalid input. Subject ID must be positive.");
                        continue;
                    }

                    break;
                }

                // SUBJECT NAME - choose from numbered List
                int subjectChoice;
                while (true)
                {
                    Console.WriteLine("Available subjects:");
                    for (int i = 0; i < allowedSubjects.Count; i++)
                        Console.WriteLine($"{i + 1}. {allowedSubjects[i]}");

                    Console.Write("Enter the number of the subject you want to enroll: ");
                    string input = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(input))
                    {
                        Console.WriteLine("Input cannot be empty.");
                        continue;
                    }

                    if (!int.TryParse(input, out subjectChoice))
                    {
                        Console.WriteLine("Invalid input. Numbers only.");
                        continue;
                    }

                    if (subjectChoice < 1 || subjectChoice > allowedSubjects.Count)
                    {
                        Console.WriteLine($"Invalid choice. Please enter a number between 1 and {allowedSubjects.Count}.");
                        continue;
                    }

                    break;
                }

                // SAVE TO FILE
                string subject = allowedSubjects[subjectChoice - 1];

                var subjectData = new
                {
                    LastName = name,
                    SubjectID = id,
                    SubjectName = subject
                };

                string json = JsonSerializer.Serialize(subjectData);
                File.AppendAllText("subjects.json", json + Environment.NewLine);
                Console.WriteLine($"Subject '{subject}' Enrolled for {name}!");

                // ENROLL ANOTHER SUBJECT?
                while (true)
                {
                    Console.Write("Do you want to enroll another subject? (Y/N): ");
                    string choice = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(choice))
                    {
                        Console.WriteLine("Invalid input. Please enter Y or N.");
                        continue;
                    }

                    choice = choice.Trim().ToUpper();

                    if (choice == "Y")
                    {
                        break; // loop repeats → enroll another subject
                    }
                    else if (choice == "N")
                    {
                        return; // exit method
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter Y or N.");
                    }
                }
            }
        }

        static void EnterGrades()
        {
            while (true)
            {
                string name;
                while (true)
                {
                    Console.Write("Student Last Name: ");
                    name = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(name))
                    {
                        Console.WriteLine("Input cannot be empty.");
                        continue;
                    }

                    if (!name.All(char.IsLetter))
                    {
                        Console.WriteLine("Invalid Last Name.");
                        continue;
                    }

                    break;
                }


                int id;
                while (true)
                {
                    Console.Write("Subject ID: ");
                    string input = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(input))
                    {
                        Console.WriteLine("Input cannot be empty.");
                        continue;
                    }

                    if (!int.TryParse(input, out id))
                    {
                        Console.WriteLine("Invalid input. Numbers only.");
                        continue;
                    }

                    break;
                }

                // GRADE
                int grade;
                while (true)
                {
                    Console.Write("Grade (0-100): ");
                    string input = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(input))
                    {
                        Console.WriteLine("Input cannot be empty.");
                        continue;
                    }

                    if (!int.TryParse(input, out grade))
                    {
                        Console.WriteLine("Invalid input. Numbers only.");
                        continue;
                    }

                    if (grade < 0 || grade > 100)
                    {
                        Console.WriteLine("Invalid input. Grade must be between 0 and 100.");
                        continue;
                    }

                    break;
                }

                // SAVE TO FILE
                var gradeData = new
                {
                    LastName = name,
                    SubjectID = id,
                    Grade = grade
                };

                string json = JsonSerializer.Serialize(gradeData);
                File.AppendAllText(Path.Combine(folderPath, gradeFile), json + Environment.NewLine);
                Console.WriteLine($"Grade {grade} saved for {name}, Subject ID: {id}!");

                // ENTER ANOTHER GRADE?
                while (true)
                {
                    Console.Write("Do you want to enter another grade? (Y/N): ");
                    string choice = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(choice))
                    {
                        Console.WriteLine("Invalid input. Please enter Y or N.");
                        continue;
                    }

                    choice = choice.Trim().ToUpper();

                    if (choice == "Y")
                    {
                        break; // loop repeats → enter another grade
                    }
                    else if (choice == "N")
                    {
                        return; // exit method
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter Y or N.");
                    }
                }
            }
        }
        static void ShowGrades()
        {
            Console.Write("Enter Student Last Name: ");
            string search = Console.ReadLine();

            if (!File.Exists(Path.Combine(folderPath, gradeFile)))
            {
                Console.WriteLine("No grades recorded.");
                return;
            }

            string[] lines = File.ReadAllLines(Path.Combine(folderPath, gradeFile));

            Console.WriteLine();
            Console.WriteLine(search);
            Console.WriteLine();

            foreach (string line in lines)
            {
                var grade = JsonSerializer.Deserialize<Dictionary<string, object>>(line);

                if (grade["LastName"].ToString().Equals(search, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Subject ID: " + grade["SubjectID"] +
                                      " -------- " + grade["Grade"]);
                }
            }
        }
    }
}