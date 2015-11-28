using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NenrLab1.FuzzyControl
{
    public static class DomainFactory
    {
        public static IDomain CreateDomain(IEnumerable<string> elements)
        {
            return new EnumDomain(elements);
        }

        public static IDomain CreateDomain(IEnumerable<int> elements)
        {
            return new IntDomain(elements);
        }

        public static IDomain CreateDomain(IEnumerable<double> elements)
        {
            return new RealDomain(elements);
        }

        public static IDomain CreateDomain(IEnumerable<IDomain> elements)
        {
            return new CartesianDomain(elements);
        }

        public static IDomain CreateDomain(int from, int to, int step)
        {
            return new IntDomain(from, to, step);
        }

        public static IDomain CreateDomain(double from, double to, double step)
        {
            return new RealDomain(from, to, step);
        }
    }
}
