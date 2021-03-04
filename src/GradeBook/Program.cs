using System;
using System.Collections.Generic;
using src.GradeBook;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            var book1 = new Book("Ryan's GradeBook");
            book1.GradeAdded += OnGradeAdded;
            book1.GradeAdded += OnGradeAdded;
            book1.GradeAdded -= OnGradeAdded;
            book1.GradeAdded += OnGradeAdded;
            

  
            Console.WriteLine("Enter a grade or Press 'Q' to quit");
            while (true) 
            {
                var input = Console.ReadLine();
                if (input == "q")
                {
                    break;
                } 
                
                try 
                {
                    var grade = double.Parse(input);
                    book1.AddGrade(grade);
  
                }
                catch (ArgumentException ex) 
                {
                    Console.WriteLine(ex.Message);
                    
                }
                catch (FormatException ex) 
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    Console.WriteLine("**");
                }
            }


            // book1.GetMin());
            // book1.GetMax();
            // book1.AverageGrade();          
            // System.Console.WriteLine(book1);

            var stats = book1.GetStatistics();

            // book1.Name = ""; -- Private state in property 
            Console.WriteLine($"{Book.CATEGORY}");
            Console.WriteLine($"For the book named {book1.Name}");
            Console.WriteLine($"The lowest grade is {stats.Low}");
            Console.WriteLine($"The highest grade is {stats.High}");
            Console.WriteLine($"The average grade is {stats.Average}");
            Console.WriteLine($"The letter grade is {stats.Letter}");
            
            }

            static void OnGradeAdded(object sender, EventArgs e)
            {
                Console.WriteLine("A grade was added");
            }
        }
}
