using System;
using System.Collections.Generic;

namespace src.GradeBook
{
    public class Book
    {
        public Book(string name) 
        {
            grades = new List<double>();
            this.Name = name;
        }

        public void AddGrade(double grade) 
        {
            grades.Add(grade);
        }

        public double AverageGrade() 
        {
            double total = 0.0;
            foreach(double grade in grades)
            {   
                total = total + grade;
            }
            return total / grades.Count;
        }

        public double GetMin() 
        {
            double min = double.MaxValue;
            foreach(double grade in grades)
            {
                if (grade < min) {
                    min = grade;
                }
            }
            return min;
        }

        public double GetMax()
        {
            double max = double.MinValue;
            foreach(double grade in grades)
            {
                if (grade > max) {
                    max = grade;
                }
            }
            return max;

        }

        public Statistics GetStatistics()
        {
            var result = new Statistics();

            result.Average = 0.0;
            result.High = double.MinValue;
            result.Low = double.MaxValue;

            foreach(var grade in grades)
            {
                result.Low = Math.Min(grade, result.Low);
                result.High = Math.Max(grade, result.High);
                result.Average += grade;
            }
            result.Average /= grades.Count;
            
            return result;

        }

        public override string ToString()
        {
            return string.Format("Minimum: {0} , Maximum: {1}, Average: {2}", GetMin(), GetMax(), AverageGrade());
        }

        private List<double> grades;
        public string Name;
    }
}