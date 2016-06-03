using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyCodilitySolutions.Challenges;

namespace CodilityTest.Challenges
{
    [TestClass]
    public class Test2013Omega
    {
        [TestMethod]
        public void TestExample()
        {
            My2013Omega test = new My2013Omega();
            int[] A = new[] {5,6,4,3,6,2,3};
            int[] B = new[] {2,3,5,2,4};
            int result = test.GetFallingDisks(A, B);
            Assert.AreEqual(4, result);
        }
    }
}
