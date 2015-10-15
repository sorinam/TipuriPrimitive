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
        public void Hanoi()
        {
            int n = 20;
            hanoi(n, 'a', 'b', 'c');
            Assert.AreEqual(1048575, listOfMovements.Count);
        }
        private void hanoi(int n, char source, char destination, char via)
        {  if (n==0)
            {
                return;
            }
            if (n > 0)
            {
                hanoi(n - 1, source, via, destination);
                string movement="Move disk "+n+" from disk "+source+" to disk " + destination;
                listOfMovements.Add(movement);
                Console.WriteLine("Move disk {0} from {1} to {2}", n, source, destination);
                hanoi(n - 1, via, destination, source);
            }
        }
    }
}
