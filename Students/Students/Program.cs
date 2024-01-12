using System;

namespace Students
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                try
                {
                    Run();
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                }

                static void Run()
                {

                    var option = GetInt("1: add student\n" +
                      "2: add course\n" +
                      "3: add Instructor\n" +
                      "4: add Instructor Coursers\n" +
                      "5: add Student Coursers\n" +
                      "6: show Student Coursers\n" +
                      "7:show masters student\n"+
                      "8:add instructor days\n"+
                      "9:show instructor days");
                      
                     
                    switch (option)
                    {
                        case 1:
                            {
                                var studentName = GetString("whats student name?");
                                University.AddStudent(studentName);
                                break;
                            }
                        case 2:
                            {
                                var courseName = GetString("whats course name?");
                               
                                var courseUnit = GetInt("whats course unit?");
                                University.AddCourse(courseName,courseUnit);
                                break;
                            }
                        case 3:
                            {
                                var instrucrName = GetString("whats instructor name?");
                                var instructorGender= GetInt("whats instructor Gender? 1:female 2:male 3:sectual");
                                University.AddInstructor(instrucrName, instructorGender);
                                break;
                            }
                        case 4:
                            {
                                var instrucrName = GetString("whats instructor name?");
                                var courseName = GetString("whats course name?");
                                University.AddInstructorCourses(courseName,instrucrName);
                                break;
                            }
                        case 5:
                            {
                                University.ShowInstructorCourses();
                                var studentName = GetString("whats student name?");
                                var instrucrName = GetString("whats instructor name?");
                                var courseName = GetString("whats course name?");
                                var courseGrade = GetInt("whats course grade?");
                                University.AddStudentCourses(studentName, courseName, instrucrName, courseGrade);
                                break;
                            }
                        case 6:
                            {
                                University.showstudentsCourse();
                                break;
                            }
                        case 7:
                            {
                                University.showstudentsMaster();
                                break;
                            }
                        case 8:
                            {
                                var instructor = GetString("instructor name");
                                Console.WriteLine("which day are you coming?  1.shanbe,\r\n       2. yekshanbe,\r\n       3. doshanbe,\r\n       4. seshanbe,\r\n       5. charshanbe,\r\n       6. panjshnbe");
                                var day = int.Parse(Console.ReadLine());
                                
                                University.AddInstructorDays(instructor,day);
                                break;
                            }
                        case 9:
                            {
                                University.ShoworkingDays();
                                break;
                            }
                    }
                }
                static string GetString(string message)
                {
                    Console.WriteLine(message);
                    string value = Console.ReadLine()!;
                    return value;
                }

                static int GetInt(string message)
                {
                    Console.WriteLine(message);
                    int value = int.Parse(Console.ReadLine()!);
                    return value;
                }
            }
        }
    }
}
