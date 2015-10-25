using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Reflection;

namespace TipuriPrimitive
{
    [TestClass]
    public class Catalogue
    {
        public struct Student
        {
            public string name;
            public decimal averageGrade;
            public Student(string name, decimal grade)
            {
                this.name = name;
                this.averageGrade = grade;
            }
        }
        public struct StudentGrades
        {
            public string name;
            public uint[] course1Grades;
            public uint[] course2Grades;
            public uint[] course3Grades;
            public StudentGrades(string name, uint[] Grades1, uint[] Grades2, uint[] Grades3)
            {
                this.name = name;
                this.course1Grades = Grades1;
                this.course2Grades = Grades2;
                this.course3Grades = Grades3;
            }
        }

        [TestMethod]
        public void SortDescendingStudents()
        {
            StudentGrades[] catalogue =
               {
            new StudentGrades ("Andrei Maria",new uint[] { 10,9,9},new uint[] {8 },new uint[] {9,10,7 }),
            new StudentGrades("Ban Andrei",new uint[]{ 10, 10, 9 }, new uint[]{10,9,10,10},new uint[] {9,7 }),
            new StudentGrades("Vlad Mihai",new uint[]{ 8,10, 9 }, new uint[]{9,10,10},new uint[] {10,7 }),
            new StudentGrades("Pop Mihai",new uint[]{5,8,10, 9 }, new uint[]{9,4,10,10},new uint[] {10,7,4 }),
            new StudentGrades ("Man Maria",new uint[] { 10,9},new uint[] {8 ,5},new uint[] {9,10,7 }),
            new StudentGrades("Bancos Andrei",new uint[]{ 10, 10 }, new uint[]{10,9,10,10},new uint[] {9,7,5 }),
            new StudentGrades("Vladimir Mihai",new uint[]{ 8,10, 9,10 }, new uint[]{9,10,10},new uint[] {10,7,8 }),
            new StudentGrades("Popescu Mihai",new uint[]{5,8,10, 9 ,9}, new uint[]{9,4,10,10},new uint[] {10,7,4,8 }),
                };

            Student[] expectedSortedList =
            {
                new Student ("Ban Andrei",9.14M),
                new Student ("Vladimir Mihai",9.08M),
                new Student ("Vlad Mihai",9.06M),
                new Student ("Bancos Andrei",8.92M),
                new Student ("Andrei Maria",8.67M),
                new Student ("Man Maria",8.22M),
                new Student ("Popescu Mihai",7.9M),
                new Student ("Pop Mihai",7.75M),
            };
            Student[] StudentsGrades = CalculateAverageGradeAndSort(catalogue);

            CollectionAssert.AreEqual(expectedSortedList, StudentsGrades);
        }

        [TestMethod]
        public void FindStudentWithCustomGrade()
        {
            StudentGrades[] catalogue =
               {
            new StudentGrades ("Andrei Maria",new uint[] { 10,9,9},new uint[] {8 },new uint[] {9,10,7 }),
            new StudentGrades("Ban Andrei",new uint[]{ 10, 10, 9 }, new uint[]{10,9,10,10},new uint[] {9,7 }),
            new StudentGrades("Vlad Mihai",new uint[]{ 8,10, 9 }, new uint[]{9,10,10},new uint[] {10,7 }),
            new StudentGrades("Pop Mihai",new uint[]{5,8,10, 9 }, new uint[]{9,4,10,10},new uint[] {10,7,4 }),
            new StudentGrades ("Man Maria",new uint[] { 10,9},new uint[] {8 ,5},new uint[] {9,10,7 }),
            new StudentGrades("Bancos Andrei",new uint[]{ 10, 10 }, new uint[]{10,9,10,10},new uint[] {9,7,5 }),
            new StudentGrades("Vladimir Mihai",new uint[]{ 8,10, 9,10 }, new uint[]{9,10,10},new uint[] {10,7,8 }),
            new StudentGrades("Popescu Mihai",new uint[]{5,8,10, 9 ,9}, new uint[]{9,4,10,10},new uint[] {10,7,4,8 }),
                };
            decimal averageGradeToFind = 8.67M;
            string[] expectedStudent = { "Andrei Maria" };

            Student[] studentsGrades = CalculateAverageGradeAndSort(catalogue);
            string[] studentsFound = FindAllStudentsWithCustomGrades(studentsGrades, averageGradeToFind);

            CollectionAssert.AreEqual(expectedStudent, studentsFound);
        }

        [TestMethod]
        public void NotFoundStudentWithCustomGrade()
        {
            StudentGrades[] catalogue =
               {
            new StudentGrades ("Andrei Maria",new uint[] { 10,9,9},new uint[] {8 },new uint[] {9,10,7 }),
            new StudentGrades("Ban Andrei",new uint[]{ 10, 10, 9 }, new uint[]{10,9,10,10},new uint[] {9,7 }),
            new StudentGrades("Vlad Mihai",new uint[]{ 8,10, 9 }, new uint[]{9,10,10},new uint[] {10,7 }),
            new StudentGrades("Pop Mihai",new uint[]{5,8,10, 9 }, new uint[]{9,4,10,10},new uint[] {10,7,4 }),
            new StudentGrades ("Man Maria",new uint[] { 10,9},new uint[] {8 ,5},new uint[] {9,10,7 }),
            new StudentGrades("Bancos Andrei",new uint[]{ 10, 10 }, new uint[]{10,9,10,10},new uint[] {9,7,5 }),
            new StudentGrades("Vladimir Mihai",new uint[]{ 8,10, 9,10 }, new uint[]{9,10,10},new uint[] {10,7,8 }),
            new StudentGrades("Popescu Mihai",new uint[]{5,8,10, 9 ,9}, new uint[]{9,4,10,10},new uint[] {10,7,4,8 }),
                };
            decimal averageGradeToFind = 8.65M;
            string[] expectedStudents = null;

            Student[] studentsGrades = CalculateAverageGradeAndSort(catalogue);
            string[] studentsFound = FindAllStudentsWithCustomGrades(studentsGrades, averageGradeToFind);

            CollectionAssert.AreEqual(expectedStudents, studentsFound);
        }
        [TestMethod]
        public void FindAllStudentsWithCustomGrades()
        {
            StudentGrades[] catalogue =
               {
            new StudentGrades ("Andrei Maria",new uint[] { 10,9,9},new uint[] {8 },new uint[] {9,10,7 }),
            new StudentGrades("Ban Andrei",new uint[]{ 10, 10, 9 }, new uint[]{10,9,10,10},new uint[] {9,7 }),
            new StudentGrades("Vlad Mihai",new uint[]{ 8,10, 9 }, new uint[]{9,10,10},new uint[] {10,7 }),
            new StudentGrades("Pop Mihai",new uint[]{5,8,10, 9 }, new uint[]{9,4,10,10},new uint[] {10,7,4 }),
            new StudentGrades ("Man Maria",new uint[] { 10,9},new uint[] {8 ,5},new uint[] {9,10,7 }),
            new StudentGrades("Bancos Andrei",new uint[]{ 10, 10 }, new uint[]{10,9,10,10},new uint[] {9,7,5 }),
            new StudentGrades("Vladimir Mihai",new uint[]{ 8,10, 9,10 }, new uint[]{9,10,10},new uint[] {10,7,8 }),
            new StudentGrades("Popescu Mihai",new uint[]{5,8,10, 9 ,9}, new uint[]{9,4,10,10},new uint[] {10,7,4,8 }),
            new StudentGrades("Matei Andrei",new uint[]{ 10, 10,10,9 }, new uint[]{10,10},new uint[] {9,7,5 }),
                };
            decimal averageGradeToFind = 8.92M;
            string[] expectedStudents = { "Matei Andrei", "Bancos Andrei" };

            Student[] studentsGrades = CalculateAverageGradeAndSort(catalogue);

            string[] studentsFound = FindAllStudentsWithCustomGrades(studentsGrades, averageGradeToFind);

            CollectionAssert.AreEqual(expectedStudents, studentsFound);
        }

        [TestMethod]
        public void FindAllTheBestStudents()
        {
            StudentGrades[] catalogue =
               {
            new StudentGrades ("Andrei Maria",new uint[] { 10,9,9},new uint[] {8 },new uint[] {9,10,7 }),
            new StudentGrades("Ban Andrei",new uint[]{ 10, 10, 9 }, new uint[]{10,9,10,10},new uint[] {9,7 }),
            new StudentGrades("Vlad Mihai",new uint[]{ 8,10, 9 }, new uint[]{9,10,10},new uint[] {10,7 }),
            new StudentGrades("Pop Mihai",new uint[]{5,8,10, 9 }, new uint[]{9,4,10,10},new uint[] {10,7,4 }),
            new StudentGrades ("Man Maria",new uint[] { 10,9},new uint[] {8 ,5},new uint[] {9,10,7 }),
            new StudentGrades("Bancos Andrei",new uint[]{ 10, 10 }, new uint[]{10,9,10,10},new uint[] {9,7,5 }),
            new StudentGrades("Vladimir Mihai",new uint[]{ 8,9 }, new uint[]{9,7},new uint[] {7,8 }),
            new StudentGrades("Popescu Mihai",new uint[]{5,8,10, 9 ,9}, new uint[]{9,4,10,10},new uint[] {10,7,4,8 }),
                };

            Student[] expectedList =
            {
                new Student ("Ban Andrei",5M),
                new Student ("Bancos Andrei",5M),
            };
            int specialGrade = 10;

            Student[] studentsGrades = FindTheBestStudents(catalogue, specialGrade);

            CollectionAssert.AreEqual(expectedList, studentsGrades);
        }

        [TestMethod]
        public void FindTheBestStudent()
        {
            StudentGrades[] catalogue =
               {
            new StudentGrades ("Andrei Maria",new uint[] { 10,9,9},new uint[] {8 },new uint[] {9,10,7 }),
            new StudentGrades("Ban Andrei",new uint[]{ 10, 10, 9 }, new uint[]{10,9,10,10},new uint[] {9,7 }),
            new StudentGrades("Vlad Mihai",new uint[]{ 8,10, 9 }, new uint[]{9,10,10},new uint[] {10,7 }),
            new StudentGrades("Pop Mihai",new uint[]{5,8,10, 9 }, new uint[]{9,4,10,10},new uint[] {10,7,4 }),
            new StudentGrades ("Man Maria",new uint[] { 10,9},new uint[] {8 ,5},new uint[] {9,10,7 }),
            new StudentGrades("Bancos Andrei",new uint[]{ 10, 10 }, new uint[]{10,9,10,10},new uint[] {9,7,5 }),
            new StudentGrades("Vladimir Mihai",new uint[]{ 8,9 }, new uint[]{9,7},new uint[] {7,8 }),
            new StudentGrades("Popescu Mihai",new uint[]{10,8,10, 10 ,9}, new uint[]{9,4,10,10},new uint[] {10,7,4,8 }),
                };

            Student[] expectedList =
            {
                new Student ("Popescu Mihai",6M),
            };
            int specialGrade = 10;

            Student[] studentsGrades = FindTheBestStudents(catalogue, specialGrade);

            CollectionAssert.AreEqual(expectedList, studentsGrades);
        }
        [TestMethod]
        public void NotFoundTheBestStudent()
        {
            StudentGrades[] Catalogue =
               {
            new StudentGrades ("Andrei Maria",new uint[] { 6,9,9},new uint[] {8 },new uint[] {9,6,7 }),
            new StudentGrades("Ban Andrei",new uint[]{ 7,  9 }, new uint[]{9,6,5},new uint[] {9,7 }),
            new StudentGrades("Vlad Mihai",new uint[]{ 8,9, 9 }, new uint[]{9,9,8},new uint[] {9,7 }),
          };

            Student[] expectedList = new Student[0];

            int specialGrade = 10;

            Student[] studentsGrades = FindTheBestStudents(Catalogue, specialGrade);

            CollectionAssert.AreEqual(expectedList, studentsGrades);
        }

        [TestMethod]
        public void FindTheStudentWithLowestAverageGrade()
        {
            StudentGrades[] catalogue =
               {
            new StudentGrades ("Andrei Maria",new uint[] { 10,9,9},new uint[] {8 },new uint[] {9,10,7 }),
            new StudentGrades("Ban Andrei",new uint[]{ 10, 10, 9 }, new uint[]{10,9,10,10},new uint[] {9,7 }),
            new StudentGrades("Vlad Mihai",new uint[]{ 8,10, 9 }, new uint[]{9,10,10},new uint[] {10,7 }),
            new StudentGrades("Pop Mihai",new uint[]{5,8,10, 9 }, new uint[]{9,4,10,10},new uint[] {10,7,4 }),
            new StudentGrades ("Man Maria",new uint[] { 10,9},new uint[] {8 ,5},new uint[] {9,10,7 }),
            new StudentGrades("Bancos Andrei",new uint[]{ 10, 10 }, new uint[]{10,9,10,10},new uint[] {9,7,5 }),
            new StudentGrades("Bacos Ana",new uint[]{ 5, 4 }, new uint[]{5,4,6},new uint[] {5 }),
            new StudentGrades("Vladimir Mihai",new uint[]{ 8,9 }, new uint[]{9,7},new uint[] {7,8 }),
            new StudentGrades("Popescu Mihai",new uint[]{10,8,10, 10 ,9}, new uint[]{9,4,10,10},new uint[] {10,7,4,8 }),
                };

            Student[] expectedList =
            {
                new Student ("Bacos Ana",4.83M),
            };

            Student[] studentsGrades = FindTheLowestGrade(catalogue);

            CollectionAssert.AreEqual(expectedList, studentsGrades);
        }
        [TestMethod]
        public void FindTheStudentsWithTheLowestAverageGrade()
        {
            StudentGrades[] catalogue =
               {
            new StudentGrades ("Andrei Maria",new uint[] { 10,9,9},new uint[] {8 },new uint[] {9,10,7 }),
            new StudentGrades("Ban Andrei",new uint[]{ 10, 10, 9 }, new uint[]{10,9,10,10},new uint[] {9,7 }),
            new StudentGrades("Vlad Mihai",new uint[]{ 8,10, 9 }, new uint[]{9,10,10},new uint[] {10,7 }),
            new StudentGrades("Pop Mihai",new uint[]{5,8,10, 9 }, new uint[]{9,4,10,10},new uint[] {10,7,4 }),
            new StudentGrades ("Man Maria",new uint[] { 10,9},new uint[] {8 ,5},new uint[] {9,10,7 }),
            new StudentGrades("Bancos Andrei",new uint[]{ 10, 10 }, new uint[]{10,9,10,10},new uint[] {9,7,5 }),
            new StudentGrades("Bacos Ana",new uint[]{ 5, 4 }, new uint[]{5,4,6},new uint[] {5 }),
            new StudentGrades("Vladimir Mihai",new uint[]{ 8,9 }, new uint[]{9,7},new uint[] {7,8 }),
            new StudentGrades("Popescu Mihai",new uint[]{5}, new uint[]{5,4},new uint[] {5,4,6}),
                };

            Student[] expectedList =
            {
                new Student ("Bacos Ana",4.83M),
                new Student ("Popescu Mihai",4.83M),
            };

            Student[] studentsGrades = FindTheLowestGrade(catalogue);

            CollectionAssert.AreEqual(expectedList, studentsGrades);
        }
        [TestMethod]
        public void FindTheStudentsInEmptyCatalogue()
        {
            StudentGrades[] catalogue = { };

            Student[] expectedList = { };

            Student[] studentGrades = FindTheLowestGrade(catalogue);

            CollectionAssert.AreEqual(expectedList, studentGrades);
        }

        private Student[] FindTheLowestGrade(StudentGrades[] catalogue)
        {
            Student[] studentsGrades = new Student[catalogue.Length];
            Student[] minimGrades = new Student[0];
            decimal minimGrade = 11;
            for (int i = 0; i < catalogue.Length; i++)
            {
                CalculateGradeForAStudent(catalogue, i, ref studentsGrades);
                if (studentsGrades[i].averageGrade < minimGrade)
                {
                    minimGrade = studentsGrades[i].averageGrade;
                    AddStudentInResultList(ref minimGrades, 0, studentsGrades[i]);
                }
                else
                {
                    if (studentsGrades[i].averageGrade == minimGrade)
                    {
                        AddStudentInResultList(ref minimGrades, minimGrades.Length, studentsGrades[i]);
                    }
                }
            }
            return minimGrades;
        }

        private static void AddStudentInResultList(ref Student[] minimGrades, int index, Student student)
        {
            Array.Resize(ref minimGrades, index + 1);
            minimGrades[index].name = student.name;
            minimGrades[index].averageGrade = student.averageGrade;
        }

        private static Student[] CalculateAverageGradeAndSort(StudentGrades[] catalogue)
        {
            Student[] studentsGrades = CalculateGradesForAllStudents(catalogue);
            InsertionSortGeneralGrades(ref studentsGrades);
            return studentsGrades;
        }

        private static Student[] FindTheBestStudents(StudentGrades[] catalogue, int Grade)
        {
            Student[] allTheBestStudents = new Student[0];
            int max = 0;
            for (int i = 0; i < catalogue.Length; i++)
            {
                int numberOfSpecialGrade = CountGrade(catalogue[i], Grade);
                if (numberOfSpecialGrade > max)
                {
                    max = numberOfSpecialGrade;
                    Student student = new Student();
                    student.name = catalogue[i].name;
                    student.averageGrade = numberOfSpecialGrade;
                    AddStudentInResultList(ref allTheBestStudents, 0, student);

                }
                else
                {
                    if ((numberOfSpecialGrade == max) && (max != 0))
                    {
                        Student student = new Student();
                        student.name = catalogue[i].name;
                        student.averageGrade = numberOfSpecialGrade;
                        AddStudentInResultList(ref allTheBestStudents, allTheBestStudents.Length, student);
                    }
                }

            }
            return allTheBestStudents;
        }

        private static int CountGrade(StudentGrades studentGrades, int grade)
        {
            var number1 = studentGrades.course1Grades;
            int foundGrade1 = CountGradeForADiscipline(number1, grade);
            var number2 = studentGrades.course2Grades;
            int foundGrade2 = CountGradeForADiscipline(number2, grade);
            var number3 = studentGrades.course3Grades;
            int foundGrade3 = CountGradeForADiscipline(number3, grade);
            return foundGrade1 + foundGrade2 + foundGrade3;
        }

        private static int CountGradeForADiscipline(uint[] number, int grade)
        {
            int count = 0;
            for (int i = 0; i < number.Length; i++)
            {
                if (number[i] == grade)
                {
                    count++;
                }
            }
            return count;
        }

        private static string[] FindAllStudentsWithCustomGrades(Student[] studentsGrades, decimal generalGradeToFind)
        {

            int indexofstudentFound = BinarySearch(studentsGrades, generalGradeToFind, 0, studentsGrades.Length - 1);
            if (indexofstudentFound != -1)
            {
                return FindAllStudentsWithTheSameGrade(studentsGrades, indexofstudentFound);

            }
            return null;
        }

        private static string[] FindAllStudentsWithTheSameGrade(Student[] studentsGrades, int index)
        {
            string[] allStudents = { studentsGrades[index].name };
            //right search
            int j = index + 1;
            while (j < studentsGrades.Length && (studentsGrades[index].averageGrade == (studentsGrades[j].averageGrade)))
            {
                AddAnotherStudentToList(ref allStudents, j, studentsGrades[j].name);
                j++;
            };
            //left search
            int k = index - 1;
            while (k > 0 && (studentsGrades[index].averageGrade == (studentsGrades[k].averageGrade)))
            {
                AddAnotherStudentToList(ref allStudents, k, studentsGrades[k].name);
                k--;
            };
            return allStudents;
        }

        private static void AddAnotherStudentToList(ref string[] allStudents, int j, string nameOfStudent)
        {
            Array.Resize(ref allStudents, allStudents.Length + 1);
            allStudents[allStudents.Length - 1] = nameOfStudent;
        }

        private static int BinarySearch(Student[] studentsGrades, decimal gradeToFind, int begin, int end)
        {
            if (begin > end) return -1;
            int middle = begin + (end - begin) / 2;
            Student middleElement = studentsGrades[middle];
            if (gradeToFind < middleElement.averageGrade)
            {
                return BinarySearch(studentsGrades, gradeToFind, middle + 1, end);
            }
            else
            {
                if (gradeToFind == middleElement.averageGrade)
                {
                    return middle;
                }
            }
            return BinarySearch(studentsGrades, gradeToFind, begin, middle - 1);

        }

        private static void InsertionSortGeneralGrades(ref Student[] studentsGrades)
        {
            for (int i = 1; i < studentsGrades.Length; i++)
            {
                if (studentsGrades[i].averageGrade > studentsGrades[i - 1].averageGrade)
                {
                    InsertElementInRightPosition(ref studentsGrades, i);
                }

            }
        }

        private static void InsertElementInRightPosition(ref Student[] listOfGrades, int index)
        {
            int j = index;
            do
            {
                if ((listOfGrades[j].averageGrade) > listOfGrades[j - 1].averageGrade)
                {
                    Swap(ref listOfGrades[j], ref listOfGrades[j - 1]);
                }
                j--;
            }
            while (j > 0 || ((listOfGrades[j + 1].averageGrade) > listOfGrades[j].averageGrade));
        }

        private static void Swap(ref Student firstValue, ref Student secondValue)
        {
            var temporary = new Student();
            temporary = firstValue;
            firstValue = secondValue;
            secondValue = temporary;
        }

        private static Student[] CalculateGradesForAllStudents(StudentGrades[] catalogue)
        {

            Student[] studentsGrades = new Student[catalogue.Length];
            for (int i = 0; i < catalogue.Length; i++)
            {
                CalculateGradeForAStudent(catalogue, i, ref studentsGrades);
            }
            return studentsGrades;
        }

        private static void CalculateGradeForAStudent(StudentGrades[] catalogue, int i, ref Student[] studentsGrades)
        {
            studentsGrades[i].name = catalogue[i].name;
            decimal generalGrade = (CalculateGrade(catalogue[i].course1Grades) + CalculateGrade(catalogue[i].course2Grades) + CalculateGrade(catalogue[i].course3Grades)) / 3;
            studentsGrades[i].averageGrade = Math.Round(generalGrade, 2);
        }

        private static decimal CalculateGrade(uint[] grades)
        {
            if (grades.Length == 0) return 0;
            decimal sum = 0;
            for (int i = 0; i < grades.Length; i++)
            {
                sum += grades[i];
            }
            return sum / grades.Length;

        }

    }
}
