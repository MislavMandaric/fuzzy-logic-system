using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NenrLab1.FuzzyControl
{
    public class ZadehNot : IComplement
    {
        public IFuzzySet Calculate(IFuzzySet set)
        {
            IList<double> memberships = new List<double>();
            for (int i = 0; i < set.GetDomain().GetCardinality(); i++)
            {
                double value = set.GetMembershipFor(set.GetDomain().ElementAt(i));
                memberships.Add(1 - value);
            }
            return FuzzySetFactory.CreateFuzzySet(set.GetDomain(), memberships);
        }
    }
}
