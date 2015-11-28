using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NenrLab1.FuzzyControl
{
    public class Mamdani : IImplication
    {
        public IFuzzySet Calculate(IFuzzySet first, IFuzzySet second)
        {
            IList<double> memberships = new List<double>();
            IDomain domain = DomainFactory.CreateDomain(new IDomain[] { first.GetDomain(), second.GetDomain() });
            IFuzzySet firstCyl = first.CylindricalExtension(domain);
            IFuzzySet secondCyl = second.CylindricalExtension(domain);
            for (int i = 0; i < domain.GetCardinality(); i++)
            {
                double value1 = firstCyl.GetMembershipFor(domain.ElementAt(i));
                double value2 = secondCyl.GetMembershipFor(domain.ElementAt(i));
                memberships.Add(Math.Min(value1, value2));
            }
            return FuzzySetFactory.CreateFuzzySet(domain, memberships);
        }
    }
}
