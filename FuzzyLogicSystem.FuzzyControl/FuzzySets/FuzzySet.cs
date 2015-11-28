using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NenrLab1.FuzzyControl
{
    public class FuzzySet : IFuzzySet
    {
        private IDomain domain;

        private IList<double> memberships;

        public FuzzySet(IDomain domain, IEnumerable<double> memberships)
        {
            this.domain = domain;
            this.memberships = new List<double>(memberships);
        }

        public FuzzySet(IDomain domain, IDictionary<string[], double> memberships)
        {
            this.domain = domain;
            this.memberships = new List<double>(new double[domain.GetCardinality()]);
            foreach (var membership in memberships)
            {
                this.memberships[domain.GetIndexOfElement(domain.FromStringRepresentation(membership.Key))] = membership.Value;
            }
        }

        public IDomain GetDomain()
        {
            return domain;
        }

        public double GetMembershipFor(object[] value)
        {
            int index = this.domain.GetIndexOfElement(value);
            return this.memberships[index];
        }

        public IFuzzySet SNorm(IFuzzySet other, ISNorm sNorm)
        {
            return sNorm.Calculate(this, other);
        }

        public IFuzzySet TNorm(IFuzzySet other, ITNorm tNorm)
        {
            return tNorm.Calculate(this, other);
        }

        public IFuzzySet Not(IComplement complement)
        {
            return complement.Calculate(this);
        }

        public IFuzzySet Implication(IFuzzySet other, IImplication implication)
        {
            return implication.Calculate(this, other);
        }

        public bool TestSymmetric()
        {
            throw new NotImplementedException();
        }

        public bool TestReflexive()
        {
            throw new NotImplementedException();
        }

        public bool TestTransitive(IComposition composition)
        {
            throw new NotImplementedException();
        }

        public bool TestEquivalence(IComposition composition)
        {
            throw new NotImplementedException();
        }

        public IFuzzySet Project(IDomain domain)
        {
            throw new NotImplementedException();
        }

        public IFuzzySet CylindricalExtension(IDomain domain)
        {
            int other = this.domain.GetDomainComponents().Contains(domain.GetDomainComponents()[0]) ? domain.GetDomainComponents().Count() - 1 : 0;
            IList<double> memberships = new List<double>();
            for (int i = 0; i < domain.GetCardinality(); i++)
            {
                IList<object> element = domain.ElementAt(i).ToList();
                element.RemoveAt(other);
                memberships.Add(this.GetMembershipFor(element.ToArray()));
            }
            return new FuzzySet(domain, memberships);
        }

        public IFuzzySet Composition(IFuzzySet other, IComposition composition)
        {
            return composition.Calculate(this, other);
        }
    }
}
