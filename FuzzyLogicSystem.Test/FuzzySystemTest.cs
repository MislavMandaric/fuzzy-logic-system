using System;
using NenrLab1.FuzzyControl;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NenrLab1.Test
{
    [TestClass]
    public class FuzzySystemTest
    {
        [TestMethod]
        public void GivenMultipleDomains_TestOutputSet()
        {
            IDomain d1 = DomainFactory.CreateDomain(new int[] { 1, 2, 3 });
            IDomain d2 = DomainFactory.CreateDomain(new string[] { "a", "b" });
            IDomain d3 = DomainFactory.CreateDomain(new IDomain[] { d1, d2 });
            IFuzzySet f1 = FuzzySetFactory.CreateFuzzySet(d1, new double[] { 1, 0.5, 0 });
            IFuzzySet f2 = f1.CylindricalExtension(d3);
        }
    }
}
