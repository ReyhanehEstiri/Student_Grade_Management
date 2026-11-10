using System;
using System.Data;

List<int> grades = new List<int>();

while (true)
{
    Console.WriteLine("==============================");
    Console.WriteLine(" STUDENT GRADE MANAGEMENT");
    Console.WriteLine("==============================");

    Console.WriteLine("1. Add Grade");
    Console.WriteLine("2. Show All Grades");
    Console.WriteLine("3. Calculate Average");
    Console.WriteLine("4. Count Passed & Failed Students");
    Console.WriteLine("0. Exit");

    Console.Write("Choose an option: ");


    string choice = Console.ReadLine() ?? "";
    switch (choice)
    {
        case "0":
            Console.WriteLine("Goodbye!");
            return;

        case "1":
            while (true)
            {
                Console.WriteLine("==============================");
                Console.Write("Enter grade (or type 'done' to finish): ");

                string input = Console.ReadLine() ?? "";

                if (input.ToLower() == "done")
                {
                    Console.WriteLine("Returning to main menu...");
                    break;
                }

                if (int.TryParse(input, out int grade))
                {
                    if (grade >= 0 && grade <= 20)
                    {
                        grades.Add(grade);
                        Console.WriteLine("Grade added successfully!");
                    }
                    else
                    {
                        Console.WriteLine("Grade must be between 0 and 20.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input! Enter a number or 'done'.");
                }
            }
            break;
        case "2":
            if(grades.Count == 0)
            {
                Console.WriteLine("No grades available!");
            }
            else
            {
                Console.WriteLine("All Grades:");
                foreach(int currentgrade in grades)
                {
                    Console.WriteLine(currentgrade);
                }
            }
            break;

        case "3":
            if(grades.Count == 0)
            {
               Console.WriteLine("No grades available!");
            }
            else
            {
                int sum = 0;
                foreach(int currentgrade in grades)
                {
                    sum += currentgrade;
                }
                double average = (double)sum / grades.Count;
                Console.WriteLine($"Average Grade: {average:F2}");
            }
            break;

        case "4":
            if (grades.Count == 0)
            {
                Console.WriteLine("No grades available!");
            }
            else
            {
                int passedCount = 0;
                int failedCount = 0;

                foreach (int currentGrade in grades)
                {
                    if (currentGrade >= 10)
                    {
                        passedCount++;
                    }
                    else
                    {
                        failedCount++;
                    }
                }

                Console.WriteLine($"Passed Students: {passedCount}");
                Console.WriteLine($"Failed Students: {failedCount}");
            }
            break;


        
        default:
            Console.WriteLine("Invalid option!");
            break;
    }
}