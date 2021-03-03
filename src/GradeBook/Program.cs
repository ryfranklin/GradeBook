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
            book1.AddGrade(98.1);
            book1.AddGrade(89.2);
            book1.AddGrade(93.2);
            book1.AddGrade(79.4);

            // book1.GetMin());
            // book1.GetMax();
            // book1.AverageGrade();          
            // System.Console.WriteLine(book1);

            var stats = book1.GetStatistics();
                        
                        
            Console.WriteLine($"The lowest grade is {stats.Low}");
            Console.WriteLine($"The highest grade is {stats.High}");
            Console.WriteLine($"The average grade is {stats.Average}");
            
            }
        }
}
