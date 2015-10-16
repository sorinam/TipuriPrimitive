using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace TipuriPrimitive
{
    [TestClass]
    public class HanoiTowers
    {

        public static int numberofDisks = 2;
        public string[,] moves = new string [(int)Math.Pow(2,4)-1,3];
        public int movesCount = 0;

        [TestMethod]
        public void TowersofHanoi()
        {   
            Hanoi(numberofDisks, 'A', 'B', 'C');
            Assert.AreEqual(104, movesCount);
        }
        private void Hanoi(int numberOfDisk, char source, char destination, char via)
        {  if (numberOfDisk==0)
            {
                return;
            }
            if (numberOfDisk > 0)
            {
                Hanoi(numberOfDisk - 1, source, via, destination);
                SaveMove(numberOfDisk,source,destination);
                Hanoi(numberOfDisk - 1, via, destination, source);
            }
        }
        public void SaveMove(int n, char source, char destination)
        {
            moves[movesCount, 0] = n.ToString();
            moves[movesCount, 1] = source.ToString();
            moves[movesCount, 2] = destination.ToString();
            movesCount++;
        }
    }
}
