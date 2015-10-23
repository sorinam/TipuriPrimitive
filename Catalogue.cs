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

            Student[] StudentsGrades = CalculateGradesForAllStudents(Catalogue);
            InsertionSortGeneralGrades(ref StudentsGrades);

            CollectionAssert.AreEqual(expectedSortedList,StudentsGrades);
        }

        [TestMethod]
        public void FindStudentWithSpecifiedGrades()
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
            decimal generalGradeToFind = 8.67M;
            string expectedStudent = "Andrei Maria";

            Student[] StudentsGrades = CalculateGradesForAllStudents(Catalogue);
            InsertionSortGeneralGrades(ref StudentsGrades);
            string studentFound = BinarySearch(StudentsGrades, generalGradeToFind, 0, StudentsGrades.Length - 1);

            Assert.AreEqual(expectedStudent,studentFound);
        }

        private static string BinarySearch(Student[] studentsGrades, decimal GradeToFind,int begin,int end)
        {
            if (begin > end) return null;
            int middle = begin + (end - begin) / 2;
            Student middleElement = studentsGrades[middle];
            if (GradeToFind<middleElement.finalGrade)
            {
               return  BinarySearch(studentsGrades, GradeToFind, middle + 1, end);
            }
            else
            {
                if (GradeToFind == middleElement.finalGrade)
                {
                    return middleElement.name;
                }
            }
            return BinarySearch(studentsGrades, GradeToFind, begin, middle - 1);
            
        }

        private void InsertionSortGeneralGrades(ref Student[] studentsGrades)
        {
            for (int i = 1; i < studentsGrades.Length; i++)
            {
                if (studentsGrades[i].finalGrade > studentsGrades[i - 1].finalGrade)
                {
                    InsertElementInRightPosition(ref studentsGrades, i);
                }

            }
        }

        private void InsertElementInRightPosition(ref Student[] ListOfGrades, int index)
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
            studentsGrades[i].finalGrade = Math.Round(generalGrade,2);
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
