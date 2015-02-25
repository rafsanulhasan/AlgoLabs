using AlgoLabs;
using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest
{
     [TestClass]
     public class UnitTest1
     {
          private List<int> GenerateRandomList()
          {
               Random r = new Random();
               List<int> arr = new List<int>(r.Next(100000));
               for (int i = 0; i < arr.Count; i++)
                    arr[i] = r.Next(Int32.MaxValue);
               return arr;
          }

          private void Process(ref List<int> expected,
               ref int[] actual,
               SortAlgorithms algorithm,
               MethodCallStyle style = MethodCallStyle.Iterative,
               bool isAscending = true)
          {
               actual = expected.ToArray();
               expected.Sort();
               if (isAscending)
                    expected.Reverse();
               SortOrders order = isAscending ? SortOrders.Ascending : SortOrders.Descending;
               if (algorithm == SortAlgorithms.Bubble)
                    actual.BubbleSort(order: order, style: style);
               if (algorithm == SortAlgorithms.Merge)
                    actual.MergeSort(order: order, style: style);
               if (algorithm == SortAlgorithms.Quick)
                    actual.QuickSort(order: order, style: style);
          }
          [TestMethod]
          public void TestBubbleSort()
          {
               List<int> list = GenerateRandomList();
               int[] array = new int[list.Count];
               Process(ref list, ref array, SortAlgorithms.Bubble);
               for (int i = 0; i < list.Count; i++)
                    Assert.AreEqual(list[i], array[i]);

               list = GenerateRandomList();
               array = new int[list.Count];
               Process(ref list, ref array, SortAlgorithms.Bubble, isAscending: false);
               for (int i = 0; i < list.Count; i++)
                    Assert.AreEqual(list[i], array[i]);

               list = GenerateRandomList();
               array = new int[list.Count];
               Process(ref list, ref array, SortAlgorithms.Bubble, MethodCallStyle.Recursive);
               for (int i = 0; i < list.Count; i++)
                    Assert.AreEqual(list[i], array[i]);

               list = GenerateRandomList();
               array = new int[list.Count];
               Process(ref list, ref array, SortAlgorithms.Bubble, MethodCallStyle.Recursive, false);
               for (int i = 0; i < list.Count; i++)
                    Assert.AreEqual(list[i], array[i]);
          }
          [TestMethod]
          public void TestMergeSort()
          {
               List<int> list = GenerateRandomList();
               int[] array = new int[list.Count];
               Process(ref list, ref array, SortAlgorithms.Merge);
               for (int i = 0; i < list.Count; i++)
                    Assert.AreEqual(list[i], array[i]);

               list = GenerateRandomList();
               array = new int[list.Count];
               Process(ref list, ref array, SortAlgorithms.Merge, isAscending: false);
               for (int i = 0; i < list.Count; i++)
                    Assert.AreEqual(list[i], array[i]);

               list = GenerateRandomList();
               array = new int[list.Count];
               Process(ref list, ref array, SortAlgorithms.Merge, MethodCallStyle.Recursive, true);
               for (int i = 0; i < list.Count; i++)
                    Assert.AreEqual(list[i], array[i]);

               list = GenerateRandomList();
               array = new int[list.Count];
               Process(ref list, ref array, SortAlgorithms.Merge, MethodCallStyle.Recursive, false);
               for (int i = 0; i < list.Count; i++)
                    Assert.AreEqual(list[i], array[i]);
          }
          [TestMethod]
          public void TestQuickSort()
          {
               List<int> list = GenerateRandomList();
               int[] array = new int[list.Count];
               Process(ref list, ref array, SortAlgorithms.Quick);
               for (int i = 0; i < list.Count; i++)
                    Assert.AreEqual(list[i], array[i]);

               list = GenerateRandomList();
               array = new int[list.Count];
               Process(ref list, ref array, SortAlgorithms.Quick, isAscending: false);
               for (int i = 0; i < list.Count; i++)
                    Assert.AreEqual(list[i], array[i]);

               list = GenerateRandomList();
               array = new int[list.Count];
               Process(ref list, ref array, SortAlgorithms.Quick, MethodCallStyle.Recursive);
               for (int i = 0; i < list.Count; i++)
                    Assert.AreEqual(list[i], array[i]);

               list = GenerateRandomList();
               array = new int[list.Count];
               Process(ref list, ref array, SortAlgorithms.Quick, MethodCallStyle.Recursive, false);
               for (int i = 0; i < list.Count; i++)
                    Assert.AreEqual(list[i], array[i]);
          }                
     }
}
