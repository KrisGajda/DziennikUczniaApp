using System;
using System.Collections.Generic;

namespace DziennikUczniaApp
{
    public class StudentToMemory : StudentBase, IStudentBase
     {
        public override event GradeAddedDelegate GradeAdded;
        public override event GradeAddedDelegate BadGradeAdded;
        public StudentToMemory(string name, string surname) : base(name, surname)
        {
        }
        public override void AddGrade(int grade)
        {
            if(CheckGradeRange (grade))
            {
                this.grades.Add(grade);
                if (grade <= 3)
                {
                    if(GradeAdded != null)
                    {
                    GradeAdded(this, new EventArgs());
                    BadGradeAdded(this, new EventArgs());
                    }
                }
                else
                {
                    GradeAdded(this, new EventArgs());
                }
            }
        }
        public override void AddGrade(string grade)
        {
            if (int.TryParse(grade, out var number) && (CheckGradeRange(number)))
            {
                this.grades.Add(number);
                if (number < 3)
                {
                    GradeAdded(this, new EventArgs());
                    BadGradeAdded(this, new EventArgs());
                }
                else
                {
                    GradeAdded(this, new EventArgs());
                }
            }
                       
            else if (grade.Contains('+') || grade.Contains('-'))
            {
                switch(grade)
                {
                case "1+":
                    this.grades.Add(1.5);
                    GradeAdded(this, new EventArgs());
                    BadGradeAdded(this, new EventArgs());
                    break;
                case "2-":
                    this.grades.Add(1.75);
                    GradeAdded(this, new EventArgs());
                    BadGradeAdded(this, new EventArgs());
                    break;
                case "2+":
                    this.grades.Add(2.5);
                    GradeAdded(this, new EventArgs());
                    BadGradeAdded(this, new EventArgs());
                    break;
                case "3-":
                    this.grades.Add(2.75);
                    GradeAdded(this, new EventArgs());
                    BadGradeAdded(this, new EventArgs());
                    break;
                case "3+":
                    this.grades.Add(3.5);
                    GradeAdded(this, new EventArgs());
                    break;
                case "4-":
                    this.grades.Add(3.75);
                    GradeAdded(this, new EventArgs());
                    break;
                case "4+":
                    this.grades.Add(4.5);
                    GradeAdded(this, new EventArgs());
                    break;
                case "5-":
                    this.grades.Add(4.75);
                    GradeAdded(this, new EventArgs());
                    break;
                case "5+":
                    this.grades.Add(5.5);
                    GradeAdded(this, new EventArgs());
                    break;
                case "6-":
                    this.grades.Add(5.75);
                    GradeAdded(this, new EventArgs());
                    break;
                default:
                    Console.WriteLine($"Invalid argument: {nameof(grade)}. Grade not added.");
                    break;
                }
            }
            else
            {
                throw new ArgumentException($"Invalid argument: {nameof(grade)}. Grade not added.");
            }
        }
        public override Statistics GetStatistics()
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
            switch(result.Final)
            {
                case var finalGrade when finalGrade >= 5.31:
                    result.Final = 6;
                    break;
                case var finalGrade when finalGrade >= 4.61 && finalGrade <= 5.30:
                    result.Final = 5;
                    break;
                case var finalGrade when finalGrade >= 3.61 && finalGrade <= 4.60:
                    result.Final = 4;
                    break;
                case var finalGrade when finalGrade >= 2.60 && finalGrade <= 3.60:
                    result.Final = 3;
                    break;
                case var finalGrade when finalGrade >= 1.51 && finalGrade <= 2.59:
                    result.Final = 2;
                    break;
                case var finalGrade when finalGrade <= 1.50:
                    result.Final = 1;
                    break;
                default:
                    result.Final = 0;
                    break;
            }

            Console.WriteLine($"{Name} {Surname}'s lowest grade value: {result.Low:N2}");
            Console.WriteLine($"{Name} {Surname}'s highest grade value: {result.High:N2}");
            Console.WriteLine($"{Name} {Surname}'s average grade value: {result.Average:N2}");
            Console.WriteLine($"{Name} {Surname}'s final result is: {result.Final:N0}");
            
            return result;
        }

        public override bool CheckGradeRange(double grade)
        {
            if(grade >=1 && grade<=6)
                return true;
            else
                throw new ArgumentException($"Invalid argument: {nameof(grade)}. Grade out of range (1-6).");  
        }

        
        public override void UpdateStudentsName()
        {
            string newName;
            string newSurname;
            Console.WriteLine("Please write new name: ");
            newName = Console.ReadLine();
            if ((CheckCharacters(newName) || newName == "" || newName.Length < 3))
            {
                Console.WriteLine("Invalid new name. Update unsuccesfull!");
            }
            else
            {
                this.Name = newName;
            }
            Console.WriteLine("Please write new surname: ");
            newSurname = Console.ReadLine();
            if ((CheckCharacters(newSurname) || newSurname == "" || newSurname.Length < 3))
            {
                Console.WriteLine("Invalid new surname. Update unsuccesfull!");
            }
            else
            {
                this.Surname = newSurname;
            }
        }
     }
}