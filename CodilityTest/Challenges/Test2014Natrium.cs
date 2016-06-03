using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyCodilitySolutions.Challenges;

namespace CodilityTest.Challenges
{
    [TestClass]
    public class Test2014Natrium
    {
        [TestMethod]
        public void TestMethod1()
        {
            var My2014Natrium = new My2014Natrium();
            int[] A = new[] {5, 3, 6, 3, 4, 2};
            int result = My2014Natrium.GetMaxDistanceMonotonic(A);
            Assert.AreEqual(3, result);
        }
    }
}
