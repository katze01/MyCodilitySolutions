using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyCodilitySolutions.Challenges;

namespace CodilityTest.Challenges
{
    [TestClass]
    public class Test2013Boron
    {
        [TestMethod]
        public void TestExample()
        {
            My2013Boron test = new My2013Boron();
            int[] A = new[] {1, 5, 3, 4, 3, 4, 1, 2, 3, 4, 6, 2};
            int result = test.GetFlag(A);
            Assert.AreEqual(result, 3);
        }

        [TestMethod]
        public void TestExtremeWithoutPeaks()
        {
            My2013Boron test = new My2013Boron();
            int[] A = new[] { 1,2,3,4 };
            int result = test.GetFlag(A);
            Assert.AreEqual(result, 0);
        }

        [TestMethod]
        public void TestOnlyOneElement()
        {
            My2013Boron test = new My2013Boron();
            int[] A = new[] { 1};
            int result = test.GetFlag(A);
            Assert.AreEqual(result, 0);
        }
    }
}
