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
            public decimal finalGrade;
            public Student(string name, decimal grade)
            {
                this.name = name;
                this.finalGrade = grade;
            }
        }
        public struct StudentGrades
        {
            public string name;
            public uint[] Discipline1Grades;
            public uint[] Discipline2Grades;
            public uint[] Discipline3Grades;
            public StudentGrades(string name, uint[] Grades1, uint[] Grades2, uint[] Grades3)
            {
                this.name = name;
                this.Discipline1Grades = Grades1;
                this.Discipline2Grades = Grades2;
                this.Discipline3Grades = Grades3;
            }
        }

        [TestMethod]
        public void SortDescendingStudents()
        {
            StudentGrades[] Catalogue =
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
            Student[] StudentsGrades = CalculateAverageGradeAndSort(Catalogue);

            CollectionAssert.AreEqual(expectedSortedList, StudentsGrades);
        }

        [TestMethod]
        public void FindStudentWithCustomGrades()
        {
            StudentGrades[] Catalogue =
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
            decimal finalGradeToFind = 8.67M;
            string[] expectedStudent = { "Andrei Maria" };

            Student[] StudentsGrades = CalculateAverageGradeAndSort(Catalogue);
            string[] studentsFound = FindAllStudentsWithCustomGrades(StudentsGrades, finalGradeToFind);

            CollectionAssert.AreEqual(expectedStudent, studentsFound);
        }

        [TestMethod]
        public void NotFoundStudentWithCustomGrades()
        {
            StudentGrades[] Catalogue =
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
            decimal finalGradeToFind = 8.65M;
            string[] expectedStudents = null;

            Student[] StudentsGrades = CalculateAverageGradeAndSort(Catalogue);
            string[] studentsFound = FindAllStudentsWithCustomGrades(StudentsGrades, finalGradeToFind);

            CollectionAssert.AreEqual(expectedStudents, studentsFound);
        }
        [TestMethod]
        public void FindAllStudentsWithCustomGrades()
        {
            StudentGrades[] Catalogue =
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
            decimal finalGradeToFind = 8.92M;
            string[] expectedStudents = { "Matei Andrei", "Bancos Andrei" };

            Student[] StudentsGrades = CalculateAverageGradeAndSort(Catalogue);

            string[] studentsFound = FindAllStudentsWithCustomGrades(StudentsGrades, finalGradeToFind);

            CollectionAssert.AreEqual(expectedStudents, studentsFound);
        }

        [TestMethod]
        public void FindAllTheBestStudents()
        {
            StudentGrades[] Catalogue =
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

            Student[] StudentsGrades = FindTheBestStudents(Catalogue, specialGrade);

            CollectionAssert.AreEqual(expectedList, StudentsGrades);
        }

        [TestMethod]
        public void FindTheBestStudent()
        {
            StudentGrades[] Catalogue =
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

            Student[] StudentsGrades = FindTheBestStudents(Catalogue, specialGrade);

            CollectionAssert.AreEqual(expectedList, StudentsGrades);
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

            Student[] StudentsGrades = FindTheBestStudents(Catalogue, specialGrade);

            CollectionAssert.AreEqual(expectedList, StudentsGrades);
        }

        [TestMethod]
        public void FindTheStudentWithLowestGeneralGrade()
        {
            StudentGrades[] Catalogue =
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

            Student[] StudentsGrades = FindTheWorstStudents(Catalogue);

            CollectionAssert.AreEqual(expectedList, StudentsGrades);
        }
        [TestMethod]
        public void FindTheStudentsWithTheLowestGeneralGrade()
        {
            StudentGrades[] Catalogue =
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

            Student[] StudentsGrades = FindTheWorstStudents(Catalogue);

            CollectionAssert.AreEqual(expectedList, StudentsGrades);
        }
        [TestMethod]
        public void FindTheStudentsInEmptyCatalogue()
        {
            StudentGrades[] Catalogue = { };

            Student[] expectedList = { };

            Student[] StudentsGrades = FindTheWorstStudents(Catalogue);

            CollectionAssert.AreEqual(expectedList, StudentsGrades);
        }

        private Student[] FindTheWorstStudents(StudentGrades[] catalogue)
        {
            Student[] studentsGrades = new Student[catalogue.Length];
            Student[] MinimGrades = new Student[0];
            decimal minimGrade = 11;
            for (int i = 0; i < catalogue.Length; i++)
            {
                CalculateGradeForAStudent(catalogue, i, ref studentsGrades);
                if (studentsGrades[i].finalGrade < minimGrade)
                {
                    minimGrade = studentsGrades[i].finalGrade;
                    Array.Resize(ref MinimGrades, 1);
                    MinimGrades[0].name = studentsGrades[i].name;
                    MinimGrades[0].finalGrade = studentsGrades[i].finalGrade;
                }
                else
                {
                    if (studentsGrades[i].finalGrade == minimGrade)
                    {
                        int newsize = MinimGrades.Length + 1;
                        Array.Resize(ref MinimGrades, newsize);
                        MinimGrades[newsize - 1].name = studentsGrades[i].name;
                        MinimGrades[newsize - 1].finalGrade = studentsGrades[i].finalGrade;
                    }
                }
            }
            return MinimGrades;
        }

        private static Student[] CalculateAverageGradeAndSort(StudentGrades[] Catalogue)
        {
            Student[] StudentsGrades = CalculateGradesForAllStudents(Catalogue);
            InsertionSortGeneralGrades(ref StudentsGrades);
            return StudentsGrades;
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
                    Array.Resize(ref allTheBestStudents, 1);
                    allTheBestStudents[0].name = catalogue[i].name;
                    allTheBestStudents[0].finalGrade = numberOfSpecialGrade;
                }
                else
                {
                    if ((numberOfSpecialGrade == max) && (max != 0))
                    {
                        int newsize = allTheBestStudents.Length + 1;
                        Array.Resize(ref allTheBestStudents, newsize);
                        allTheBestStudents[newsize - 1].name = catalogue[i].name;
                        allTheBestStudents[newsize - 1].finalGrade = numberOfSpecialGrade;
                    }
                }

            }
            return allTheBestStudents;
        }

        private static int CountGrade(StudentGrades studentGrades, int grade)
        {
            var number1 = studentGrades.Discipline1Grades;
            int foundGrade1 = CountGradeForADiscipline(number1, grade);
            var number2 = studentGrades.Discipline2Grades;
            int foundGrade2 = CountGradeForADiscipline(number2, grade);
            var number3 = studentGrades.Discipline3Grades;
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
                return FindAllStudents(studentsGrades, indexofstudentFound);

            }
            return null;
        }

        private static string[] FindAllStudents(Student[] studentsGrades, int index)
        {
            string[] AllStudents = { studentsGrades[index].name };
            //right search
            int j = index + 1;
            while (j < studentsGrades.Length && (studentsGrades[index].finalGrade == (studentsGrades[j].finalGrade)))
            {
                Array.Resize(ref AllStudents, AllStudents.Length + 1);
                AllStudents[AllStudents.Length - 1] = studentsGrades[j].name;
                j++;
            };
            //left search
            int k = index - 1;
            while (k > 0 && (studentsGrades[index].finalGrade == (studentsGrades[k].finalGrade)))
            {
                Array.Resize(ref AllStudents, AllStudents.Length + 1);
                AllStudents[AllStudents.Length - 1] = studentsGrades[k].name;
                k--;
            };
            return AllStudents;
        }

        private static int BinarySearch(Student[] studentsGrades, decimal GradeToFind, int begin, int end)
        {
            if (begin > end) return -1;
            int middle = begin + (end - begin) / 2;
            Student middleElement = studentsGrades[middle];
            if (GradeToFind < middleElement.finalGrade)
            {
                return BinarySearch(studentsGrades, GradeToFind, middle + 1, end);
            }
            else
            {
                if (GradeToFind == middleElement.finalGrade)
                {
                    return middle;
                }
            }
            return BinarySearch(studentsGrades, GradeToFind, begin, middle - 1);

        }

        private static void InsertionSortGeneralGrades(ref Student[] studentsGrades)
        {
            for (int i = 1; i < studentsGrades.Length; i++)
            {
                if (studentsGrades[i].finalGrade > studentsGrades[i - 1].finalGrade)
                {
                    InsertElementInRightPosition(ref studentsGrades, i);
                }

            }
        }

        private static void InsertElementInRightPosition(ref Student[] ListOfGrades, int index)
        {
            int j = index;
            do
            {
                if ((ListOfGrades[j].finalGrade) > ListOfGrades[j - 1].finalGrade)
                {
                    Swap(ref ListOfGrades[j], ref ListOfGrades[j - 1]);
                }
                j--;
            }
            while (j > 0 || ((ListOfGrades[j + 1].finalGrade) > ListOfGrades[j].finalGrade));
        }

        private static void Swap(ref Student firstValue, ref Student secondValue)
        {
            var temporary = new Student();
            temporary = firstValue;
            firstValue = secondValue;
            secondValue = temporary;
        }

        private static Student[] CalculateGradesForAllStudents(StudentGrades[] Catalogue)
        {

            Student[] studentsGrades = new Student[Catalogue.Length];
            for (int i = 0; i < Catalogue.Length; i++)
            {
                CalculateGradeForAStudent(Catalogue, i, ref studentsGrades);
            }
            return studentsGrades;
        }

        private static void CalculateGradeForAStudent(StudentGrades[] catalogue, int i, ref Student[] studentsGrades)
        {
            studentsGrades[i].name = catalogue[i].name;
            decimal generalGrade = (CalculateGrade(catalogue[i].Discipline1Grades) + CalculateGrade(catalogue[i].Discipline2Grades) + CalculateGrade(catalogue[i].Discipline3Grades)) / 3;
            studentsGrades[i].finalGrade = Math.Round(generalGrade, 2);
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
