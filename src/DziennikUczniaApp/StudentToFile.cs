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
        public override string FileWithGrades(string Surname, string Name)
        {
            return ($"{Surname}{Name}.txt");
        }
        public const string auditFile = "audit.txt";
        
        public override void AddGrade(int grade)
        {
            
            if(CheckGradeRange (grade))
            {
                using(var writer = File.AppendText(FileWithGrades(Surname, Name)))
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
            CreateFilesWithGrades(grade);
        }
        else if (grade.Contains('+') || grade.Contains('-'))
        {
            switch(grade)
            {
            case "1+":
                this.grades.Add(1.5);
                CreateFilesWithGrades(grade);
                break;
            case "2-":
                this.grades.Add(1.75);
                CreateFilesWithGrades(grade);
                break;
            case "2+":
                this.grades.Add(2.5);
                CreateFilesWithGrades(grade);
                break;
            case "3-":
                this.grades.Add(2.75);
                CreateFilesWithGrades(grade);
                break;
            case "3+":
                this.grades.Add(3.5);
                CreateFilesWithGrades(grade);
                break;
            case "4-":
                this.grades.Add(3.75);
                CreateFilesWithGrades(grade);
                break;
            case "4+":
                this.grades.Add(4.5);
                CreateFilesWithGrades(grade);
                break;
            case "5-":
                this.grades.Add(4.75);
                CreateFilesWithGrades(grade);
                break;
            case "5+":
                this.grades.Add(5.5);
                CreateFilesWithGrades(grade);
                break;
            case "6-":
                this.grades.Add(5.75);
                CreateFilesWithGrades(grade);
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

        private void CreateFilesWithGrades(string grade)
        {
            using (var writer = File.AppendText(FileWithGrades(Surname, Name)))
            {
                writer.WriteLine(grade);
            }
            using (var auditWriter = File.AppendText(auditFile))
            {
                auditWriter.WriteLine($"{grade}\t{DateTime.UtcNow}");
            }
            if(GradeAdded != null)
            {
            GradeAdded(this, new EventArgs());
            }
        }

        public override bool CheckGradeRange(double grade)
        {
            if(grade >=1 && grade<=6)
                return true;
            else
                throw new ArgumentException($"Invalid argument: {nameof(grade)}. Grade out of range (1-6).");  
        }       
    }
}