using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyCodilitySolutions.Challenges;

namespace CodilityTest.Challenges
{
    [TestClass]
    public class Test2014Oxygenium
    {
        [TestMethod]
        public void TestExample()
        {
            var test = new My2014Oxygenium();
            int K = 2;
            int[] A = new[] {3,5,7,6,3};
            var result = test.GetCountBoundedSlices(K, A);
            Assert.AreEqual(9, result);
        }
    }
}
