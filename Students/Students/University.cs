using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students
{
    static class University
    {
        private static List<User> _users = new();
        private static List<Student> _students = new();
        private static List<Course> _courses = new();
        private static List<Instructor> _instructors = new();
        public static void AddStudent(string name)
        {
            var student = new Student(name);
            var isExistStudent = _users.Any(item =>item is Student && item.Name.ToLower() == name.ToLower());
            if (isExistStudent)
            {
                throw new Exception("student name should be unique");
            }
            _users.Add(student);
        }
        public static void AddCourse(string name, int unit)
        {
            var course = new Course(name, unit);
            var isExistCourse = _courses.Any(item => item.Name.ToLower() == name.ToLower());
            if (isExistCourse)
            {
                throw new Exception("Course name should be unique");
            }
            _courses.Add(course);
        }
        public static void AddInstructor(string name, int gender)
        {

            var instructor = new Instructor(name, gender == 1 ? Gender.female : gender == 2 ? Gender.male : gender == 3 ? Gender.bisectual : throw new Exception("this gender not existed"));

            var isExistInstructor = _users.Any(item =>item is Instructor && item.Name.ToLower() == name.ToLower());
            if (isExistInstructor)
            {
                throw new Exception("Instructor name should be unique");
            }
            _users.Add(instructor);

        }
        public static void AddInstructorCourses(string coursename, string intructorname)
        {
            var intructor = _users.Find(item =>item is Instructor && item.Name == intructorname);
            if (intructor is null)
            {
                throw new Exception("Instructor not Found");
            }
            var courseName = _courses.Find(item => item.Name == coursename);
            if (courseName is null)
            {
                throw new Exception("course not Found");
            }
           var wantedInstructor= intructor as Instructor;
            wantedInstructor.InstructorCourses.Add(courseName);
        }
        public static void ShowInstructorCourses()
        {
             foreach (var instructor in _users.Where(item => item is Instructor))
            {
                var wantedInstructor = instructor as Instructor;
                Console.WriteLine($"{wantedInstructor.Name} have :");
                foreach (var course in wantedInstructor.InstructorCourses)
                {
                    Console.WriteLine($"{course.Name}");
                }

            }
        }
        public static void AddStudentCourses(string username, string coursename, string courseinstructor, int coursegrade)
        {
            var student = _users.Find(item =>item is Student && item.Name == username);
            if (student == null)
            {
                throw new Exception("student not Found");
            }
            var wantedStudent = student as Student;
            var instructor = _users.Find(item =>item is Instructor && item.Name == courseinstructor);
            if (instructor == null)
            {
                throw new Exception("instructor not Found");
            }
           var wantedInstructor= instructor as Instructor;
            if (!wantedInstructor.InstructorCourses.Any(item => item.Name == coursename))
            {
                throw new Exception("instructor dont teach this course");
            }

            var course = _courses.Find(item => item.Name == coursename);
            wantedStudent.SetEnrolledStudentCourses(coursename, courseinstructor, coursegrade, course.Unit);
            
            wantedStudent.CalculateStudentAvg();
        }
        public static void AddInstructorDays(string name, int day)
        {
            var instructor = _users.Find(item =>item is Instructor && item.Name == name);
            var wantedInstructor = instructor as Instructor;
            switch (day)
            {
                case 1:
                    {
                        wantedInstructor.WorkingDays.Add(Days.shnbe);
                        break;
                    }
                case 2:
                    {
                        wantedInstructor.WorkingDays.Add(Days.yekshne);
                        break;
                    }
                case 3:
                    {
                        wantedInstructor.WorkingDays.Add(Days.doshnbe);
                        break;

                    }
                case 4:
                    {
                        wantedInstructor.WorkingDays.Add(Days.seshanbe);
                        break;
                    }
                case 5:
                    {
                        wantedInstructor.WorkingDays.Add(Days.charshanbe);
                        break;
                    }
                case 6:
                    {
                        wantedInstructor.WorkingDays.Add(Days.panjshanbe);
                        break;
                    }

            }
        }
        public static void ShoworkingDays()
        {
            //var instructors = _users.Where(item => item is Instructor).ToList();
            foreach (var instructor in _users.Where(item => item is Instructor))
            {
                var currentInstructor = instructor as Instructor;
                Console.WriteLine($"{currentInstructor.Name}");
                foreach (var day in currentInstructor.WorkingDays)
                {
                    Console.WriteLine($"{day}");
                }

            }
        }
        public static void showstudentsCourse()
        {
            foreach (var student  in _users.Where(item => item is Student))
            {
                var currentStudent = student as Student;
                Console.WriteLine($"{currentStudent.Name} avg is :{currentStudent.Avg}");
                currentStudent.studentcourses();

            }
        }
        public static void showstudentsMaster()
        {
            foreach (var master in _users.Where(item => item is Instructor))
            {
                var currentInstructor = master as Instructor;
                Console.WriteLine($"{currentInstructor.Name} ");
                foreach (var course in currentInstructor.InstructorCourses)
                {
                    Console.WriteLine($"{course.Name} ");
                    foreach (var student in _users.Where(item => item is Student))
                    {
                        var currentStudent = student as Student;
                        currentStudent.studentMasters(master.Name, course.Name);

                    }

                }

            }

        }
    }
}
