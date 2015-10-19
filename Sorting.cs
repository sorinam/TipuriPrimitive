using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace TipuriPrimitive
{
    [TestClass]
    public class Sorting
    {
        [TestMethod]
        public void SortingArrayUsingMergeAlghortihm()
        {
            int[] inputArray = { 16, 8, 1, 15, 46, 3 };
            int[] sortedArray = { 1, 3, 8, 15, 16, 46 };
            MergeSort(ref inputArray);
            CollectionAssert.AreEqual(sortedArray, inputArray);
        }

        [TestMethod]
        public void MergeSortedArrays()
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
            if (inputArray.Length <= 2)
            {
                if (inputArray.Length == 1) return;
                if (inputArray[0] > inputArray[1])
                {
                    swap(ref inputArray[0], ref inputArray[1]);
                    return;
                }
            }
            int index = inputArray.Length / 2;
            int[] leftArray = new int[index];
            int[] rightArray = new int[inputArray.Length - index];
            Array.Copy(inputArray, leftArray, index);
            Array.Copy(inputArray, index, rightArray, 0, inputArray.Length - index);
            MergeSort(ref leftArray);
            MergeSort(ref rightArray);
            Merge(leftArray, rightArray, ref inputArray);
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

        private static void swap(ref int first, ref int second)
        {
            var temporary = first;
            first = second;
            second = temporary;
        }
    }
}



