using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace TipuriPrimitive
{
    [TestClass]
    public class HanoiTowers
    {
        public List<string> listOfMovements = new List<string>();

        [TestMethod]
        public void TowersofHanoi()
        {
            int numberofDisks = 20;
            Hanoi(numberofDisks, 'A', 'B', 'C');
            Assert.AreEqual(1048575, listOfMovements.Count);
        }
        private void Hanoi(int n, char source, char destination, char via)
        {  if (n==0)
            {
                return;
            }
            if (n > 0)
            {
                Hanoi(n - 1, source, via, destination);
                string movement="Move disk "+n+" from disk "+source+" to disk " + destination;
                listOfMovements.Add(movement);
                Hanoi(n - 1, via, destination, source);
            }
        }
    }
}
