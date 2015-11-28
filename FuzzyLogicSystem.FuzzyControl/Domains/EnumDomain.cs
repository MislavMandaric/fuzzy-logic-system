using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NenrLab1.FuzzyControl
{
    public class EnumDomain : IDomain
    {
        private IList<string> elements;

        private IDomain[] domains;

        public EnumDomain(IEnumerable<string> elements)
        {
            this.elements = new List<string>(elements);
            this.domains = new IDomain[] { this };
        }

        public object[] FromStringRepresentation(string[] values)
        {
            return new object[] { values[0] };
        }

        public int GetIndexOfElement(object[] values)
        {
            return this.elements.IndexOf((string)values[0]);
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
