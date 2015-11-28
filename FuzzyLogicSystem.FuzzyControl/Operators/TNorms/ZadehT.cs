using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NenrLab1.FuzzyControl
{
    public class ZadehT : ITNorm
    {
        public IFuzzySet Calculate(IFuzzySet first, IFuzzySet second)
        {
            if (!first.GetDomain().Equals(second.GetDomain()))
            {
                throw new ApplicationException("Domains are not the same.");
            }
            IList<double> memberships = new List<double>();
            IDomain domain = first.GetDomain();
            for (int i = 0; i < first.GetDomain().GetCardinality(); i++)
            {
                double value1 = first.GetMembershipFor(domain.ElementAt(i));
                double value2 = second.GetMembershipFor(domain.ElementAt(i));
                memberships.Add(Math.Min(value1, value2));
            }
            return FuzzySetFactory.CreateFuzzySet(domain, memberships);
        }
    }
}
