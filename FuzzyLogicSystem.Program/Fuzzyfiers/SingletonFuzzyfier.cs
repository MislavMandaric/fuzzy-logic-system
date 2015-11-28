using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NenrLab1.FuzzyControl;

namespace NenrLab1.Program
{
    public class SingletonFuzzyfier : IFuzzyfier
    {
        public IFuzzySet Fuzzyfie(string[] value, IDomain domain)
        {
            IList<double> memberships = new List<double>(new double[domain.GetCardinality()]);
            memberships[domain.GetIndexOfElement(domain.FromStringRepresentation(value))] = 1;
            return FuzzySetFactory.CreateFuzzySet(domain, memberships);
        }
    }
}
