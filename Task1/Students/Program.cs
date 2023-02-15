using System;
using System.Collections.Generic;

namespace Students
{
    class Program
    {

        static void Main(string[] args)
        {
            var subjects = new string[] { "Maths", "PE", "Art", "Physics", 
                "Chemistry", "Geography" };

            var student1c1 = new Student("vasya.pupkin@epam.com");
            var student2c1 = new Student("anton.laptev@epam.com");
            var student3c1 = new Student("axl.rose@epam.com");
          
            var student1c2 = new Student("Vasya", "Pupkin");
            var student2c2 = new Student("Anton", "Laptev");
            var student3c2 = new Student("Axl", "Rose");

            var studentSubjectDict = new Dictionary<Student, HashSet<string>>();

            studentSubjectDict[student1c1] = new HashSet<string>
            {
                subjects[0],
                subjects[1],
                subjects[2]
            };
            studentSubjectDict[student2c1] = new HashSet<string>
            {
                subjects[3],
                subjects[4],
                subjects[5]
            };
            studentSubjectDict[student3c1] = new HashSet<string>
            {
                subjects[0],
                subjects[2],
                subjects[4]
            };
            studentSubjectDict[student1c2] = new HashSet<string>
            {
                subjects[1],
                subjects[3],
                subjects[5]
            };
            studentSubjectDict[student2c2] = new HashSet<string>
            {
                subjects[0],
                subjects[3],
                subjects[5]
            };
            studentSubjectDict[student3c2] = new HashSet<string>
            {
                subjects[1],
                subjects[2],
                subjects[5]
            };

            Console.WriteLine("Number of records in \"studentSubjectDict\" dictionary is: "
                + studentSubjectDict.Count);
        }
    }
}
