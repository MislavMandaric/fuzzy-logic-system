using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NenrLab1.FuzzyControl
{
    public class CartesianDomain : IDomain
    {
        private IList<object[]> elements;

        private IDomain[] domains;

        public CartesianDomain(IEnumerable<IDomain> domains)
        {
            this.domains = new List<IDomain>(domains).ToArray();
            var elements = domains.Aggregate(
                (IEnumerable<object[]>)new List<object[]> { new object[0] },
                (elementsSoFar, domain) =>
                    from element in elementsSoFar
                    from index in Enumerable.Range(0, domain.GetCardinality())
                    select element.Concat(domain.ElementAt(index)).ToArray()).ToList();
            this.elements = elements;
        }

        public object[] FromStringRepresentation(string[] values)
        {
            object[] element = new object[values.Length];
            for (int index = 0; index < values.Length; index++)
            {
                element[index] = this.Parse(values[index]);
            }
            return element;
        }

        public int GetIndexOfElement(object[] values)
        {
            return this.elements.IndexOf(values);
        }

        public object[] ElementAt(int index)
        {
            return this.elements[index];
        }

        public int GetCardinality()
        {
            return this.elements.Count;
        }

        public IDomain[] GetDomainComponents()
        {
            return this.domains;
        }

        private object Parse(string value)
        {
            int integer;
            double real;
            if (int.TryParse(value, out integer))
            {
                return integer;
            }
            else if (double.TryParse(value, out real))
            {
                return real;
            }
            else return value;
        }
    }
}
