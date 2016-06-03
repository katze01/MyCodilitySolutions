using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyCodilitySolutions.Challenges;

namespace CodilityTest.Challenges
{
    [TestClass]
    public class Test2013Nitrogenium
    {
        [TestMethod]
        public void TestMethod1()
        {
            var test = new My2013Nitrogenium();
            int[] A = new[] {2,1,3,2,3};
            int[] B = new[] { 0,1,2,3,1};
            int[] result = test.GetFloodedIsland(A, B);
            Assert.AreEqual(5, result.Length);
            Assert.AreEqual(1, result[0]);
            Assert.AreEqual(2, result[1]);
            Assert.AreEqual(2, result[2]);
            Assert.AreEqual(0, result[3]);
            Assert.AreEqual(2, result[4]);            
        }

        [TestMethod]
        public void TestMethod2()
        {
            var test = new My2013Nitrogenium();
            int[] A = new[] { 1,4,2,5,1,3,2};
            int[] B = new[] { 0, 1, 2, 3, 4,5 };
            int[] result = test.GetFloodedIsland(A, B);
            Assert.AreEqual(6, result.Length);
            Assert.AreEqual(1, result[0]);
            Assert.AreEqual(2, result[1]);
            Assert.AreEqual(3, result[2]);
            Assert.AreEqual(2, result[3]);
            Assert.AreEqual(1, result[4]);
            Assert.AreEqual(0, result[5]);
        }
    }
}
