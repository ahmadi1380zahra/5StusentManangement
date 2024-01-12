using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students
{
    public interface IStudentAvg
    {
        public void CalculateStudentAvg();
    }
    class User
    {
        public User(string name)
        {
            Name = name;
        }
        public string Name { get; set; }
    }
    class Student : User,IStudentAvg
    {
        private List<EnrolledCourses> _EnrolledStudentCourses { get; set; }
        public Student(string name) : base(name)
        {

            _EnrolledStudentCourses = new();
        }
        public int Avg { get; private set; }
        public void studentMasters(string instructorname, string coursename)
        {
            foreach (var course in _EnrolledStudentCourses)
            {
                if (course.CourseName == coursename && course.InstructorName == instructorname)
                {
                    Console.WriteLine($"{Name}");
                }
            }
        }

        public void studentcourses()
        {
            foreach (var course in _EnrolledStudentCourses)
            {
                Console.WriteLine($"{course.CourseName} : {course.CourseGrade} * {course.CourseUnit} master {course.InstructorName}");
            }
        }
        public void SetEnrolledStudentCourses(string coursename, string courseinstructor, int coursegrade, int courseunit)
        {
            if (_EnrolledStudentCourses.Any(item => item.CourseName == coursename))
            {
                throw new Exception("you cant have this course twice");
            }
            _EnrolledStudentCourses.Add(new EnrolledCourses(coursename, courseinstructor, coursegrade, courseunit));

        }
        

        public void CalculateStudentAvg()
        {

            if (_EnrolledStudentCourses.Count == 0)
            {
                Avg = 0;
                return;
            }

            var totalGrade = 0;
            var totalUnits = 0;

            foreach (var course in _EnrolledStudentCourses)
            {

                totalGrade += course.CourseGrade * course.CourseUnit;
                totalUnits += course.CourseUnit;
            }

            Avg = totalGrade / totalUnits;
        }
    }
    class EnrolledCourses
    {
        public EnrolledCourses(string courseName, string instructorName, int courseGrade, int courseUnit)
        {
            CourseName = courseName;
            InstructorName = instructorName;
            CourseGrade = courseGrade;
            CourseUnit = courseUnit;
        }
        public string CourseName { get; set; }
        public int CourseUnit { get; set; }
        public string InstructorName { get; set; }
        public int CourseGrade { get; set; }
    }
    class Instructor : User
    {
        public Instructor(string name, Gender gender) : base(name)
        {

            InstructorCourses = new();
            WorkingDays = new();
            Gender = gender;
        }

        public Gender Gender { get; set; }
        public List<Days> WorkingDays { get; set; }
        public List<Course> InstructorCourses { get; set; }
    }
    class Course
    {
        public Course(string name, int unit)
        {
            Name = name;
            Unit = unit;

        }
        public string Name { get; set; }
        public int Unit { get; set; }

    }
}
