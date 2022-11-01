using System;
using System.Collections.Generic;

namespace DziennikUczniaApp
{
    partial class Program
    {
        static void Main(string[] args)
        {

            List<string> studentList = new List<string>();

            var stu001 = new StudentToFile("Adam", "Nowak");
            studentList.Add(stu001.Surname + " " + stu001.Name);
            stu001.GradeAdded += OnGradeAdded;
            stu001.BadGradeAdded += OnBadGradeAdded;
            

            studentList.Sort();
            printStudentList();

            EnterGrade(stu001);
            stu001.GetStatistics();
            Console.WriteLine($"name: {stu001.Name}, surname:  {stu001.Surname}");
            stu001.UpdateStudentsName();
            Console.WriteLine($"new name: {stu001.Name}, new surname:  {stu001.Surname}");

            void printStudentList()
            {
                for (int i = 0; i < studentList.Count; i++)
                {
                    Console.Write($"{i + 1} ");
                    Console.WriteLine(studentList[i]);
                }
            }
            static void OnGradeAdded(object sender, EventArgs args)
            {
                Console.WriteLine($"New grade is added.");
            }
            static void OnBadGradeAdded(object sender, EventArgs args)
            {
                Console.WriteLine($"Oh no! We should inform student's parents about this fact.");
            }
        }

        private static void EnterGrade(IStudentBase stu001)
        {
            while (true)
            {
                Console.WriteLine($"Hello! Enter grade for {stu001.Name} {stu001.Surname}");
                var input = Console.ReadLine();

                if (input == "q")
                {
                    break;
                }
                //var grade = double.Parse(input);

                try
                {
                    stu001.AddGrade(input);
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}