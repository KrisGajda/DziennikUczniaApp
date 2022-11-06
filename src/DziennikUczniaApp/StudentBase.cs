using System;
using System.Collections.Generic;

namespace DziennikUczniaApp
{
    public interface IStudentBase
        {
            void AddGrade(int grade);
            void AddGrade(string grade);
            Statistics GetStatistics();
            bool CheckGradeRange(double grade);
            void UpdateStudentsName();
            bool CheckCharacters(string Name);
            string Name {get; set;}
            string Surname {get; set;}
            string FileWithGrades(string surname, string name);            
        }
    public abstract class StudentBase : Person, IStudentBase
    {
        public delegate void GradeAddedDelegate(object sender, EventArgs args);
        public abstract event GradeAddedDelegate GradeAdded;
        public abstract event GradeAddedDelegate BadGradeAdded;
        public List <double> grades = new List<double>();
        public StudentBase(string name, string surname) : base(name, surname)
        {   
        }
        public abstract void AddGrade(string grade);
        public abstract void AddGrade(int grade);

        public virtual bool CheckCharacters(string Name)
        {
            bool isDigit = false;
            foreach (var character in Name)
            {
                if (char.IsDigit(character))
                {
                    isDigit = true;
                    break;
                }
                else
                {
                    isDigit = false;
                }
            }
            return isDigit;
        }

        public virtual bool CheckGradeRange(double grade)
        {
            // Checking range: 0 - 100
            if(grade >= 0 && grade <= 100)
                return true;
            else
                throw new ArgumentException($"Invalid argument: {nameof(grade)}. Grade out of range (0-100).");
        }

        public virtual Statistics GetStatistics()
        {
            var result = new Statistics();
             result.Average = 0.0;
             result.High = double.MinValue;
             result.Low = double.MaxValue;
                         
            for (var index = 0; index < grades.Count; index++)
            {
                result.Low = Math.Min(grades[index], result.Low);
                result.High = Math.Max(grades[index], result.High);
                result.Average += grades[index];
            }
            
            result.Average /= grades.Count;
            result.Final = result.Average;
            return result;
        }

        public virtual void UpdateStudentsName()
        {
            string newName;
            string newSurname;
            Console.WriteLine("Please write new name: ");
            newName = Console.ReadLine();
            Console.WriteLine("Please write new surname: ");
            newSurname = Console.ReadLine();
        }
    }
}