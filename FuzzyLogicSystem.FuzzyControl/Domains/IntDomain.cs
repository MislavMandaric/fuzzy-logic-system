using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NenrLab1.FuzzyControl
{
    public class IntDomain : IDomain
    {
        private IList<int> elements;

        private IDomain[] domains;

        public IntDomain(IEnumerable<int> elements)
        {
            this.elements = new List<int>(elements);
            this.domains = new IDomain[] { this };
        }

        public IntDomain(int from, int to, int step)
        {
            this.elements = new List<int>();
            for (int i = from; i <= to; i += step)
            {
                this.elements.Add(i);
            }
        }

        public object[] FromStringRepresentation(string[] values)
        {
            return new object[] { int.Parse(values[0]) };
        }

        public int GetIndexOfElement(object[] values)
        {
            return this.elements.IndexOf((int)values[0]);
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
