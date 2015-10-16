using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace TipuriPrimitive
{
    [TestClass]
    public class HanoiTowers
    {

        public int numberofDisks = 4;
        public string[,] moves = new string[(int)Math.Pow(2, 4) - 1, 3];
        public int movesCount = 0;
        public List<int> ListA = new List<int> {4,3,2,1};
        public List<int> ListB = new List<int>();
        public List<int> ListC = new List<int>();

        [TestMethod]
        public void TowersofHanoi()
        {
            Hanoi(numberofDisks, 'A', 'B', 'C');
            Assert.AreEqual(16, movesCount);
        }
        private void Hanoi(int numberOfDisk, char source, char destination, char via)
        {
            if (numberOfDisk == 0)
            {
                return;
            }
            if (numberOfDisk > 0)
            {
                Hanoi(numberOfDisk - 1, source, via, destination);
                SaveMove(numberOfDisk, source, destination);
                Hanoi(numberOfDisk - 1, via, destination, source);
            }
        }
        public void SaveMove(int n, char source, char destination)
        {
            moves[movesCount, 0] = n.ToString();
            moves[movesCount, 1] = source.ToString();
            moves[movesCount, 2] = destination.ToString();
            MoveDisk(n, source, destination);
            movesCount++;
        }

        private void MoveDisk(int n, char from, char to)
        {
            List<int> Source = GetList(from);
            List<int> Destination = GetList(to);
            Source.Remove(n);
            Destination.Add(n);
           
        }

        private List<int> GetList(char nameofList)
        {
            switch (nameofList)
            {
                case 'A':
                    return ListA;
                case 'B':
                    return ListB;
                case 'C':
                    return ListC;
            }
            return ListA;
        }
    }
}
