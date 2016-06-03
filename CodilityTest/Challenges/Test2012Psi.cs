using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyCodilitySolutions.Challenges;

namespace CodilityTest.Challenges
{
    [TestClass]
    public class Test2012Psi
    {
        [TestMethod]
        public void TestExample()
        {
            My2012Psi test = new My2012Psi();
            int N = 4;
            int[] A = new[] {0,1,1,2,3,2,1,0,0};
            int[] B = new[] { 0, 1, 1, 1,2,2,3,1,0};
            int[] C = new[] { 0,1,0,0,0,1,1,0,1};
            var result = test.GetWireBurnouts(N, A, B,C);
            Assert.AreEqual(8, result);
        }

        [TestMethod]
        public void TestReturnFalse()
        {
            My2012Psi test = new My2012Psi();
            int N = 4;
            int[] A = new[] { 0 };
            int[] B = new[] { 0 };
            int[] C = new[] { 0 };
            var result = test.GetWireBurnouts(N, A, B, C);
            Assert.AreEqual(-1, result);
        }
    }
}
