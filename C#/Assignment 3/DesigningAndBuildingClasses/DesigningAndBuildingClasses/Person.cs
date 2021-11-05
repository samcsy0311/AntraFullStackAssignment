using System;

enum Grade { 
     A = 4,
     B = 3,
     C = 2,
     D = 1,
     F = 0
}

namespace DesigningAndBuildingClasses
{
     interface IPersonService
     {
          string[] getAddress();
          int getAge();
          bool checkSalary(decimal s);
     }

     interface IStudentService : IPersonService
     {
          double getGPA();
          Course[] getCourses();
     }

     interface IInstructorService:IPersonService
     {
          void printDepartment();
          void updateBonus();
     }

     abstract class Person:IPersonService
     {
          protected string id;
          protected string name;
          protected string[] addresses;
          protected int age;
          protected string gender;
          protected decimal salary;

          public string[] getAddress()
          {
               return addresses;
          }
          public int getAge()
          {
               return age;
          }
          public bool checkSalary (decimal s)
          {
               return s > 0;
          }

          public abstract void Print();
     }

     class Student : Person, IStudentService
     {
          private Course[] courses;
          private Grade[] grades;
          public override void Print()
          {
               Console.WriteLine("StudentID: " + id + "\t Name: " + name);
          }
          
          public new bool checkSalary(decimal s)
          {
               return true;
          }
          public double getGPA()
          {
               double totalPoints = 0;
               double totalCredits = 0;
               for (int i = 0; i < courses.Length; ++i)
               {
                    totalCredits += courses[i].getCredits();
                    totalPoints += courses[i].getCredits() * (double)grades[i];
               }
               return totalPoints / totalCredits;
          }

          public Course[] getCourses()
          {
               return courses;
          }
     }

     class Instructor : Person, IInstructorService
     {
          private Department department;
          private bool head;
          private decimal bonus;
          private DateTime joinDate;

          public override void Print()
          {
               Console.WriteLine("InstructorID: " + id + "\t Name: " + name);
          }
          public void printDepartment ()
          {
               Console.WriteLine("He belongs to " + department.getDepName() + " department.");
          }

          public void updateBonus ()
          {
               DateTime zeroTime = new DateTime(1, 1, 1);
               int numOfYears = (zeroTime + (DateTime.Today - joinDate)).Year - 1;
               this.bonus = numOfYears * 10000;
          }
     }

     class Course
     {
          private string courseID { set; get; }
          private string courseName { set; get; }
          private double credits { set; get; }
          private Student[] classList { set; get; }

          public Course (string courseID, string courseName, double credits, Student[] classList)
          {
               this.courseID = courseID;
               this.courseName = courseName;
               this.credits = credits;
               this.classList = classList;
          }

          public double getCredits ()
          {
               return credits;
          }
     }

     class Department
     {
          private string depName { set; get; }
          private Instructor depHead { set; get; }
          private Course[] courseList { set; get; }
          private decimal budget { set; get; }

          public Department(string depName, Instructor depHead, Course[] courseList, decimal budget)
          {
               this.depName = depName;
               this.depHead = depHead;
               this.courseList = courseList;
               this.budget = budget;
          }
          public string getDepName ()
          {
               return depName;
          }
     }
}
