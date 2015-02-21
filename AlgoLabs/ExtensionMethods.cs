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
              string result = String.Empty;
              if (timeSpan.TotalDays < 0)
              {
                   if (timeSpan.TotalHours < 0)
                   {
                        if (timeSpan.TotalMinutes < 0)
                        {
                             if (timeSpan.TotalSeconds<0)
                                  result = String.Format("{0:X} ms", timeSpan.TotalMilliseconds);
                             else
                             {
                                  result = String.Format("{0} s", timeSpan.TotalSeconds);
                                  if (timeSpan.TotalMilliseconds > 0)
                                       result += String.Format(" and {0} ms", timeSpan.TotalMilliseconds);
                             }
                        }
                        else
                        {
                             result = String.Format("{0} m", timeSpan.TotalMinutes);
                             if (timeSpan.TotalSeconds > 0)
                                  result += timeSpan.TotalMilliseconds > 0 ? String.Format(" {0} s and {1} ms", timeSpan.TotalSeconds, timeSpan.TotalMilliseconds) : String.Format(" and {0} s", timeSpan.TotalSeconds);
                        }
                   }
                   else
                   {
                        result = String.Format("{0} h", timeSpan.TotalHours);
                        if (timeSpan.TotalMinutes < 0)
                        {
                             if (timeSpan.TotalSeconds < 0 && timeSpan.TotalMilliseconds > 0)
                                  result += String.Format(" and {0} ms", timeSpan.TotalMilliseconds);
                             else
                             {
                                  result += String.Format(" {0} s", timeSpan.TotalSeconds);
                                  result += timeSpan.TotalMilliseconds > 0 ? String.Format(" and {0} ms", timeSpan.TotalMilliseconds) : String.Empty;
                             }
                        }
                        else
                        {
                             result += String.Format(" {0} m", timeSpan.TotalMinutes);
                             if (timeSpan.TotalSeconds > 0)
                                  result += timeSpan.TotalMilliseconds > 0 ? String.Format(" {0} s and {1} ms", timeSpan.TotalSeconds, timeSpan.TotalMilliseconds) : String.Format(" and {0} s", timeSpan.TotalSeconds);
                        }
                   }
              }
              return result;
         }
    }
}
