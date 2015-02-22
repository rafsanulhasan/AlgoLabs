using System;

namespace AlgoLabs
{
     public class Start
     {
          static void Main(string[] args)
          {                                                                                         
               TimeSpan runningTime = new TimeSpan();
               Console.WriteLine("Welcome to Algorithms' Lab Solutions");
               int[] array = { 3, 1, 7, 5, 4, 2, 8, 6 }, bubbleSortResult, heapSortResult, insertionSortResult, mergeSortResult, quickSortResult;
               Console.WriteLine("\n{0}\t{1}\t\t{2}\t\t\t{3}", "Algorithm", "Style", "Values", "Running Time");
               array.Print<int, SortAlgorithms>(SortAlgorithms.None, new Nullable<TimeSpan>());

               //array.Sort(out bubbleSortResult, out runningTime, algorithm: SortAlgorithms.Bubble);
               //bubbleSortResult.Print(SortAlgorithms.Bubble, MethodCallStyle.Recursive, runningTime);
               array.Sort(out bubbleSortResult, out runningTime, algorithm: SortAlgorithms.Bubble, callStyle: MethodCallStyle.Iterative);
               bubbleSortResult.Print(SortAlgorithms.Bubble, MethodCallStyle.Iterative, runningTime);

               //array.Sort(out heapSortResult, out runningTime, algorithm: SortAlgorithms.Heap);
               //heapSortResult.Print(SortAlgorithms.Heap, MethodCallStyle.Recursive, runningTime);
               //array.Sort(out heapSortResult, out runningTime, algorithm: SortAlgorithms.Heap, callStyle: MethodCallStyle.Iterative);
               //heapSortResult.Print(SortAlgorithms.Heap, MethodCallStyle.Iterative, runningTime);

               //array.Sort(out insertionSortResult, out runningTime, algorithm: SortAlgorithms.Insertion);
               //insertionSortResult.Print(SortAlgorithms.Insertion, MethodCallStyle.Recursive, runningTime);
               //array.Sort(out insertionSortResult, out runningTime, algorithm: SortAlgorithms.Insertion, callStyle: MethodCallStyle.Iterative);
               //insertionSortResult.Print(SortAlgorithms.Insertion, MethodCallStyle.Iterative, runningTime);

               array.Sort(out mergeSortResult, out runningTime, algorithm: SortAlgorithms.Merge);
               Console.WriteLine();
               mergeSortResult.Print(SortAlgorithms.Merge, MethodCallStyle.Recursive, runningTime);
               array.Sort(out mergeSortResult, out runningTime, algorithm: SortAlgorithms.Merge, callStyle: MethodCallStyle.Iterative);
               mergeSortResult.Print(SortAlgorithms.Merge, MethodCallStyle.Iterative, runningTime);

               array.Sort(out quickSortResult, out runningTime, algorithm: SortAlgorithms.Quick);
               quickSortResult.Print(SortAlgorithms.Quick, MethodCallStyle.Recursive, runningTime);
               array.Sort(out quickSortResult, out runningTime, algorithm: SortAlgorithms.Quick, callStyle: MethodCallStyle.Iterative);
               quickSortResult.Print(SortAlgorithms.Quick, MethodCallStyle.Iterative, runningTime);
               Console.ReadKey();
               
          }
     }
}
