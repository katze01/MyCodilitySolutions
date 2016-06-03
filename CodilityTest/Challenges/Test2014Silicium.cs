using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyCodilitySolutions.Challenges;

namespace CodilityTest.Challenges
{
    [TestClass]
    public class Test2014Silicium
    {
        [TestMethod]
        public void TestExample()
        {
            My2014Silicium test = new My2014Silicium();
            int X = 6;
            int Y = 7;
            int K = 3;
            int[] A = new[] {1, 3};
            int[] B = new[] {1, 5};
            var result = test.GetCuttingTheCake(X, Y, K, A, B);
            Assert.AreEqual(6 , result);
        }
    }
}
