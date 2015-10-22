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

        public struct GlobalStruct
        {
            public string stringStruct;
            public int number;
            public GlobalStruct(string name, int number)
            {
                this.stringStruct = name;
                this.number = number;
            }
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
        public void FindAndSortWordsFromAText()
        {
            string textToOrder = "orice cuvant care orice care care care numai are multe are multe care multe multe a orice ";
            GlobalStruct[] expectedSortedWords =
            {
             new GlobalStruct("cuvant",1),
             new GlobalStruct("numai",1),
             new GlobalStruct("a",1),
             new GlobalStruct("are",2),
             new GlobalStruct("orice",3),
             new GlobalStruct("multe",4),
             new GlobalStruct("care",5),
            };

            GlobalStruct[] sortedWords = SortWordsFromText(textToOrder);
            CollectionAssert.AreEqual(expectedSortedWords, sortedWords);
        }
        [TestMethod]
        public void FindAndSortWordsFromEmptyText()
        {
            string textToOrder = " ";
            GlobalStruct[] expectedSortedWords = { };
            GlobalStruct[] sortedWords = SortWordsFromText(textToOrder);
            CollectionAssert.AreEqual(expectedSortedWords, sortedWords);
        }
        [TestMethod]
        public void FindAndSortWordsFromATextWithOneString()
        {
            string textToOrder = "zana ";
            GlobalStruct[] expectedSortedWords = { new GlobalStruct("zana", 1) };
            GlobalStruct[] sortedWords = SortWordsFromText(textToOrder);
            CollectionAssert.AreEqual(expectedSortedWords, sortedWords);
        }
        [TestMethod]
        public void FindAndSortDistinctWordsFromAText()
        {
            string textToOrder = "Mama are mere multe, dar care nu sunt acre!  ";
            GlobalStruct[] expectedSortedWords = {
            new GlobalStruct("Mama", 1),
            new GlobalStruct("are", 1),
            new GlobalStruct("mere", 1) ,
            new GlobalStruct("multe", 1),
            new GlobalStruct("dar", 1),
            new GlobalStruct("care", 1),
            new GlobalStruct("nu", 1),
            new GlobalStruct("sunt", 1),
            new GlobalStruct("acre", 1),
            };
            GlobalStruct[] sortedWords = SortWordsFromText(textToOrder);
            CollectionAssert.AreEqual(expectedSortedWords, sortedWords);
        }

        private GlobalStruct[] SortWordsFromText(string textToOrder)
        {
            GlobalStruct[] Dictionary = CreateDictionary(textToOrder);
            LQuickSort(ref Dictionary, 0, Dictionary.Length - 1);
            return Dictionary;
        }

        private static int LPartition(GlobalStruct[] sourceArray, int left, int right)
        {
            var pivot = sourceArray[right].number;
            var pivotName = sourceArray[right].stringStruct;
            int i = left;

            for (int j = left; j < right; j++)
            {
                if (sourceArray[j].number <= pivot)
                {
                    GlobalStruct temp = sourceArray[i];
                    sourceArray[i] = sourceArray[j];
                    sourceArray[j] = temp;
                    i++;
                }
            }

            sourceArray[right] = sourceArray[i];
            sourceArray[i].number = pivot;
            sourceArray[i].stringStruct = pivotName;
            return i;
        }
        private static void LQuickSort(ref GlobalStruct[] sourceArray, int left, int right)
        {
            if (left < right)
            {
                int index = LPartition(sourceArray, left, right);
                LQuickSort(ref sourceArray, left, index - 1);
                LQuickSort(ref sourceArray, index + 1, right);
            }
        }

        private static GlobalStruct[] CreateDictionary(string textToOrder)
        {
            int indexOfDictionary = 0;
            string[] Words = GetWords(textToOrder);
            GlobalStruct[] Dictionary = new GlobalStruct[Words.Length];
            string word;
            for (int i = 0; i < Words.Length; i++)
            {
                word = Words[i];
                int position = PositionInDictionary(word, Dictionary);
                if (position >= 0)
                {
                    IncreaseWordItterations(ref Dictionary, position);
                }
                else
                {
                    AddWordInDictionary(word, ref Dictionary, indexOfDictionary);
                    indexOfDictionary++;
                }
            }
            ResizeDictionary(ref Dictionary);
            return Dictionary;
        }
        private static void ResizeDictionary(ref GlobalStruct[] dictionary)
        {
            int index = FindFirstNullElement(dictionary);
            if (index > 0)
            {
                Array.Resize(ref dictionary, index);
            }
        }

        private static int FindFirstNullElement(GlobalStruct[] dictionary)
        {
            int indexOffirstNullElement = BinarySearchIndexOfFirstNullElement(dictionary, 0, dictionary.Length - 1);
            return indexOffirstNullElement;
        }

        [TestMethod]
        public void TestBinarySearchMethod1()
        {
            GlobalStruct[] Words = new GlobalStruct[3];
            Words[0].stringStruct = "bina";
            Words[0].number = 22;
            Assert.AreEqual(1, BinarySearchIndexOfFirstNullElement(Words, 0, Words.Length - 1));
        }
        [TestMethod]
        public void TestBinarySearchMethod0()
        {
            GlobalStruct[] Words = new GlobalStruct[3];
            Assert.AreEqual(0, BinarySearchIndexOfFirstNullElement(Words, 0, Words.Length - 1));
        }
        [TestMethod]
        public void TestBinarySearchMethod2()
        {
            GlobalStruct[] Words = new GlobalStruct[3];
            Words[0].stringStruct = "bina";
            Words[0].number = 22;
            Words[1].stringStruct = "bia";
            Words[1].number = 2;
            Words[2].stringStruct = "ba";
            Words[2].number = 32;
            Assert.AreEqual(-1, BinarySearchIndexOfFirstNullElement(Words, 0, Words.Length - 1));
        }

        private static int BinarySearchIndexOfFirstNullElement(GlobalStruct[] arrayToSearch, int begin, int end)
        {
            if (begin > end) return -1;
            int middle = begin + (end - begin) / 2;
            GlobalStruct middleElement = arrayToSearch[middle];
            if ((middleElement.number == 0) && (middleElement.stringStruct == null))
            {
                if (middle > 0)
                {
                    if (IsPreviousElementNeNull(arrayToSearch, middle))
                    {
                        return middle;
                    }
                    else
                    {
                        return BinarySearchIndexOfFirstNullElement(arrayToSearch, begin, middle - 1);
                    }
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                return BinarySearchIndexOfFirstNullElement(arrayToSearch, middle + 1, end);
            }
        }

        private static bool IsPreviousElementNeNull(GlobalStruct[] arrayToSearch, int middle)
        {
            if (((arrayToSearch[middle - 1].number != 0) && (arrayToSearch[middle - 1].stringStruct != null)))
            {
                return true;
            }
            return false;
        }

        private static void IncreaseWordItterations(ref GlobalStruct[] dictionary, int position)
        {
            dictionary[position].number++;
        }
        private static void AddWordInDictionary(string word, ref GlobalStruct[] dictionary, int indexOfDictionary)
        {
            GlobalStruct newElement = new GlobalStruct();
            newElement.number = 1;
            newElement.stringStruct = word;
            dictionary[indexOfDictionary] = newElement;
        }

        private static string[] GetWords(string input)
        {
            MatchCollection matches = Regex.Matches(input, @"\b[\w']*\b");

            var words = from m in matches.Cast<Match>()
                        where !string.IsNullOrEmpty(m.Value)
                        select TrimSuffix(m.Value);

            return words.ToArray();
        }
        private static string TrimSuffix(string word)
        {
            int apostropheLocation = word.IndexOf('\'');
            if (apostropheLocation != -1)
            {
                word = word.Substring(0, apostropheLocation);
            }

            return word;
        }

        private static int PositionInDictionary(string word, GlobalStruct[] Dictionary)
        {
            for (int i = 0; i < Dictionary.Length; i++)
            {
                if (word == Dictionary[i].stringStruct)
                {
                    return i;
                }
            }
            return -1;
        }

        [TestMethod]
        public void CentralizingVotes()
        {
            int numberOfVoteSection = 4;
            GlobalStruct[] list1 = { new GlobalStruct("Cretu Ene",100), new GlobalStruct("Man Ana", 43), new GlobalStruct("Pop Viorel", 24), new GlobalStruct("Avram Marin", 4) };
            GlobalStruct[] list2 = { new GlobalStruct("Cretu Ene", 154), new GlobalStruct("Man Ana", 87), new GlobalStruct("Pop Viorel", 25), new GlobalStruct("Avram Marin",14),new GlobalStruct("Pintea Radu",3) };
            GlobalStruct[] list3 = { new GlobalStruct("Pop Viorel", 45), new GlobalStruct("Avram Marin", 45), new GlobalStruct("Man Ana", 36), new GlobalStruct("Cretu Ene", 25) };
            GlobalStruct[] list4 = { new GlobalStruct("Popa Vanda", 63), new GlobalStruct("Cretu Ene", 47), new GlobalStruct("Avram Marin", 46) ,new GlobalStruct("Man Ana", 22)};

            GlobalStruct[][] ListOfVotes = {list1,list2,list3,list4 };

            GlobalStruct[] expectedVoteResults = new GlobalStruct[numberOfVoteSection];


            GlobalStruct[] calculateVotesResult = CentralizeAndSortVotes(ListOfVotes);

            CollectionAssert.AreEqual(expectedVoteResults, calculateVotesResult);
        }

        private static GlobalStruct[] CentralizeAndSortVotes(GlobalStruct[][] listOfVotes)
        {          
            GlobalStruct[] resultOfVotes=InitializingCanditatesList(listOfVotes[0]);
            CentralizedVotes(ref resultOfVotes, listOfVotes);
            return resultOfVotes;
        }

        private static void CentralizedVotes(ref GlobalStruct[] canditatesPosition, GlobalStruct[][] listOfVotes)
        {
          for(int i=1;i<listOfVotes.Length;i++)
            {
                AddList(listOfVotes[i],ref canditatesPosition);
                LQuickSort(ref canditatesPosition, 0, canditatesPosition.Length - 1);
                Array.Reverse(canditatesPosition);
            }
        }

        private static void AddList(GlobalStruct[] listFromVoteSection, ref GlobalStruct[] canditatesPosition)
        {
            int indexOfList = canditatesPosition.Length-1;
           foreach (GlobalStruct candidate in listFromVoteSection)
            {
                int index = PositionInDictionary(candidate.stringStruct, canditatesPosition);
                if (index>=0)
                {
                    ModifyNumberOfVotes(ref canditatesPosition,index, candidate.number);
                }
                else
                {
                    indexOfList++;
                    AddCanditatesInList(candidate, ref canditatesPosition, indexOfList);
                }
            }
        }

        private static void AddCanditatesInList(GlobalStruct candidate, ref GlobalStruct[] canditatesPosition,  int index)
        {
            Array.Resize(ref canditatesPosition, index+1);

            GlobalStruct newElement = new GlobalStruct();
            newElement.number = candidate.number;
            newElement.stringStruct = candidate.stringStruct;

            canditatesPosition[index] = newElement;
        }
        private static void ModifyNumberOfVotes(ref GlobalStruct[] canditatesPosition, int index, int number)
        {
            canditatesPosition[index].number += number;                            
        }

        private static GlobalStruct[] InitializingCanditatesList( GlobalStruct[] list)
        {
            GlobalStruct[] temporaryList = new GlobalStruct[list.Length];
            Array.Copy(list, temporaryList, list.Length);
            return temporaryList;
        }
    }}