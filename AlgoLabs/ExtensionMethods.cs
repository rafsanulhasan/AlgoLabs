using System;
using System.Runtime.CompilerServices;

namespace AlgoLabs
{
    public static class ExtensionMethods
    {
         /// <summary>
         /// // ********************************************************* //
         /// This algorithm is created by Course Faculty
         /// // ********************************************************* //
         /// Merges two sorted array and Sorts the merged array
         /// </summary>
         /// <param name="array"></param>
         /// <param name="left"></param>
         /// <param name="right"></param>
         private static void Merge(this int[] array, int[] left, int[] right)
         {
              int lCount = left.Length, rCount = right.Length, i = 0, j = 0, k = 0;
              while (i < lCount && j < rCount)
              {
                   if (left[i] < right[j])
                        array[k++] = left[i++];
                   else
                        array[k++] = right[j++];
              }
              while (i < lCount)
                   array[k++] = left[i++];
              while (j < rCount)
                   array[k++] = right[j++];
         }
         /// <summary>
         /// // ********************************************************* //
         /// This algorithm is created by me
         /// // ********************************************************* //
         /// Merges two sorted array and Sorts the merged array
         /// </summary>
         /// <param name="array"></param>
         /// <param name="left"></param>
         /// <param name="right"></param>
         private static void Merge(this int[] array, int left = Int32.MinValue, int right = Int32.MinValue)
         {
              left = left == Int32.MinValue ? 0 : left;
              right = right == Int32.MinValue ? array.Length - 1 : right;
              int length = array.Length,
                   mid = Math.Floor((double)(left + right / 2)).ToInt32() + 1,
                   temp_pos = left;
              int[] temp = new int[length];
              while ((left <= mid - 1) && (mid <= right))
              {
                   if (array[left] <= array[mid])
                        temp[temp_pos++] = array[left++];
                   else
                        temp[temp_pos++] = array[mid++];
              }

              while (left <= mid - 1)
                   temp[temp_pos++] = array[left++];

              while (mid <= right)
                   temp[temp_pos++] = array[mid++];

              for (int i = 0; i < length; i++)
              {
                   array[right] = temp[right];
                   right--;
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

         private static int Partition(this int[] array, int left = Int32.MinValue, int right = Int32.MinValue)
         {
              left = left == Int32.MinValue ? 0 : left;
              right = right == Int32.MinValue ? array.Length - 1 : right; ;
              int pivot = array[left];
              while (true)
              {
                   while (array[left] < pivot)
                        left++;

                   while (array[right] > pivot)
                        right--;

                   if (left < right)
                        left.Swap(ref array[left], ref array[right]);
                   else
                        return right;
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

         public static void Print<Algorithm>(this int[] array, Algorithm algorithm, TimeSpan? runningTime)
         {
              Console.WriteLine();
              Console.Write("{0}\t\t", algorithm.ToString());
              foreach (var item in array)
                   Console.Write("{0} ", item);
              if (runningTime.HasValue)
                   Console.WriteLine("\n\t\tRunning Time: {0}", runningTime.Value.ToTimeSpanString());
         }

         /// <summary>
         /// Reverses the array
         /// </summary>
         /// <param name="array"></param>

         public static void Reverse(this int[] array)
         {
              int[] reversed = new int[array.Length];
              for (int i = 0; i < array.Length; i++)
                   reversed[i] = array[array.Length - i - 1];
              for (int i = 0; i < array.Length; i++)
                   array[i] = reversed[i];
         }

         private static void Sort(this int[] array, SortAlgorithms algorithm = SortAlgorithms.Automatic, SortOrders sortOrder = SortOrders.Ascending, int left = Int32.MinValue, int right = Int32.MinValue)
         {
              int length = array.Length;
              left = left == Int32.MinValue ? 0 : left;
              right = right == Int32.MinValue ? length - 1 : right;
              switch (algorithm)
              {
                   case SortAlgorithms.Heap:
                        break;
                   case SortAlgorithms.Insertion:
                        break;
                   case SortAlgorithms.Merge:
                        if (length < 2) return;
                        int mid = Math.Floor((double)(left + right) / 2).ToInt32();
                        // ****************************************************************************** //
                        // This algorithm is created by course faculty //
                        //int[] l = new int[Int32.Parse(mid.ToString())], r = new int[length - mid];
                        //for (int i = 0; i < mid; i++)
                        //     l[i] = array[i];
                        //for (int i = mid; i < length; i++)
                        //     r[i - mid] = array[i];
                        //l.Sort(SortAlgorithms.Merge, SortOrders.Ascending);
                        //r.Sort(SortAlgorithms.Merge, SortOrders.Ascending); 
                        //array.Merge(l, r);
                        // ****************************************************************************** //
                        // ****************************************************************************** //
                        // This algorithm is created by me //
                        array.Sort(algorithm: SortAlgorithms.Merge, left: left, right: mid);
                        array.Sort(algorithm: SortAlgorithms.Merge, left: mid + 1, right: right);
                        array.Merge(left, right);
                        // ****************************************************************************** //
                        if (sortOrder == SortOrders.Descending)
                             array.Reverse();
                        break;
                   case SortAlgorithms.Quick:
                        if (left < right)
                        {
                             int pivot = array.Partition(left, right);

                             if (pivot > 1)
                                  array.Sort(algorithm: SortAlgorithms.Quick, left: left, right: pivot - 1);

                             if (pivot + 1 < right)
                                  array.Sort(algorithm: SortAlgorithms.Quick, left: pivot + 1, right: right);
                        }
                        break;
                   default:
                        break;
              }
              if (sortOrder == SortOrders.Descending)
                   array.Reverse();
         }
         public static void Sort(this int[] array, out int[] sortedArray, SortAlgorithms algorithm = SortAlgorithms.Automatic, SortOrders sortOrder = SortOrders.Ascending, int left = Int32.MinValue, int right = Int32.MinValue)
         {
              sortedArray = array;
              int length = array.Length;
              left = left == Int32.MinValue ? 0 : left;
              right = right == Int32.MinValue ? length - 1 : right;
              switch (algorithm)
              {
                   case SortAlgorithms.Heap:
                        break;
                   case SortAlgorithms.Insertion:
                        break;
                   case SortAlgorithms.Merge:
                        sortedArray.Sort(algorithm: SortAlgorithms.Merge, left: left, right: right);
                        break;
                   case SortAlgorithms.Quick:
                        sortedArray.Sort(algorithm, sortOrder, left, right);
                        break;
                   default:
                        break;
              }
              if (sortOrder == SortOrders.Descending)
                   sortedArray.Reverse();
         }

         public static void Sort(this int[] array, out TimeSpan runningTime, SortAlgorithms algorithm = SortAlgorithms.Automatic, SortOrders sortOrder = SortOrders.Ascending, int left = Int32.MinValue, int right = Int32.MinValue)
         {
              runningTime = new TimeSpan(0, 0, 0, 0, 0);
              DateTime startTime = DateTime.Now, endTime;
              TimeSpan leftRunningTime = new TimeSpan(0, 0, 0, 0, 0),
                   rightRunningTime = new TimeSpan(0, 0, 0, 0, 0),
                   runningTime2 = new TimeSpan(0, 0, 0, 0, 0);
              int length = array.Length;
              left = left == Int32.MinValue ? 0 : left;
              right = right == Int32.MinValue ? length - 1 : right;
              switch (algorithm)
              {
                   case SortAlgorithms.Heap:
                        break;
                   case SortAlgorithms.Insertion:
                        break;
                   case SortAlgorithms.Merge:
                        startTime = DateTime.Now;
                        int mid = Math.Floor((double)(left + right) / 2).ToInt32();
                        // ****************************************************************************** //
                        // This algorithm is created by course faculty //
                        //if (length < 2)
                        //{
                        //     endTime = DateTime.Now;
                        //     runningTime = endTime - startTime;
                        //     return;
                        //}
                        //int[] leftArray = new int[Int32.Parse(mid.ToString())], rightArray = new int[length - mid];
                        //for (int i = 0; i < mid; i++)
                        //     leftArray[i] = array[i];
                        //for (int i = mid; i < length; i++)
                        //     rightArray[i - mid] = array[i];
                        //leftArray.Sort(out leftRunningTime, SortAlgorithms.Merge, SortOrders.Ascending);
                        //rightArray.Sort(out rightRunningTime, SortAlgorithms.Merge, SortOrders.Ascending);
                        //array.Merge(leftArray, rightArray);
                        // ****************************************************************************** //
                        // ****************************************************************************** //
                        // This algorithm is created by me //
                        array.Sort(out leftRunningTime, algorithm: SortAlgorithms.Merge, left: left, right: mid);
                        array.Sort(out rightRunningTime, algorithm: SortAlgorithms.Merge, left: mid + 1, right: right);
                        array.Merge(left, right);
                        // ****************************************************************************** //
                        break;
                   case SortAlgorithms.Quick:
                        array.Sort(out runningTime2, algorithm: SortAlgorithms.Quick, left: left, right: right);
                        break;
                   default:
                        break;
              }
              if (sortOrder == SortOrders.Descending)
                   array.Reverse();
              endTime = DateTime.Now;
              runningTime = endTime - startTime;
              if (leftRunningTime > new TimeSpan(0, 0, 0, 0, 0) && rightRunningTime > new TimeSpan(0, 0, 0, 0, 0))
                   runningTime += leftRunningTime + rightRunningTime;
              else if (runningTime2 > new TimeSpan(0, 0, 0, 0, 0))
                   runningTime += runningTime2;
         }

         public static void Sort(this int[] array, out int[] sortedArray, out TimeSpan runningTime, SortAlgorithms algorithm = SortAlgorithms.Automatic, SortOrders sortOrder = SortOrders.Ascending, int left = Int32.MinValue, int right = Int32.MinValue)
         {
              DateTime startTime = DateTime.Now, endTime;
              sortedArray = array;
              runningTime = new TimeSpan(0, 0, 0, 0, 0);
              TimeSpan leftRunningTime = new TimeSpan(0, 0, 0, 0, 0),
                   rightRunningTime = new TimeSpan(0, 0, 0, 0, 0),
                   runningTime2 = new TimeSpan(0, 0, 0, 0, 0);
              int length = array.Length;
              int[] leftArray, rightArray;
              switch (algorithm)
              {
                   case SortAlgorithms.Heap:
                        break;
                   case SortAlgorithms.Insertion:
                        break;
                   case SortAlgorithms.Merge:
                        int mid = Math.Floor((double)length / 2).ToInt32();
                        // ****************************************************************************** //
                        // This algorithm is created by course faculty //
                        //if (length < 2)
                        //{
                        //     endTime = DateTime.Now;
                        //     runningTime = endTime - startTime;
                        //     return;
                        //}
                        //leftArray = new int[mid];
                        //rightArray = new int[length - mid];
                        //for (int i = 0; i < mid; i++)
                        //     leftArray[i] = array[i];
                        //for (int i = mid; i < length; i++)
                        //     rightArray[i - mid] = array[i];
                        //leftArray.Sort(out leftArray, out leftRunningTime, SortAlgorithms.Merge, SortOrders.Ascending);
                        //rightArray.Sort(out rightArray, out rightRunningTime, SortAlgorithms.Merge, SortOrders.Ascending);
                        //sortedArray.Merge(leftArray, rightArray);                                           
                        // ****************************************************************************** //
                        // ****************************************************************************** //
                        // This algorithm is created by course faculty //
                        sortedArray.Sort(out leftRunningTime, algorithm: SortAlgorithms.Merge, left: left, right: mid);
                        sortedArray.Sort(out rightRunningTime, algorithm: SortAlgorithms.Merge, left: mid+1, right: right);
                        sortedArray.Merge(left, right);
                        // ****************************************************************************** //
                        break;
                   case SortAlgorithms.Quick:
                        left = left == Int32.MinValue ? 0 : left;
                        right = right == Int32.MinValue ? length - 1 : right;
                        sortedArray.Sort(out runningTime2, algorithm, sortOrder, left, right);
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
         public static void Swap(this object Object, ref int mainObject, ref int swappingObject)
         {
              int tmp = mainObject;
              mainObject = swappingObject;
              swappingObject = tmp;
         }
         public static int ToInt32(this Double value)
         {
              return (int)value;
         }
         public static string ToTimeSpanString( this TimeSpan timeSpan)
         {
              return String.Format("{0:N0}d {1:N0}h {2:N0}m {3:N0}s {4}ms", timeSpan.TotalDays,timeSpan.TotalHours, timeSpan.TotalMinutes, timeSpan.TotalSeconds, timeSpan.TotalMilliseconds);
         }
    }
}
