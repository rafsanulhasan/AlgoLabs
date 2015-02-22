using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace AlgoLabs
{
    public static class ExtensionMethods
    {
         /// <summary>
         /// Merges two sorted array and Sorts the merged array
         /// </summary>
         /// <param name="array"></param>
         /// <param name="left"></param>
         /// <param name="right"></param>
         private static void Merge<T>(this T[] array, ref T[] left, ref T[] right, MethodCallStyle callStyle = MethodCallStyle.Recursive) where T:struct
         {
              IComparer comparer = new CaseInsensitiveComparer();
            
              switch (callStyle)
              {
                   case MethodCallStyle.Iterative:

                        break;
                   default:
                        int lCount = left.Length, rCount = right.Length, i = 0, j = 0, k = 0;
                        while (i < lCount && j < rCount)
                        {
                             if (comparer.Compare(left[i] , right[j])<=0)
                                  array[k++] = left[i++];
                             else
                                  array[k++] = right[j++];
                        }
                        while (i < lCount)
                             array[k++] = left[i++];
                        while (j < rCount)
                             array[k++] = right[j++];
                        break;
              }
         }
         private static void Merge<T>(this T[] array, int start, int mid, int end, T[] temp)
         {
              int i = start, j = mid + 1, k = start;
              IComparer comparer = new CaseInsensitiveComparer();
              while ((i <= mid) && (j <= end))
              {
                   if (comparer.Compare(array[i], array[j]) <= 0)
                   {
                        temp[k] = array[i];
                        i++;
                   }
                   else
                   {
                        temp[k] = array[j];
                        j++;
                   }
                   k++;
              }
              while (i <= mid)
              {
                   temp[k] = array[i];
                   i++;
                   k++;
              }
              while (j <= end)
              {
                   temp[k] = array[j];
                   j++;
                   k++;
              }
         }

    
         /// <summary>
         /// // ********************************************************* //
         /// This algorithm is created by Course Faculty
         /// // ********************************************************* //
         /// Creates a partition from the given range
         /// </summary>
         /// <param name="array"></param>
         /// <param name="left"></param>
         /// <param name="right"></param>
         /// <returns></returns>        
         private static void Partition<T>(this T[] array, out int result, MethodCallStyle callStyle = MethodCallStyle.Recursive, int left = Int32.MinValue, int right = Int32.MinValue) where T : struct
         {
              result = Int32.MinValue;
              left = left == Int32.MinValue ? 0 : left;
              right = right == Int32.MinValue ? array.Length - 1 : right; ;
              IComparer comparer = new CaseInsensitiveComparer();
              T pivot;
              switch (callStyle)
              {
                   case MethodCallStyle.Iterative:
                        int k = left - 1;
                        pivot = array[right];
                        for (int i = left; i < right; i++)
                        {
                             if (comparer.Compare(array[i], pivot) <= 0)
                             {
                                  k++;
                                  array[k].Swap(ref array[k], ref array[i]);
                             }
                        }
                        array[k + 1].Swap(ref array[k + 1], ref array[right]);
                        result = k + 1;
                        break;
                   default:
                        pivot = array[left];
                        while (true)
                        {
                             while (comparer.Compare(array[left], pivot) < 0)
                                  left++;

                             while (comparer.Compare(array[right], pivot) > 0)
                                  right--;

                             if (left < right)
                                  left.Swap(ref array[left], ref array[right]);
                             else
                                  result = right;
                        }
                        break;
              }
         }
         /// <summary>
         /// // ********************************************************* //
         /// This algorithm is created by Course Faculty
         /// // ********************************************************* //
         /// Prints the values of array (separated by space)
         /// Also prints the running time (if provided)
         /// </summary>
         /// <typeparam name="Algorithm"></typeparam>
         /// <param name="array"></param>
         /// <param name="algorithm"></param>
         /// <param name="runningTime"></param>
         public static void Print<T, Algorithm>(this T[] array, Algorithm algorithm, TimeSpan? runningTime)   where T:struct
         {
              Console.Write("\n{0}\t\t{1}\t\t", algorithm.ToString(), MethodCallStyle.None.ToString());            
              for (int i = 0; i < array.Length - 1; i++)
                   Console.Write("{0} ", array[i]);
              Console.Write(array[array.Length - 1]);
              if (runningTime.HasValue)
                   Console.WriteLine("\t\t{0}", runningTime.Value.ToTimeSpanString());
         }
         /// <summary>
         /// // ********************************************************* //
         /// This algorithm is created by Course Faculty
         /// // ********************************************************* //
         /// Prints the values of array (separated by space)
         /// Also prints the running time (if provided)
         /// </summary>
         /// <typeparam name="Algorithm"></typeparam>
         /// <param name="array"></param>
         /// <param name="algorithm"></param>
         /// <param name="runningTime"></param>
         public static void Print<T, Algorithm, CallStyle>(this T[] array, Algorithm algorithm, CallStyle callStyle, TimeSpan? runningTime)  where T:struct
         {
              Console.Write("\n{0}\t\t{1}\t", algorithm.ToString(), callStyle.ToString());
              for (int i = 0; i < array.Length - 1; i++)
                   Console.Write("{0} ", array[i]);
              Console.Write(array[array.Length - 1]);
              if (runningTime.HasValue)
                   Console.WriteLine("\t\t{0}", runningTime.Value.ToTimeSpanString());
         }

         /// <summary>
         /// Reverses the array
         /// </summary>
         /// <param name="array"></param>
         public static void Reverse<T>(this T[] array) where T:struct
         {
              T[] reversed = new T[array.Length];
              for (int i = 0; i < array.Length; i++)
                   reversed[i] = array[array.Length - i - 1];
              for (int i = 0; i < array.Length; i++)
                   array[i] = reversed[i];
         }

         public static void Sort<T>(this T[] array, out T[] sortedArray, out TimeSpan runningTime, SortAlgorithms algorithm = SortAlgorithms.Automatic, SortOrders sortOrder = SortOrders.Ascending, MethodCallStyle callStyle=MethodCallStyle.Recursive, int left = Int32.MinValue, int right = Int32.MinValue) where T:struct
         {
              DateTime startTime = DateTime.Now, endTime;
              sortedArray = array;
              runningTime = new TimeSpan(0, 0, 0, 0, 0);
              TimeSpan leftRunningTime = new TimeSpan(0, 0, 0, 0, 0),
                   rightRunningTime = new TimeSpan(0, 0, 0, 0, 0),
                   runningTime2 = new TimeSpan(0, 0, 0, 0, 0);
              int length = array.Length;
              left = left == Int32.MinValue ? 0 : left;
              right = right == Int32.MinValue ? length - 1 : right;
              T[] leftArray, rightArray, temp;
              IComparer comparer = new CaseInsensitiveComparer();
              switch (algorithm)
              {
                   case SortAlgorithms.Heap:
                        break;
                   case SortAlgorithms.Bubble:
                        right = left = 0;
                        if (callStyle == MethodCallStyle.Iterative)
                        {
                             for (int pass = 1; pass <= array.Length - 2; pass++)
                             {
                                  for (int i = 0; i <= array.Length - 2; i++)
                                  {
                                       if (comparer.Compare(array[i], array[i + 1]) > 0)
                                            sortedArray[i].Swap(ref sortedArray[i], ref sortedArray[i + 1]);

                                  }

                             }
                        }
                        else if (callStyle == MethodCallStyle.Recursive)
                        {
                             if (left == length - 1) return;
                             if (right == length - 1)
                                  array.Sort(out sortedArray, out runningTime2, algorithm: SortAlgorithms.Bubble, callStyle: MethodCallStyle.Recursive, left: left + 1, right: left + 1);

                             //compare items at current index and current index + 1 and swap if required
                             int nextIndex = right + 1;
                             if (comparer.Compare(array[right], array[nextIndex]) > 0)
                                  array.Swap(ref array[right], ref array[nextIndex]);
                             array.Sort(out sortedArray, out runningTime2, algorithm: SortAlgorithms.Bubble, callStyle: MethodCallStyle.Recursive, left: left, right: right + 1);
                        }
                        break;
                   case SortAlgorithms.Insertion:
                        break;
                   case SortAlgorithms.Merge:
                        if (length < 2 || left==right)
                        {
                             endTime = DateTime.Now;
                             runningTime = endTime - startTime;
                             return;
                        }
                        int mid = ((double)(length / 2)).ToInt32();
                        if (callStyle == MethodCallStyle.Recursive)
                        {
                             // ****************************************************************************** //
                             // This algorithm is created by course faculty //  
                             leftArray = new T[mid];
                             rightArray = new T[length - mid];
                             for (int i = 0; i < mid; i++)
                                  leftArray[i] = array[i];
                             for (int i = mid; i < length; i++)
                                  rightArray[i - mid] = array[i];
                             leftArray.Sort(out leftArray, out leftRunningTime, algorithm: SortAlgorithms.Merge);
                             rightArray.Sort(out rightArray, out rightRunningTime, algorithm: SortAlgorithms.Merge);
                             sortedArray.Merge(ref leftArray, ref rightArray);
                             // ****************************************************************************** //

                        }
                        else if (callStyle==MethodCallStyle.Iterative)
                        {
                             temp = new T[length];
                             Array.Copy(array, temp, length);
                             for (int runWidth = 1; runWidth < array.Length; runWidth = 2 * runWidth)
                             {
                                  for (int eachRunStart = 0; eachRunStart < array.Length;
                                      eachRunStart = eachRunStart + 2 * runWidth)
                                  {
                                       int start = eachRunStart;
                                        mid = eachRunStart + (runWidth - 1);
                                       if (mid >= array.Length)
                                            mid = array.Length - 1;
                                       int end = eachRunStart + ((2 * runWidth) - 1);
                                       if (end >= array.Length)
                                            end = array.Length - 1;

                                       array.Merge(start, mid, end, temp);
                                  }
                                  for (int i = 0; i < array.Length; i++)
                                       array[i] = temp[i];
                             }
                         }
                        break;
                   case SortAlgorithms.Quick:
                        int pivot;
                        if (callStyle == MethodCallStyle.Iterative)
                        {
                             // Create an auxiliary stack
                             int[] stack = new int[right - left + 1];
                             // initialize top of stack
                             int top = -1;
                             // push initial values of l and h to stack
                             stack[++top] = left;
                             stack[++top] = right;
                             // Keep popping from stack while is not empty
                             while (top >= 0)
                             {
                                  // Pop h and l
                                  right = stack[top--];
                                  left = stack[top--];
                                  // Set pivot element at its correct position in sorted array
                                  array.Partition(out pivot, MethodCallStyle.Iterative, left, right);
                                  // If there are elements on left side of pivot, then push left side to stack
                                  if (pivot - 1 > left)
                                  {
                                       stack[++top] = left;
                                       stack[++top] = pivot - 1;
                                  }
                                  // If there are elements on right side of pivot, then push right side to stack
                                  if (pivot + 1 < right)
                                  {
                                       stack[++top] = pivot + 1;
                                       stack[++top] = right;
                                  }
                             }
                        }
                        else if (callStyle == MethodCallStyle.Iterative)
                        {
                             array.Partition(out pivot, callStyle, left: left, right: right);
                             if (left < right)
                             {
                                  if (pivot > 1)
                                       array.Sort(out sortedArray, out runningTime2, algorithm: SortAlgorithms.Quick, left: left, right: pivot - 1);

                                  if (pivot + 1 < right)
                                       array.Sort(out sortedArray, out runningTime2, algorithm: SortAlgorithms.Quick, left: pivot + 1, right: right);
                             }
                        }

                        break;
                   default:
                        break;
              }
              if (sortOrder == SortOrders.Descending)
                   sortedArray.Reverse();
              endTime = DateTime.Now;
              runningTime = endTime - startTime;
              if (leftRunningTime > new TimeSpan(0, 0, 0, 0, 0) && rightRunningTime > new TimeSpan(0, 0, 0, 0, 0))
                   runningTime += leftRunningTime + rightRunningTime;
              else if (runningTime2 > new TimeSpan(0, 0, 0, 0, 0))
                   runningTime += runningTime2;
         }
         public static void Swap<T>(this object Object, ref T mainObject, ref T swappingObject)
         {
              T tmp = mainObject;
              mainObject = swappingObject;
              swappingObject = tmp;
         }
         public static int ToInt32(this double value)
         {
              return (int)value;
         }
         public static string ToTimeSpanString(this TimeSpan timeSpan)
         {
              return String.Format("{0:N0}d {1:N0}h {2:N0}m {3:N0}s {4:F5}ms", timeSpan.TotalDays, timeSpan.TotalHours, timeSpan.TotalMinutes, timeSpan.TotalSeconds, timeSpan.TotalMilliseconds);
         }
    }
}
