using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;

namespace TipuriPrimitive
{
    [TestClass]
    public class Sorting
    {
        public enum Priority { High = 1, Medium, Low };
        public struct Repairs
        {
            public string name;
            public Priority priority;
            public Repairs(string name, Priority priority)
            {
                this.name = name;
                this.priority = priority;
            }
        }

        public struct Words
        {
            public string word;
            public int number;
        }

        [TestMethod]
        public void DisplayLotoNumbersUsingMergeSortAlghorithm()
        {
            int[] extractedLotoNumbers = { 16, 8, 1, 15, 46, 3 };
            int[] sortedLotoNumbers = { 1, 3, 8, 15, 16, 46 };

            Assert.IsTrue(IsValid(extractedLotoNumbers), "Invalid array !");
            MergeSort(ref extractedLotoNumbers);
            CollectionAssert.AreEqual(sortedLotoNumbers, extractedLotoNumbers);
        }
        [TestMethod]
        public void DisplayLotoNoNumbersUsingMergeSortAlghoritm()
        {
            int[] extractedLotoNumbers = { };
            int[] sortedLotoNumbers = { };
            MergeSort(ref extractedLotoNumbers);
            CollectionAssert.AreEqual(sortedLotoNumbers, extractedLotoNumbers);
        }
        [TestMethod]
        public void DisplayLotoNumbersUsingSelectionAlghorithm()
        {
            int[] extractedLotoNumbers = { 16, 8, 1, 15, 46, 3 };
            int[] sortedLotoNumbers = { 1, 3, 8, 15, 16, 46 };
            SelectionSort(ref extractedLotoNumbers);
            CollectionAssert.AreEqual(sortedLotoNumbers, extractedLotoNumbers);
        }
        [TestMethod]
        public void DisplayLotoNoNumbersUsingSelectionAlghorithm()
        {
            int[] extractedLotoNumbers = { };
            int[] sortedLotoNumbers = { };
            SelectionSort(ref extractedLotoNumbers);
            CollectionAssert.AreEqual(sortedLotoNumbers, extractedLotoNumbers);
        }

        [TestMethod]
        public void SortingArrayUSingMergeSortAlghoritm()
        {
            int[] sourceArray = { 2 };
            int[] sortedArray = { 2 };
            MergeSort(ref sourceArray);
            CollectionAssert.AreEqual(sortedArray, sourceArray);
        }
        [TestMethod]
        public void SortingArrayWithTwoElementsMergeSortAlghoritm()
        {
            int[] sourceArray = { 12, 8 };
            int[] sortedArray = { 8, 12 };
            MergeSort(ref sourceArray);
            CollectionAssert.AreEqual(sortedArray, sourceArray);
        }
        [TestMethod]
        public void SortingArrayWithThreeElementsMergeSortAlghoritm()
        {
            int[] sourceArray = { 12, 1, 8 };
            int[] sortedArray = { 1, 8, 12 };
            MergeSort(ref sourceArray);
            CollectionAssert.AreEqual(sortedArray, sourceArray);
        }

        [TestMethod]
        public void TestMergeSortedArrays()
        {
            int[] a = { 4, 7, 59, 87 };
            int[] b = { 1, 3, 6, 100 };
            int[] c = new int[a.Length + b.Length];
            int[] sortedArray = { 1, 3, 4, 6, 7, 59, 87, 100 };
            Merge(a, b, ref c);
            CollectionAssert.AreEqual(sortedArray, c);
        }

        private static void MergeSort(ref int[] inputArray)
        {
            if (inputArray.Length > 0)
            {
                if (inputArray.Length <= 2)
                {
                    if (inputArray.Length == 1) return;
                    if (inputArray[0] > inputArray[1])
                    {
                        Swap(ref inputArray[0], ref inputArray[1]);
                        return;
                    }
                }
                int index = inputArray.Length / 2;
                int[] leftArray = new int[index];
                int[] rightArray = new int[inputArray.Length - index];
                SplitArray(inputArray, ref leftArray, ref rightArray);
                MergeSort(ref leftArray);
                MergeSort(ref rightArray);
                Merge(leftArray, rightArray, ref inputArray);
            }
        }
        private static void Merge(int[] firstArray, int[] secondArray, ref int[] sortedArray)
        {
            int i = 0;
            int j = 0;
            int k = 0;
            do
            {
                if (firstArray[i] < secondArray[j])
                {
                    sortedArray[k++] = firstArray[i++];
                }
                else
                {
                    sortedArray[k++] = secondArray[j++];
                }

            }
            while (i < firstArray.Length && j < secondArray.Length);

            if (i == firstArray.Length)
            {
                Array.Copy(secondArray, j, sortedArray, k, secondArray.Length - j);
            }
            else
            {
                Array.Copy(firstArray, i, sortedArray, k, firstArray.Length - i);

            }
        }
        private static void SplitArray(int[] inputArray, ref int[] leftArray, ref int[] rightArray)
        {
            int index = inputArray.Length / 2;
            Array.Copy(inputArray, leftArray, index);
            Array.Copy(inputArray, index, rightArray, 0, inputArray.Length - index);
        }

        private static void SelectionSort(ref int[] sourceArray)
        {
            int indexOfMinim;
            for (int i = 0; i < sourceArray.Length - 1; i++)
            {
                indexOfMinim = FindIndexOfMinim(sourceArray, i);
                if (indexOfMinim != i)
                {
                    Swap(ref sourceArray[i], ref sourceArray[indexOfMinim]);
                }
            }
        }
        private static int FindIndexOfMinim(int[] sourceArray, int index)
        {
            for (int j = index + 1; j < sourceArray.Length; j++)
            {
                if (sourceArray[j] < sourceArray[index])
                {
                    index = j;
                }
            }
            return index;
        }

        private static void Swap(ref int firstElement, ref int secondElement)
        {
            var temporary = firstElement;
            firstElement = secondElement;
            secondElement = temporary;
        }

        private bool IsValid(int[] LotoNumbers)
        {
            if (LotoNumbers.Length < 1) return false;
            for (int i = 0; i < LotoNumbers.Length - 1; i++)
            {
                if (IsFound(LotoNumbers, LotoNumbers[i], i)) return false;
            }
            return true;
        }
        private bool IsFound(int[] numbers, int value, int index)
        {
            for (int i = index + 1; i < numbers.Length; i++)
            {
                if (numbers[i] == value) return true;
            }
            return false;
        }

        [TestMethod]
        public void SortUsingQuickSortAlghorithm()
        {
            int[] Numbers = { 16, 8, 1, 8, 0, 23, 8, 4, 56, 3, 1 };
            int[] sortNumbers = { 0, 1, 1, 3, 4, 8, 8, 8, 16, 23, 56 };

            QuickSort(ref Numbers, 0, Numbers.Length - 1);
            CollectionAssert.AreEqual(sortNumbers, Numbers);
        }
        private static int Partition(int[] sourceArray, int left, int right)
        {
            int pivot = sourceArray[right];
            int i = left;

            for (int j = left; j < right; j++)
            {
                if (sourceArray[j] <= pivot)
                {
                    Swap(ref sourceArray[i], ref sourceArray[j]);
                    i++;
                }
            }

            sourceArray[right] = sourceArray[i];
            sourceArray[i] = pivot;

            return i;
        }
        private static void QuickSort(ref int[] sourceArray, int left, int right)
        {
            if (left < right)
            {
                int index = Partition(sourceArray, left, right);
                QuickSort(ref sourceArray, left, index - 1);
                QuickSort(ref sourceArray, index + 1, right);
            }
        }

        [TestMethod]
        public void RepairsOrder()
        {
            Repairs[] Clients =
             {
             new Repairs("Mancas",Priority.High),
             new Repairs("Pop",Priority.Low),
             new Repairs("Anca",Priority.Low),
             new Repairs("Man",Priority.Medium),
             new Repairs("Dan",Priority.Medium),
             new Repairs("Voicu",Priority.High),
            };
            Repairs[] SortedClients =
             {
             new Repairs("Mancas",Priority.High),
             new Repairs("Voicu",Priority.High),
             new Repairs("Man",Priority.Medium),
             new Repairs("Dan",Priority.Medium),
             new Repairs("Anca",Priority.Low),
             new Repairs("Pop",Priority.Low)
            };

            SortClients(ref Clients);

            CollectionAssert.AreEqual(SortedClients, Clients);
        }
        private void SortClients(ref Repairs[] clients)
        {
            int indexOfMinim;
            for (int i = 0; i < clients.Length - 1; i++)
            {
                indexOfMinim = SFindIndexOfMinim(clients, i);
                if (indexOfMinim != i)
                {
                    Repairs temp;
                    temp = clients[i];
                    clients[i] = clients[indexOfMinim];
                    clients[indexOfMinim] = temp;

                }
            }
        }
        private static int SFindIndexOfMinim(Repairs[] sourceArray, int index)
        {
            for (int j = index + 1; j < sourceArray.Length; j++)
            {
                if ((int)(sourceArray[j].priority) < (int)sourceArray[index].priority)
                {
                    index = j;
                }
            }
            return index;
        }

        [TestMethod]
        public void SortingWords()
        {
            string textToOrder = "Variables that are value types store data, and those that are reference types store references to the actual data. Reference types are also referred to as objects. Pointer types can be used only in unsafe mode.";

            List<Words> Dictionary = CreateDictionarry(textToOrder);
            LQuickSort(ref Dictionary, 0, Dictionary.Count - 1);
            Assert.AreEqual(1, 2);
        }
        private static int LPartition(List<Words> sourceArray, int left, int right)
        {
            var pivot = sourceArray[right].number;
            int i = left;

            for (int j = left; j < right; j++)
            {
                if (sourceArray[j].number <= pivot)
                {
                    Words temp = sourceArray[i];
                    sourceArray[i] = sourceArray[j];
                    sourceArray[j] = temp;
                    i++;
                }
            }

            sourceArray[right] = sourceArray[i];
            //sourceArray[i].number = pivot;

            return i;
        }
        private static void LQuickSort(ref List<Words> sourceArray, int left, int right)
        {
            if (left < right)
            {
                int index = LPartition(sourceArray, left, right);
                LQuickSort(ref sourceArray, left, index - 1);
                LQuickSort(ref sourceArray, index + 1, right);
            }
        }
        private List<Words> CreateDictionarry(string textToOrder)
        {
            List<Words> Dictionary = new List<Words>();
            string[] Words = GetWords(textToOrder);
            string word;
            for (int i = 0; i < Words.Length; i++)
            {
                word = Words[i];
                int position = PositionInDictionary(word, Dictionary);
                if (position > 0)
                { IncreaseWordItterations(ref Dictionary, position); }
                else
                {
                    AddWordInDictionary(word, ref Dictionary);
                }
            }
            return Dictionary;
        }
        private static void IncreaseWordItterations(ref List<Words> dictionary, int position)
        {
            Words word = new Words();
            word.number = dictionary[position].number + 1;
            word.word = dictionary[position].word;
            dictionary.Remove(dictionary[position]);
            dictionary.Add(word);
        }
        private void AddWordInDictionary(string word, ref List<Words> dictionary)
        {
            Words element = new Words();
            element.number = 1;
            element.word = word;
            dictionary.Add(element);
        }
        private string[] GetWords(string input)
        {
            MatchCollection matches = Regex.Matches(input, @"\b[\w']*\b");

            var words = from m in matches.Cast<Match>()
                        where !string.IsNullOrEmpty(m.Value)
                        select TrimSuffix(m.Value);

            return words.ToArray();
        }
        static string TrimSuffix(string word)
        {
            int apostropheLocation = word.IndexOf('\'');
            if (apostropheLocation != -1)
            {
                word = word.Substring(0, apostropheLocation);
            }

            return word;
        }
        private int PositionInDictionary(string word, List<Words> Dictionary)
        {
            for (int i = 0; i < Dictionary.Count; i++)
            {
                if (word == Dictionary[i].word) { return i; }
            }
            return 0;
        }


    }
}



