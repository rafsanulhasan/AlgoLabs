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

         public static void BubbleSort<T>(this T[] array, 
              int start=-1, int end=-1, 
              SortOrders order= SortOrders.Ascending, 
              MethodCallStyle style = MethodCallStyle.Iterative) where T:struct
         {
              IComparer comparer = new CaseInsensitiveComparer();       
              int length = array.Length;
              start= start == -1 ? 0 : start;
              end = end == -1 ? length - 1 : end;
              if (style == MethodCallStyle.Iterative)
              {
                   for (int pass = 1; pass < end; pass++)
                   {
                        for (int i = 0; i < end; i++)
                        {
                             if (order == SortOrders.Ascending)
                             {
                                  if (comparer.Compare(array[i], array[i + 1]) > 0)
                                       array[i].Swap(ref array[i], ref array[i + 1]);
                             }
                             else if (order == SortOrders.Descending)
                             {
                                  if (comparer.Compare(array[i], array[i + 1]) < 0)
                                       array[i].Swap(ref array[i + 1], ref array[i]);
                             }
                        }

                   }
              }
              else if (style == MethodCallStyle.Recursive)
              {
                   if (start >= end) return;
                   if (order == SortOrders.Ascending)
                   {
                        if (comparer.Compare(array[start], array[start + 1]) > 0)
                             array[start].Swap(ref array[start], ref array[start + 1]);
                   }
                   else if (order == SortOrders.Descending)
                   {
                        if (comparer.Compare(array[start], array[start + 1]) < 0)
                             array[start].Swap(ref array[start + 1], ref array[start]);
                   }
                   array.BubbleSort(start + 1, end, order, style);
                   array.BubbleSort(start, end - 1, order, style);
              }
         }

         public static void MergeSort<T>(this T[] array, 
              int left = -1, 
              int right = -1, 
              SortOrders order = SortOrders.Ascending,
              MethodCallStyle style = MethodCallStyle.Iterative) where T : struct
         {
              int length = array.Length;
              left = left == -1 ? 0 : left;
              right = right == -1 ? length - 1 : right;
              IComparer comparer = new CaseInsensitiveComparer();
              int mid = ((double)(length / 2)).ToInt32();
              T[] temp;
              if (style == MethodCallStyle.Iterative)
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
              else if (style == MethodCallStyle.Recursive)
              {
                   // ****************************************************************************** //
                   // This algorithm is created by course faculty // 
                   if (length < 2 || left == right) return;
                   T[] leftArray, rightArray;
                   leftArray = new T[mid];
                   rightArray = new T[length - mid];
                   for (int i = 0; i < mid; i++)
                        leftArray[i] = array[i];
                   for (int i = mid; i < length; i++)
                        rightArray[i - mid] = array[i];
                   leftArray.MergeSort();
                   rightArray.MergeSort();
                   array.Merge(ref leftArray, ref rightArray, style);
                   // ****************************************************************************** //

              }
              if (order == SortOrders.Descending)
                   array.Reverse();
         }

         public static void QuickSort<T>(this T[] array, 
              int left = -1, 
              int right = -1, 
              SortOrders order = SortOrders.Ascending, 
              MethodCallStyle style = MethodCallStyle.Iterative) where T : struct
         {
              int length = array.Length, pivot;
              left = left == -1 ? 0 : left;
              right = right == -1 ? length - 1 : right;
              IComparer comparer = new CaseInsensitiveComparer(); 
              if (style == MethodCallStyle.Iterative)
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
              else if (style == MethodCallStyle.Recursive)
              {
                   array.Partition(out pivot, style, left: left, right: right);
                   if (left < right)
                   {
                        if (pivot > 1)
                             array.QuickSort(left, pivot - 1);

                        if (pivot + 1 < right)
                             array.QuickSort(pivot + 1, right);
                   }
              }
              if (order == SortOrders.Descending)
                   array.Reverse();
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
