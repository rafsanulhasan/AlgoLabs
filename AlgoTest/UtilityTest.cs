using AlgoLabs;
using Microsoft.VisualStudio.TestTools.UnitTesting;using System;                    
using System.Collections.Generic;

namespace AlgoTest
{
     [TestClass]
     public class UtilityTest
     {
          [TestMethod]
          public void TestSwapArrayOfObject()
          {
               Random random = new Random();
               object[] objList1 = new object[random.Next(100)],
                            objList2 = new object[random.Next(100)],
                            expectedObjList1 = new object[objList1.Length],
                            expectedObjList2 = new object[objList2.Length];
               for (int i = 0; i < objList1.Length; i++)
                    objList1[i] = (DateTime.Now);
               for (int i = 0; i < objList2.Length; i++)
                    objList2[i] = (DateTime.Now);
               expectedObjList1 = objList1;
               expectedObjList2 = objList2;
               objList1.Swap(ref objList1, ref objList2);
               var tmpObjList = expectedObjList1;
               expectedObjList1 = expectedObjList2;
               expectedObjList2 = tmpObjList;
               Assert.AreEqual(objList1, expectedObjList1);
               Assert.AreEqual(objList2, expectedObjList2);
          }

          [TestMethod]
          public void TestSwapInteger()
          {
               Random random = new Random();
               int n1 = random.Next(Int32.MinValue, Int32.MaxValue),
                     n2 = random.Next(Int32.MinValue, Int32.MaxValue);
               var expectedO1 = new Object();
               var expectedO2 = new Object();
               expectedO1 = n1;
               expectedO2 = n2;
               n1.Swap(ref n1, ref n2);
               var tmp = expectedO1;
               expectedO1 = expectedO2;
               expectedO2 = tmp;
               Assert.AreEqual(expectedO1, n1);
               Assert.AreEqual(expectedO2, n2);
          }
          [TestMethod]
          public void TestSwapListOfObject()
          {
               Random random = new Random();
               List<object> objList1 = new List<object>(random.Next(100)),
                            objList2 = new List<object>(random.Next(100)),
                            expectedObjList1 = new List<object>(),
                            expectedObjList2 = new List<object>();
               objList1.Add(DateTime.Now);
               objList1.Add(DateTime.Now);
               objList1.Add(DateTime.Now);
               objList1.Add(DateTime.Now);
               objList1.Add(DateTime.Now);
               objList2.Add(DateTime.Now);
               objList2.Add(DateTime.Now);
               objList2.Add(DateTime.Now);
               objList2.Add(DateTime.Now);
               objList2.Add(DateTime.Now);
               expectedObjList1 = objList1;
               expectedObjList2 = objList2;
               objList1.Swap(ref objList1, ref objList2);
               var tmpObjList = expectedObjList1;
               expectedObjList1 = expectedObjList2;
               expectedObjList2 = tmpObjList;
               Assert.AreEqual(objList1, expectedObjList1);
               Assert.AreEqual(objList2, expectedObjList2);
          }

          [TestMethod]
          public void TestSwapString()
          {
               Random random = new Random();
               var expectedO1 = new Object();
               var expectedO2 = new Object();

               string s1 = DateTime.Now.ToLongDateString(),
                    s2 = DateTime.Now.ToLongDateString();
               expectedO1 = s1;
               expectedO2 = s2;
               var tmp = expectedO1;
               expectedO1 = expectedO2;
               expectedO2 = tmp;
               s1.Swap(ref s1, ref s2);
               Assert.AreEqual(expectedO1, s1);
               Assert.AreEqual(expectedO2, s2);
          }
     }
}
