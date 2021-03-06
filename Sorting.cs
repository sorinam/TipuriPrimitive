﻿using System;
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
            public string stringField;
            public int numericField;
            public GlobalStruct(string name, int number)
            {
                this.stringField = name;
                this.numericField = number;
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
            GlobalStruct[] Dictionary = CreateListOfStrings(textToOrder);
            StructQuickSort(ref Dictionary, 0, Dictionary.Length - 1);
            return Dictionary;
        }

        private static int StructPartition(GlobalStruct[] sourceArray, int left, int right)
        {
            var pivot = sourceArray[right].numericField;
            var pivotName = sourceArray[right].stringField;
            int i = left;

            for (int j = left; j < right; j++)
            {
                if (sourceArray[j].numericField <= pivot)
                {
                    StructSwap(ref sourceArray[i], ref sourceArray[j]);
                    i++;
                }
            }

            sourceArray[right] = sourceArray[i];
            sourceArray[i].numericField = pivot;
            sourceArray[i].stringField = pivotName;
            return i;
        }
        public static void StructQuickSort(ref GlobalStruct[] sourceArray, int left, int right)
        {
            if (left < right)
            {
                int index = StructPartition(sourceArray, left, right);
                StructQuickSort(ref sourceArray, left, index - 1);
                StructQuickSort(ref sourceArray, index + 1, right);
            }
        }

        private static GlobalStruct[] CreateListOfStrings(string textToOrder)
        {
            int indexOfList = 0;
            string[] Words = GetWords(textToOrder);
            GlobalStruct[] ListOfStrings = new GlobalStruct[Words.Length];
            string word;
            for (int i = 0; i < Words.Length; i++)
            {
                word = Words[i];
                int position = PositionInList(word, ListOfStrings);
                if (position >= 0)
                {
                    IncreaseWordItterations(ref ListOfStrings, position);
                }
                else
                {
                    AddWordInList(word, ref ListOfStrings, indexOfList);
                    indexOfList++;
                }
            }
            ResizeList(ref ListOfStrings);
            return ListOfStrings;
        }
        private static void ResizeList(ref GlobalStruct[] dictionary)
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
            Words[0].stringField = "bina";
            Words[0].numericField = 22;
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
            Words[0].stringField = "bina";
            Words[0].numericField = 22;
            Words[1].stringField = "bia";
            Words[1].numericField = 2;
            Words[2].stringField = "ba";
            Words[2].numericField = 32;
            Assert.AreEqual(-1, BinarySearchIndexOfFirstNullElement(Words, 0, Words.Length - 1));
        }

        private static int BinarySearchIndexOfFirstNullElement(GlobalStruct[] arrayToSearch, int begin, int end)
        {
            if (begin > end) return -1;
            int middle = begin + (end - begin) / 2;
            GlobalStruct middleElement = arrayToSearch[middle];
            if ((middleElement.numericField == 0) && (middleElement.stringField == null))
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
            if (((arrayToSearch[middle - 1].numericField != 0) && (arrayToSearch[middle - 1].stringField != null)))
            {
                return true;
            }
            return false;
        }

        private static void IncreaseWordItterations(ref GlobalStruct[] dictionary, int position)
        {
            dictionary[position].numericField++;
        }
        private static void AddWordInList(string word, ref GlobalStruct[] listOfString, int indexOfList)
        {
            GlobalStruct newElement = new GlobalStruct();
            newElement.numericField = 1;
            newElement.stringField = word;
            listOfString[indexOfList] = newElement;
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

        private static int PositionInList(string word, GlobalStruct[] listOfStrings)
        {
            for (int i = 0; i < listOfStrings.Length; i++)
            {
                if (word == listOfStrings[i].stringField)
                {
                    return i;
                }
            }
            return -1;
        }

        [TestMethod]
        public void CentralizationVotesFromMorePollingPlacesDifferentNumbersOfCandidates()
        {
            string[] listOfCandidates = { "Cretu Ene", "Pop Viorel", "Popa Vanda", "Avram Marin", "Man Ana", "Pintea Radu" };
            GlobalStruct[] list1 = { new GlobalStruct("Cretu Ene", 100), new GlobalStruct("Man Ana", 43), new GlobalStruct("Pop Viorel", 24), new GlobalStruct("Avram Marin", 4) };
            GlobalStruct[] list2 = { new GlobalStruct("Cretu Ene", 154), new GlobalStruct("Man Ana", 87), new GlobalStruct("Pop Viorel", 25), new GlobalStruct("Avram Marin", 14), new GlobalStruct("Pintea Radu", 3) };
            GlobalStruct[] list3 = { new GlobalStruct("Pop Viorel", 45), new GlobalStruct("Avram Marin", 45), new GlobalStruct("Man Ana", 36), new GlobalStruct("Cretu Ene", 25) };
            GlobalStruct[] list4 = { new GlobalStruct("Popa Vanda", 63), new GlobalStruct("Cretu Ene", 47), new GlobalStruct("Avram Marin", 46), new GlobalStruct("Man Ana", 22) };

            GlobalStruct[][] ReceivedVotingLists = { list1, list2, list3, list4 };

            GlobalStruct[] expectedVotingList = { new GlobalStruct("Cretu Ene", 326), new GlobalStruct("Man Ana", 188), new GlobalStruct("Avram Marin", 109), new GlobalStruct("Pop Viorel", 94), new GlobalStruct("Popa Vanda", 63), new GlobalStruct("Pintea Radu", 3) };


            GlobalStruct[] calculateVotingList = CentralizeAndSortVotes(listOfCandidates, ReceivedVotingLists);

            CollectionAssert.AreEqual(expectedVotingList, calculateVotingList);
        }
        [TestMethod]
        public void CentralizationVotesFromMorePollingPlacesTheSameNumbersOfCandidates()
        {
            string[] listOfCandidates = { "Cretu Ene", "Pop Viorel", "Avram Marin", "Man Ana", "Pintea Radu" };
            GlobalStruct[] list1 = { new GlobalStruct("Cretu Ene", 100), new GlobalStruct("Man Ana", 43), new GlobalStruct("Pop Viorel", 24), new GlobalStruct("Avram Marin", 4) };
            GlobalStruct[] list2 = { new GlobalStruct("Cretu Ene", 154), new GlobalStruct("Man Ana", 87), new GlobalStruct("Pop Viorel", 25), new GlobalStruct("Avram Marin", 14) };
            GlobalStruct[] list3 = { new GlobalStruct("Pop Viorel", 45), new GlobalStruct("Avram Marin", 45), new GlobalStruct("Man Ana", 36), new GlobalStruct("Cretu Ene", 25) };
            GlobalStruct[] list4 = { new GlobalStruct("Cretu Ene", 47), new GlobalStruct("Avram Marin", 46), new GlobalStruct("Man Ana", 22), new GlobalStruct("Pop Viorel", 15) };

            GlobalStruct[][] ReceivedVotingLists = { list1, list2, list3, list4 };

            GlobalStruct[] expectedVotingList = { new GlobalStruct("Cretu Ene", 326), new GlobalStruct("Man Ana", 188), new GlobalStruct("Avram Marin", 109), new GlobalStruct("Pop Viorel", 109), new GlobalStruct("Pintea Radu", 0) };

            GlobalStruct[] calculateVotingList = CentralizeAndSortVotes(listOfCandidates, ReceivedVotingLists);

            CollectionAssert.AreEqual(expectedVotingList, calculateVotingList);
        }
        [TestMethod]
        public void CentralizationVotesFromMorePollingPlacesAllCandidates()
        {
            string[] listOfCandidates = { "Cretu Ene", "Pop Viorel", "Avram Marin", "Man Ana" };
            GlobalStruct[] list1 = { new GlobalStruct("Cretu Ene", 100), new GlobalStruct("Man Ana", 43), new GlobalStruct("Pop Viorel", 24), new GlobalStruct("Avram Marin", 4) };
            GlobalStruct[] list2 = { new GlobalStruct("Cretu Ene", 154), new GlobalStruct("Man Ana", 87), new GlobalStruct("Pop Viorel", 25), new GlobalStruct("Avram Marin", 14) };
            GlobalStruct[] list3 = { new GlobalStruct("Pop Viorel", 45), new GlobalStruct("Avram Marin", 45), new GlobalStruct("Man Ana", 36), new GlobalStruct("Cretu Ene", 25) };
            GlobalStruct[] list4 = { new GlobalStruct("Cretu Ene", 47), new GlobalStruct("Avram Marin", 46), new GlobalStruct("Man Ana", 22), new GlobalStruct("Pop Viorel", 15) };

            GlobalStruct[][] ReceivedVotingLists = { list1, list2, list3, list4 };

            GlobalStruct[] expectedVotingList = { new GlobalStruct("Cretu Ene", 326), new GlobalStruct("Man Ana", 188), new GlobalStruct("Avram Marin", 109), new GlobalStruct("Pop Viorel", 109) };

            GlobalStruct[] calculateVotingList = CentralizeAndSortVotes(listOfCandidates, ReceivedVotingLists);

            CollectionAssert.AreEqual(expectedVotingList, calculateVotingList);
        }
        [TestMethod]
        public void CentralizationVotesFromOnePollingPlace()
        {
            string[] listOfCandidates = { "Pop Viorel", "Popa Vanda", "Avram Marin", "Man Ana", "Pintea Radu" };
            GlobalStruct[] list1 = { new GlobalStruct("Cretu Ene", 100), new GlobalStruct("Man Ana", 43), new GlobalStruct("Pop Viorel", 24), new GlobalStruct("Avram Marin", 4) };

            GlobalStruct[][] ReceivedVotingLists = { list1 };

            GlobalStruct[] expectedVotingList = { new GlobalStruct("Man Ana", 43), new GlobalStruct("Pop Viorel", 24), new GlobalStruct("Avram Marin", 4), new GlobalStruct("Pintea Radu", 0), new GlobalStruct("Popa Vanda", 0) };

            GlobalStruct[] calculateVotingList = CentralizeAndSortVotes(listOfCandidates, ReceivedVotingLists);

            CollectionAssert.AreEqual(expectedVotingList, calculateVotingList);
        }
        [TestMethod]
        public void CentralizationVotesNotReceivedLists()
        {
            string[] listOfCandidates = { "Cretu Ene", "Pop Viorel", "Popa Vanda" };
            GlobalStruct[] list1 = { };

            GlobalStruct[][] ReceivedVotingLists = { list1 };

            GlobalStruct[] expectedVotingList = { new GlobalStruct("Popa Vanda", 0), new GlobalStruct("Pop Viorel", 0), new GlobalStruct("Cretu Ene", 0) };

            GlobalStruct[] calculateVotingList = CentralizeAndSortVotes(listOfCandidates, ReceivedVotingLists);

            CollectionAssert.AreEqual(expectedVotingList, calculateVotingList);
        }

        private static GlobalStruct[] CentralizeAndSortVotes(string[] listOfCandidates, GlobalStruct[][] votingLists)
        {
            GlobalStruct[] centralVotingList = InitializingVotingList(listOfCandidates);
            CentralizingVotingLists(ref centralVotingList, votingLists);
            return centralVotingList;
        }

        private static void CentralizingVotingLists(ref GlobalStruct[] centralVotingList, GlobalStruct[][] listOfVotes)
        {
            for (int i = 0; i < listOfVotes.Length; i++)
            {
                AddListFromOnePollingSection(listOfVotes[i], ref centralVotingList);
                StructQuickSort(ref centralVotingList, 0, centralVotingList.Length - 1);
                ReverseList(ref centralVotingList);
            }
        }

        private static void ReverseList(ref GlobalStruct[] sourceList)
        {
            for (int i = 0; i < sourceList.Length / 2; i++)
            {
                StructSwap(ref sourceList[i], ref sourceList[sourceList.Length - i - 1]);
            }

        }

        private static void StructSwap(ref GlobalStruct firstValue, ref GlobalStruct secondValue)
        {
            var temporary = new GlobalStruct();
            temporary = firstValue;
            firstValue = secondValue;
            secondValue = temporary;
        }

        private static void AddListFromOnePollingSection(GlobalStruct[] listFromVoteSection, ref GlobalStruct[] centralVotingList)
        {
            foreach (GlobalStruct candidate in listFromVoteSection)
            {
                int index = PositionInList(candidate.stringField, centralVotingList);
                if (index >= 0)
                {
                    UpdateNumberOfVotesForOneCandidate(ref centralVotingList, index, candidate.numericField);
                }
            }
        }

        private static void UpdateNumberOfVotesForOneCandidate(ref GlobalStruct[] canditatesPosition, int index, int number)
        {
            canditatesPosition[index].numericField += number;
        }

        private static GlobalStruct[] InitializingVotingList(string[] listOfCandidates)
        {
            GlobalStruct[] temporaryList = new GlobalStruct[listOfCandidates.Length];
            for (int i = 0; i < listOfCandidates.Length; i++)
            {
                temporaryList[i].stringField = listOfCandidates[i];
            }
            return temporaryList;
        }
              
    }
}