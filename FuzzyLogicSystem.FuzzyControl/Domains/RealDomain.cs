using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NenrLab1.FuzzyControl
{
    public class RealDomain : IDomain
    {
        private IList<double> elements;

        private IDomain[] domains;

        public RealDomain(IEnumerable<double> elements)
        {
            this.elements = new List<double>(elements);
            this.domains = new IDomain[] { this };
        }

        public RealDomain(double from, double to, double step)
        {
            this.elements = new List<double>();
            for (double i = from; i <= to; i += step)
            {
                this.elements.Add(i);
            }
        }

        public object[] FromStringRepresentation(string[] values)
        {
            return new object[] { double.Parse(values[0]) };
        }

        public int GetIndexOfElement(object[] values)
        {
            return this.elements.IndexOf((double)values[0]);
        }

        public object[] ElementAt(int index)
        {
            return new object[] { this.elements[index] };
        }

        public int GetCardinality()
        {
            return this.elements.Count;
        }

        public IDomain[] GetDomainComponents()
        {
            return this.domains;
        }
    }
}
