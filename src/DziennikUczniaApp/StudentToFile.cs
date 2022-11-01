using System;
using System.IO;

namespace DziennikUczniaApp
{
    public class StudentToFile : StudentBase, IStudentBase
    {
        public override event GradeAddedDelegate GradeAdded;
        public override event GradeAddedDelegate BadGradeAdded;
        
        public StudentToFile(string name, string surname) : base(name, surname)
        {
            
        }
        public const string fileName = ($"{Surname}{Name}.txt");
        // public string CreateTxtFileName(string firstWord, string secondWord)
        // {
        //     string newString = $"{firstWord}{secondWord}.txt";
        //     return newString;
        // }
        // public const string fileName = new CreateTxtFileName(Surname, Name);
        public override void AddGrade(int grade)
        {
            if(CheckGradeRange (grade))
            {
                using(var writer = File.AppendText(fileName))
                {
                writer.WriteLine(grade);
                }
                if(GradeAdded != null)
                {
                GradeAdded(this, new EventArgs());
                }
            }
            else
            {
                throw new ArgumentException($"Invalid argument: {nameof(grade)}. Grade not added.");
            }
        }

        public override void AddGrade(string grade)
        {
        if (int.TryParse(grade, out var number) && (CheckGradeRange(number)))
        {
            using(var writer = File.AppendText(fileName))
                {
                writer.WriteLine(grade);
                }
            if(GradeAdded != null)
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
                using(var writer = File.AppendText(fileName))
                {
                writer.WriteLine("1.5");
                }
                GradeAdded(this, new EventArgs());
                break;
            case "2-":
                this.grades.Add(1.75);
                using(var writer = File.AppendText(fileName))
                {
                writer.WriteLine("1.75");
                }
                GradeAdded(this, new EventArgs());
                break;
            case "2+":
                this.grades.Add(2.5);
                using(var writer = File.AppendText(fileName))
                {
                writer.WriteLine("2.5");
                }
                GradeAdded(this, new EventArgs());
                break;
            case "3-":
                this.grades.Add(2.75);
                using(var writer = File.AppendText(fileName))
                {
                writer.WriteLine("2.75");
                }
                GradeAdded(this, new EventArgs());
                break;
            case "3+":
                this.grades.Add(3.5);
                using(var writer = File.AppendText(fileName))
                {
                writer.WriteLine("3.5");
                }
                GradeAdded(this, new EventArgs());
                break;
            case "4-":
                this.grades.Add(3.75);
                using(var writer = File.AppendText(fileName))
                {
                writer.WriteLine("3.75");
                }
                GradeAdded(this, new EventArgs());
                break;
            case "4+":
                this.grades.Add(4.5);
                using(var writer = File.AppendText(fileName))
                {
                writer.WriteLine("4.5");
                }
                GradeAdded(this, new EventArgs());
                break;
            case "5-":
                this.grades.Add(4.75);
                using(var writer = File.AppendText(fileName))
                {
                writer.WriteLine("4.75");
                }
                GradeAdded(this, new EventArgs());
                break;
            case "5+":
                this.grades.Add(5.5);
                using(var writer = File.AppendText(fileName))
                {
                writer.WriteLine("5.5");
                }
                GradeAdded(this, new EventArgs());
                break;
            case "6-":
                this.grades.Add(5.75);
                using(var writer = File.AppendText(fileName))
                {
                writer.WriteLine("5.75");
                }
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
    }
}