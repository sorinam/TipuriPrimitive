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
            public List<uint> Matter1;
            public List<uint> Matter2;
            public List<uint> Matter3;
            public Student(string name, List<uint> Matter1, List<uint> Matter2, List<uint> Matter3)
            {
                this.name = name;
                this.Matter1 = new List<uint>();
                this.Matter2 = new List<uint>();
                this.Matter3 = new List<uint>();
            }
        }
        public struct StudentAverage
        {
            public string name;
            public float averagenumber ;
            
            public StudentAverage(string name, float Note)
            {
                this.name = name;
                this.averagenumber = Note;
            }
        }

        [TestMethod]
        public void Students()
        {
            Student[] ClassCatalogue =
               {
                new Student ("Andrei Maria",new List<uint>{ 10,9},new List<uint> { 10,8,9},new List<uint> {10 }),
                new Student ("Ban Claudiu",new List<uint>{7,10,9},new List<uint> { 10,10,9},new List<uint> {4,7}),
                new Student ("Coman Ana",new List<uint>{10,10,7},new List<uint> { 10,8,6},new List<uint> {8,7,9 }),
                new Student ("Radu Andrei",new List<uint>{ 9,4,7},new List<uint> { 9},new List<uint> {10,9,7 }),
                new Student ("Toma Dan",new List<uint>{ 10,9},new List<uint> { 8,9},new List<uint> {7,8,6,6 }),
            };
            StudentAverage[] ClassAverage=CalculateGeneralAverageForAllStudents(ClassCatalogue);
        }

        private static StudentAverage[] CalculateGeneralAverageForAllStudents(Student[] classCatalogue)
        {   StudentAverage[] studentNotes = new StudentAverage[classCatalogue.Length];
        
           StudentAverage studentAverageNotes = new StudentAverage();

           for (int i=0;i<classCatalogue.Length;i++)
            {
                studentAverageNotes.averagenumber = CalculateGeneralAverageForOneStudent(classCatalogue[i]);
                studentAverageNotes.name = classCatalogue[i].name;
                studentNotes[i] = studentAverageNotes;
            }
            return studentNotes;
        }

        private static float CalculateGeneralAverageForOneStudent(Student student)
        {
            float[] averageForEachMatters = new float[3];
            averageForEachMatters[0] = CalculateAverageForOneMatter(student.Matter1);
            averageForEachMatters[1] = CalculateAverageForOneMatter(student.Matter2);
            averageForEachMatters[2] = CalculateAverageForOneMatter(student.Matter3);
            return (averageForEachMatters[0] + averageForEachMatters[0] + averageForEachMatters[0]) / 3;

        }

        private static float CalculateAverageForOneMatter(List<uint> Notes)
        {
            if (Notes.Count == 0) return 0;
            float sum = 0;
             for (int i = 0; i < Notes.Count; i++)
                {
                    sum += Notes[i];
                }
         return sum / Notes.Count;
            
        }
    
    }
}
