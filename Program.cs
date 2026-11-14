using System;
using System.Data;

List<int> grades = new List<int>();

static void ShowMenu()
{
    Console.WriteLine("1. Add Grade");
    Console.WriteLine("2. Show All Grades");
    Console.WriteLine("3. Calculate Average");
    Console.WriteLine("4. Count Passed & Failed");
    Console.WriteLine("0. Exit");

    
}


static void AddGrades(List<int> grades)
{
    while (true)
    {
        Console.Write("Enter grade (or type 'done' to finish): ");

        string input = Console.ReadLine() ?? "";

        if (input.Equals("done", StringComparison.OrdinalIgnoreCase))
        {
            break;
        }

        if (int.TryParse(input, out int grade))
        {
            if (grade >= 0 && grade <= 20)
            {
                grades.Add(grade);
                Console.WriteLine("Grade added!");
            }
            else
            {
                Console.WriteLine("Grade must be between 0 and 20.");
            }
        }
        else
        {
            Console.WriteLine("Invalid input!");
        }
    }
}

static void ShowGrades(List<int> grades)
{
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
}

static double CalculateAverage(List<int> grades)
{
    int sum = 0;

    foreach (int currentGrade in grades)
    {
        sum += currentGrade;
    }

    double average = (double)sum / grades.Count;

    return average;
}

static void CountPassedAndFailed(List<int> grades)
{
    int passedCount = grades.Count(g => g >= 10);

    int failedCount = grades.Count(g => g < 10);

    Console.WriteLine($"Passed: {passedCount}");
    Console.WriteLine($"Failed: {failedCount}");
}



while (true)
{
    ShowMenu(); 
    Console.Write("Choose an option: ");


    string choice = Console.ReadLine() ?? "";
    switch (choice)
    {
        case "0":
            Console.WriteLine("Goodbye!");
            return;

        case "1":
            AddGrades(grades);
            break;

        case "2":
            ShowGrades(grades);
            break;

        case "3":
            if (grades.Count == 0)
            {
                Console.WriteLine("No grades available!");
            }   
            else
            {
                double average = CalculateAverage(grades);
                Console.WriteLine($"Average: {average:F2}");
            }
            break;

        case "4":
            CountPassedAndFailed(grades);
            break;

        default:
            Console.WriteLine("Invalid option!");
            break;
    }
}