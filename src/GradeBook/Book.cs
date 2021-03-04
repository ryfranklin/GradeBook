using System;
using System.Collections.Generic;

namespace src.GradeBook
{
    public delegate void GradeAddedDelegate(object sender, EventArgs args);

    public class Book
    {
        public Book(string name) 
        {
            grades = new List<double>();
            this.Name = name;
        }

        public void AddGrade(char letter) 
        {
            switch(letter)
            {
                case 'A':
                    AddGrade(90);
                    break;
                case 'B':
                    AddGrade(80);
                    break;
                case 'C':
                    AddGrade(70);
                    break;
                case 'D':
                    AddGrade(60);
                    break;

                case 'F':
                    AddGrade(50);
                    break;
                default:
                    AddGrade(0);
                    break;
            }
        }

        public void AddGrade(double grade) 
        {
            if(grade <= 100 && grade >= 0) 
            {
                grades.Add(grade);
                if(GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                }

            } else 
            {
                throw new ArgumentException($"Invalid {nameof(grade)}");
            }
        }

        public event GradeAddedDelegate GradeAdded;

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

            switch(result.Average)
            {
                case var d when d >= 90.0:
                    result.Letter = 'A';
                    break;
                case var d when d >= 80.0:
                    result.Letter = 'B';
                    break;
                case var d when d >= 70.0:
                    result.Letter = 'C';
                    break;
                case var d when d >= 60.0:
                    result.Letter = 'D';
                    break;
                default:
                    result.Letter = 'F';
                    break;
                
            }
            
            return result;

        }

        public override string ToString()
        {
            return string.Format("Minimum: {0} , Maximum: {1}, Average: {2}", GetMin(), GetMax(), AverageGrade());
        }

        private List<double> grades;
        
        public String Name 
        {
            get; 
            set;        
        }   

        public const string CATEGORY = "Science";
    }
}