using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIDTERMTEST
{
    class Program
    {
        public static void Main(string[] args)
        {

            Console.WriteLine("Please select an option:");
            Console.WriteLine("=============================================================");
            Console.WriteLine("\t1. Input information (input details for a student).");
            Console.WriteLine("\t2. Sorting student asccending by average mark.");
            Console.WriteLine("\t3. Display all the student.");
            Console.WriteLine("\t4. Search Student by Name");
            Console.WriteLine("\t5. Delete Student by student ID.");
            Console.WriteLine("\t6. Exit program.");
            Console.WriteLine("=============================================================");

            int option = Convert.ToInt32(Console.ReadLine());
            while (option < 0)
            {
                Console.WriteLine("Retry.");
            }
            Student t1 = new Student();
            TestStudent testStudent = new TestStudent();
            switch (option)
            {
                case 1:
                    testStudent.InputStudent();
                    break;
                case 2:
                    testStudent.SortByAverageMark();
                    break;
                case 3:
                    testStudent.DisplayStudent();
                    break;
                case 4:
                    testStudent.SearchStudentByName();
                    break;
                case 5:
                    testStudent.DeleteStudentByID();
                    break;
                case 6:
                    ;
                    break;
                default:
                    Console.WriteLine("Retry.");
                    break;
            }

        }
    }
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public string DateOfBirth { get; set; }
        public string Class { get; set; }
        public double Mark1 { get; set; }
        public double Mark2 { get; set; }
        public double Mark3 { get; set; }

        public double AverageMark()
        {
            double averageMark = (Mark1 + Mark2 + Mark3) / 3;
            return averageMark;
        }
    }

    public class TestStudent
    {
        public Student[] studentArray;

        public void StudentList()
        {
            Console.Write("The number of students: ");
            int numberOfStudent = Convert.ToInt32(Console.ReadLine());
            while (numberOfStudent <= 0)
            {
                Console.WriteLine("Retry.");
            }
            studentArray = new Student[numberOfStudent];
        }

        public void InputStudent()
        {
            for (int i = 0; i < studentArray.Length; i++)
            {
                Student student = new Student();
                Console.WriteLine($"\nStudent {i + 1}: ID = {i + 1}");
                student.Id = i + 1;

                Console.Write("Name: ");
                student.Name = Console.ReadLine();

                Console.Write("Gender: ");
                student.Gender = Console.ReadLine();

                Console.Write("Age: ");
                student.Age = Convert.ToInt32(Console.ReadLine());

                Console.Write("Date of birth: ");
                student.DateOfBirth = Console.ReadLine();

                Console.Write("Class: ");
                student.Class = Console.ReadLine();

                Console.Write("Mark1: ");
                student.Mark1 = Convert.ToDouble(Console.ReadLine());

                Console.Write("Mark2: ");
                student.Mark2 = Convert.ToDouble(Console.ReadLine());

                Console.Write("Mark3: ");
                student.Mark3 = Convert.ToDouble(Console.ReadLine());

                studentArray[i] = student;

            }
        }

        public void DisplayStudent()
        {
            Console.WriteLine("\nStudent Information:");
            for (int i = 0; i < studentArray.Length; i++)
            {
                Student student = studentArray[i];
                Console.WriteLine($"ID: {student.Id}");
                Console.WriteLine($"Name: {student.Name}");
                Console.WriteLine($"Gender: {student.Gender}");
                Console.WriteLine($"Age: {student.Age}");
                Console.WriteLine($"Date of birth: {student.DateOfBirth}");
                Console.WriteLine($"Class: {student.Class}");
                Console.WriteLine($"Mark 1: {student.Mark1}");
                Console.WriteLine($"Mark 2: {student.Mark2}");
                Console.WriteLine($"Mark 3: {student.Mark3}");
                Console.WriteLine($"Average mark: {student.AverageMark()}\n");
            }
        }

        public void SearchStudentByName()
        {
            Console.Write("Which student do you want to search for?");
            string searchName = Console.ReadLine();

            bool isThereAName = false;
            foreach (var student in studentArray)
            {
                if (student.Name.Equals(searchName, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Student found: " + student);
                    isThereAName = true;
                    break;
                }
            }
            if (!isThereAName)
            {
                Console.WriteLine("Student not found.");
            }


        }

        public void UpdateStudentInfo()
        {
            Console.Write("Whose student information do you want to edit?");
            string searchName = Console.ReadLine();

            bool isThereAName = false;
            for (int i = 0; i < studentArray.Length; i++)
            {
                if (studentArray[i].Name.Equals(searchName, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("\nStudent information:");
                    Console.WriteLine(studentArray[i]);
                    Console.WriteLine("Start editing ...");

                    Console.Write("New Name: ");
                    studentArray[i].Name = Console.ReadLine();

                    Console.Write("New Gender: ");
                    studentArray[i].Gender = Console.ReadLine();

                    Console.Write("New Age: ");
                    studentArray[i].Age = Convert.ToInt32(Console.ReadLine());

                    Console.Write("New Date of birth: ");
                    studentArray[i].DateOfBirth = Console.ReadLine();

                    Console.Write("New Class: ");
                    studentArray[i].Class = Console.ReadLine();

                    Console.Write("New Mark1: ");
                    studentArray[i].Mark1 = Convert.ToDouble(Console.ReadLine());

                    Console.Write("New Mark2: ");
                    studentArray[i].Mark2 = Convert.ToDouble(Console.ReadLine());

                    Console.Write("New Mark3: ");
                    studentArray[i].Mark3 = Convert.ToDouble(Console.ReadLine());

                    Console.WriteLine("Information updated.");

                    isThereAName = true;
                    break;

                }
            }
            if (!isThereAName)
            {
                Console.WriteLine("Student not found.");
            }


        }

        public void DeleteStudentByID()
        {
            Console.Write("Which student ID do you want to remove?");
            int searchID = Convert.ToInt32(Console.ReadLine()); ;
            while (searchID <= 0)
            {
                Console.Write("ID not available. Retry.");
            }

            bool isThereAnID = false;
            for (int i = 0; i < studentArray.Length; i++)
            {
                if (studentArray[i].Id == searchID)
                {
                    Console.WriteLine("\nStudent Information about to be removed:");
                    Console.WriteLine(studentArray[i]);

                    for (int j = i; j < studentArray.Length - 1; j++)
                    {
                        studentArray[j] = studentArray[j + 1];
                    }

                    Array.Resize(ref studentArray, studentArray.Length - 1);

                    Console.WriteLine("Student removed.");
                    isThereAnID = true;
                    break;
                }
            }
            if (!isThereAnID)
            {
                Console.WriteLine("Student not found.");
            }

        }

        public void SortByAverageMark()
        {
            for (int i = 0; i < studentArray.Length - 1; i++)
            {
                for (int j = i + 1; j < studentArray.Length; j++)
                {
                    if (studentArray[i].AverageMark() > studentArray[j].AverageMark())
                    {
                        Student temp = studentArray[i];
                        studentArray[i] = studentArray[j];
                        studentArray[j] = temp;
                    }
                }
            }

            Console.WriteLine("\nStudent List sorted by Average mark:");
            foreach (var student in studentArray)
            {
                Console.WriteLine(student);
            }
        }

        
    }

   
        





}