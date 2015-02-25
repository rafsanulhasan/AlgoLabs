using System;

namespace AlgoLabs
{
     public class Start
     {
          static void Main(string[] args)
          {                                                                                         
               TimeSpan runningTime = new TimeSpan();
               Console.WriteLine("Welcome to Algorithms' Lab Solutions");
               int[] array = { 3, 1, 7, 5, 4, 2, 8, 6 };
               Console.WriteLine("\n{0}\t{1}\t\t{2}\t\t\t{3}\n", "Algorithm", "Style", "Values", "Running Time");
               array.Print<int, SortAlgorithms>(SortAlgorithms.None, new Nullable<TimeSpan>());

               Console.Write("\n\n");
               try
               {
                    array.BubbleSort(style: MethodCallStyle.Recursive);
                    array.Print(SortAlgorithms.Bubble, MethodCallStyle.Recursive, runningTime);
                    array = new int[] { 3, 1, 7, 5, 4, 2, 8, 6 };
                    array.BubbleSort();
                    array.Print(SortAlgorithms.Bubble, MethodCallStyle.Iterative, runningTime);
                    array = new int[] { 3, 1, 7, 5, 4, 2, 8, 6 };
                    array.BubbleSort(order: SortOrders.Descending, style: MethodCallStyle.Recursive);
                    array.Print(SortAlgorithms.Bubble, MethodCallStyle.Recursive, runningTime);
                    array = new int[] { 3, 1, 7, 5, 4, 2, 8, 6 };
                    array.BubbleSort(order: SortOrders.Descending);
                    array.Print(SortAlgorithms.Bubble, MethodCallStyle.Iterative, runningTime);

                    //array.Sort(out heapSortResult, out runningTime, algorithm: SortAlgorithms.Heap);
                    //heapSortResult.Print(SortAlgorithms.Heap, MethodCallStyle.Recursive, runningTime);
                    //array.Sort(out heapSortResult, out runningTime, algorithm: SortAlgorithms.Heap, callStyle: MethodCallStyle.Iterative);
                    //heapSortResult.Print(SortAlgorithms.Heap, MethodCallStyle.Iterative, runningTime);

                    //array.Sort(out insertionSortResult, out runningTime, algorithm: SortAlgorithms.Insertion);
                    //insertionSortResult.Print(SortAlgorithms.Insertion, MethodCallStyle.Recursive, runningTime);
                    //array.Sort(out insertionSortResult, out runningTime, algorithm: SortAlgorithms.Insertion, callStyle: MethodCallStyle.Iterative);
                    //insertionSortResult.Print(SortAlgorithms.Insertion, MethodCallStyle.Iterative, runningTime);

                    Console.Write("\n");
                    array = new int[] { 3, 1, 7, 5, 4, 2, 8, 6 };
                    array.MergeSort(style: MethodCallStyle.Recursive);
                    array.Print(SortAlgorithms.Merge, MethodCallStyle.Recursive, runningTime);
                    array = new int[] { 3, 1, 7, 5, 4, 2, 8, 6 };
                    array.MergeSort();
                    array.Print(SortAlgorithms.Merge, MethodCallStyle.Iterative, runningTime);
                    array = new int[] { 3, 1, 7, 5, 4, 2, 8, 6 };
                    array.MergeSort(order: SortOrders.Descending, style: MethodCallStyle.Recursive);
                    array.Print(SortAlgorithms.Merge, MethodCallStyle.Recursive, runningTime);
                    array = new int[] { 3, 1, 7, 5, 4, 2, 8, 6 };
                    array.MergeSort(order: SortOrders.Descending);
                    array.Print(SortAlgorithms.Merge, MethodCallStyle.Iterative, runningTime);

                    Console.Write("\n");
                    array = new int[] { 3, 1, 7, 5, 4, 2, 8, 6 };
                    array.QuickSort(style: MethodCallStyle.Recursive);
                    array.Print(SortAlgorithms.Quick, MethodCallStyle.Recursive, runningTime);
                    array = new int[] { 3, 1, 7, 5, 4, 2, 8, 6 };
                    array.QuickSort();
                    array.Print(SortAlgorithms.Quick, MethodCallStyle.Iterative, runningTime);
                    array = new int[] { 3, 1, 7, 5, 4, 2, 8, 6 };
                    array.QuickSort(order: SortOrders.Descending, style: MethodCallStyle.Recursive);
                    array.Print(SortAlgorithms.Quick, MethodCallStyle.Recursive, runningTime);
                    array = new int[] { 3, 1, 7, 5, 4, 2, 8, 6 };
                    array.QuickSort(order: SortOrders.Descending);
                    array.Print(SortAlgorithms.Quick, MethodCallStyle.Iterative, runningTime);
                    Console.ReadKey();
               }
               catch (NotImplementedException nex)
               {
                    Console.WriteLine(nex.Message);
                    Console.ReadKey();
               }
               catch (Exception ex)
               {

               }
          }
     }
}
