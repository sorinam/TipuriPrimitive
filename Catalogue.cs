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
            public float finalGrade;
            public Student(string name, float grade)
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
        public void Students()
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
            Student[] StudentsGrades = CalculateGradesForAllStudents(Catalogue);
            InsertionSortGeneralGrades(ref StudentsGrades);
            Assert.AreEqual(1, 3);

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
            float generalGrade = (CalculateGrade(catalogue[i].Discipline1Grades) + CalculateGrade(catalogue[i].Discipline2Grades) + CalculateGrade(catalogue[i].Discipline3Grades)) / 3;
            studentsGrades[i].finalGrade = generalGrade;
        }

        private static float CalculateGrade(uint[] grades)
        {
            if (grades.Length == 0) return 0;
            float sum = 0;
            for (int i = 0; i < grades.Length; i++)
            {
                sum += grades[i];
            }
            return sum / grades.Length;

        }

    }
}
