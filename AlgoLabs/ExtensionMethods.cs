using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoLabs
{
    public static class ExtensionMethods
    {
         public static int[] Sort(this int[] array, SortAlgorithms algorithm = SortAlgorithms.Automatic)
         {
              int[] result = new int[array.Length];
              switch (algorithm)             
              {
                   case SortAlgorithms.Heap:
                        break;
                   case SortAlgorithms.Insertion:
                        break;
                   case SortAlgorithms.Merge: 
                        break;
                   case SortAlgorithms.Quick:
                        break;
                   default:
                        break;
              }
              return result;
         }
    }
}
