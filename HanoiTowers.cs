using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace TipuriPrimitive
{
    [TestClass]
    public class HanoiTowers
    {
        public Int64 movesCount = 0;

        [TestMethod]
        public void TowersofHanoi()
        {
            int numberOfDisks = 20;
            Int64 expectedMoves = (Int64)Math.Pow(2, numberOfDisks) - 1;

            List<int> ATower = GenerateDisks(numberOfDisks);
            List<int> BTower = new List<int>();
            List<int> CTower = new List<int>();

            HanoiTowersMoves(numberOfDisks, ATower, BTower, CTower);

            Assert.AreEqual(expectedMoves, movesCount);
        }

        [TestMethod]
        public void TowersofHanoiOneDisk()
        {
            int numberOfDisks = 1;
          
            List<int> ATower = GenerateDisks(numberOfDisks);
            List<int> BTower = new List<int>();
            List<int> CTower = new List<int>();

            HanoiTowersMoves(numberOfDisks, ATower, BTower, CTower);

            Assert.AreEqual(1, movesCount);
        }

        [TestMethod]
        public void TowersofHanoiTwoDisks()
        {
            int numberOfDisks = 2;

            List<int> ATower = GenerateDisks(numberOfDisks);
            List<int> BTower = new List<int>();
            List<int> CTower = new List<int>();

            HanoiTowersMoves(numberOfDisks, ATower, BTower, CTower);

            Assert.AreEqual(3, movesCount);
        }

        [TestMethod]
        public void TowersofHanoiThreeDisks()
        {
            int numberOfDisks = 3;

            List<int> ATower = GenerateDisks(numberOfDisks);
            List<int> BTower = new List<int>();
            List<int> CTower = new List<int>();

            HanoiTowersMoves(numberOfDisks, ATower, BTower, CTower);

            Assert.AreEqual(7, movesCount);
        }

        private List<int> GenerateDisks(int index)
        {
            List<int> outputList = new List<int>();
            for (int i = 0; i < index; i++)
            {
                outputList.Add(index - i);
            }
            return outputList;
        }

        private void HanoiTowersMoves(int n, List<int> source, List<int> destination, List<int> via)
        {
            if (n == 0)
            {
                return;
            }
            if (n > 0)
            {
                HanoiTowersMoves(n - 1, source, via, destination);
                MoveDisk(n, source, destination);
                movesCount++;
                HanoiTowersMoves(n - 1, via, destination, source);
            }
        }

        private void MoveDisk(int n, List<int> source, List<int> destination)
        {
            var index = source.Count - 1;
            int topDisk = source[index];
            source.Remove(topDisk);
            destination.Add(topDisk);
        }

    }
}
