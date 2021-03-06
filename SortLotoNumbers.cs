﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TipuriPrimitive
{
    [TestClass]
    public class SortLotoNumbers
    {

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
        public void SortingArrayUsingMergeSortAlghoritm()
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

    }
}
