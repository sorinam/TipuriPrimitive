using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace TipuriPrimitive
{
    [TestClass]
    public class HanoiTowers
    {

        public int numberofDisks =10;
        public string[,] moves = new string[(int)Math.Pow(2, 4) - 1, 3];
        public Int64 movesCount = 0;
        public List<int> ATower = new List<int> {10,9,8,7,6,5,4,3,2,1};
        public List<int> BTower = new List<int>();
        public List<int> CTower = new List<int>();

        [TestMethod]
        public void TowersofHanoi()
        {
            Hanoi(numberofDisks, 'A', 'B', 'C');
            Assert.AreEqual(16343, movesCount);
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
                MoveDisk(numberOfDisk, source, destination);
                movesCount++;
                Hanoi(numberOfDisk - 1, via, destination, source);
            }
        }
        public void SaveMove(int n, char source, char destination)
        {
            moves[movesCount, 0] = n.ToString();
            moves[movesCount, 1] = source.ToString();
            moves[movesCount, 2] = destination.ToString();
            
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
            List<int> result = new List<int>();
            switch (nameofList)
            {
                case 'A':
                    result = ATower;
                    break;
                case 'B':
                    result = BTower;
                    break;
                case 'C':
                    result = CTower;
                    break;
            }
            return result; ;
        }
    }
}
