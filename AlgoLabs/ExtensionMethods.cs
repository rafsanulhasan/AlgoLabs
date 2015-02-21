using System;

namespace AlgoLabs
{
    public static class ExtensionMethods
    {
         public static void Swap(this Int32 Int32Object, ref int mainObject, ref int swappingObject)
         {
              int tmp = mainObject;
              mainObject = swappingObject;
              swappingObject = tmp;
         }

         public static int Floor(this decimal number)
         {
              return Int32.Parse(Math.Floor(number).ToString());
         }

         public static int Floor(this double number)
         {
              return Int32.Parse(Math.Floor(number).ToString());
         }



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

         public static void Reverse(this int[] array)
         {
              int[] reversed = new int[array.Length];
              for (int i = 0; i < array.Length; i++)
                   reversed[i] = array[array.Length - i - 1];
              for (int i = 0; i < array.Length; i++)
                   array[i] = reversed[i];
         }

         public static void Sort(this int[] array, out TimeSpan runningTime, SortAlgorithms algorithm = SortAlgorithms.Automatic, SortOrders sortOrder = SortOrders.Ascending)
         {
              runningTime = new TimeSpan();
              DateTime startTime, endTime;
              int length = array.Length;
              switch (algorithm)             
              {
                   case SortAlgorithms.Heap:
                        break;
                   case SortAlgorithms.Insertion:
                        break;
                   case SortAlgorithms.Merge:
                        startTime = DateTime.Now;
                        int mid = Math.Floor((double)length / 2).Floor();
                        if (length < 2)
                        {
                             endTime = DateTime.Now;
                             runningTime = endTime - startTime;
                             return;
                        }
                        int[] left = new int[Int32.Parse(mid.ToString())], right = new int[length - mid];
                        TimeSpan leftRunningTime, rightRunningTime;
                        for (int i = 0; i < mid; i++)
                             left[i] = array[i];
                        for (int i = mid; i < length; i++)
                             right[i - mid] = array[i];
                        left.Sort(out leftRunningTime, SortAlgorithms.Merge, SortOrders.Ascending);
                        right.Sort(out rightRunningTime, SortAlgorithms.Merge, SortOrders.Ascending);
                        array.Merge(left, right);
                        if (sortOrder == SortOrders.Descending)
                             array.Reverse();
                        endTime = DateTime.Now;
                        runningTime = endTime - startTime + leftRunningTime + rightRunningTime;
                        break;
                   case SortAlgorithms.Quick:
                        break;
                   default:                                                  
                        break;
              }
         }
         public static string ToTimeSpanString( this TimeSpan timeSpan)
         {
              int days = timeSpan.TotalDays > 0 ? Int32.Parse(Math.Floor(timeSpan.TotalDays).ToString()) : 0,
                  hours = timeSpan.TotalHours > 0 ? Int32.Parse(Math.Floor(timeSpan.TotalHours).ToString()) : 0,
                  mins = timeSpan.TotalMinutes > 0 ? Int32.Parse(Math.Floor(timeSpan.TotalMinutes).ToString()) : 0,
                  secs = timeSpan.TotalSeconds > 0 ? Int32.Parse(Math.Floor(timeSpan.TotalHours).ToString()) : 0,
                  ms = timeSpan.TotalMilliseconds > 0 ? Int32.Parse(Math.Floor(timeSpan.TotalMilliseconds).ToString()) : 0;
              return String.Format("{0} d {1} h {2} m {3} s {4:F3} ms", days, hours, mins, secs, timeSpan.TotalMilliseconds);
         }
    }
}
