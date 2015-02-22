using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System
{
     public struct PositionInfo
     {
          public int Left { get { return Int32.Parse(Range.Split('-')[0]); } set { Range.Split('-')[0] = value.ToString(); } }
          public int Right { get { return Int32.Parse(Range.Split('-')[1]); } set { Range.Split('-')[1] = value.ToString(); } }
          private string Range;
          public PositionInfo(int[] range)
          {
               if (range.Length != 2)
                    throw new Exception("Conversion failed");
               Range = String.Format("{0}-{1}", range[0], range[1]);
          }
          public PositionInfo(int left, int right)
          {
               Range = String.Format("{0}-{1}", left, right);
          }
          public PositionInfo(string range)
          {
               Range = range;
          }
          public static implicit operator int[](PositionInfo range)
          {
               return new int[] { range.Left, range.Right };
          }
          public static implicit operator PositionInfo(int[] range)
          {
               if (range.Length != 2)
                    throw new Exception("Conversion failed");
               return new PositionInfo(String.Format("{0}-{1}", range[0], range[1]));
          }
          public static bool operator ==(PositionInfo range1, PositionInfo range2)
          {
               return range1.Left == range2.Left && range1.Right == range2.Right ? true : false;
          }
          public static bool operator !=(PositionInfo range1, PositionInfo range2)
          {
               return range1.Left != range2.Left && range1.Right != range2.Right ? true : false;
          }

          public override bool Equals(object obj)
          {
               return base.Equals(obj);
          }
          public override int GetHashCode()
          {
               return base.GetHashCode();
          }
          public override string ToString()
          {
               return base.ToString();
          }
     }
}
