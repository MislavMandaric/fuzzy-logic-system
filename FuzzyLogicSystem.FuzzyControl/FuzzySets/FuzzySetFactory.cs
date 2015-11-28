using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NenrLab1.FuzzyControl
{
    public static class FuzzySetFactory
    {
        public static IFuzzySet CreateFuzzySet(IDomain domain, IDictionary<string[], double> memberships)
        {
            return new FuzzySet(domain, memberships);
        }

        public static IFuzzySet CreateFuzzySet(IDomain domain, IEnumerable<double> memberships)
        {
            return new FuzzySet(domain, memberships);
        }

        public static IFuzzySet Gamma(IDomain domain, params int[] points)
        {
            double[] memberships = new double[domain.GetCardinality()];
            for (int index = 0; index < domain.GetCardinality(); index++)
            {
                int value = (int)domain.ElementAt(index)[0];
                if (value <= points[0])
                {
                    memberships[index] = 0;
                }
                else if (value >= points[1])
                {
                    memberships[index] = 1;
                }
                else
                {
                    memberships[index] = (double)(value - points[0]) / (points[1] - points[0]);
                }
            }
            return FuzzySetFactory.CreateFuzzySet(domain, memberships);
        }

        public static IFuzzySet Gamma(IDomain domain, params double[] points)
        {
            double[] memberships = new double[domain.GetCardinality()];
            for (int index = 0; index < domain.GetCardinality(); index++)
            {
                double value = (double)domain.ElementAt(index)[0];
                if (value <= points[0])
                {
                    memberships[index] = 0;
                }
                else if (value >= points[1])
                {
                    memberships[index] = 1;
                }
                else
                {
                    memberships[index] = (value - points[0]) / (points[1] - points[0]);
                }
            }
            return FuzzySetFactory.CreateFuzzySet(domain, memberships);
        }

        public static IFuzzySet L(IDomain domain, params int[] points)
        {
            double[] memberships = new double[domain.GetCardinality()];
            for (int index = 0; index < domain.GetCardinality(); index++)
            {
                int value = (int)domain.ElementAt(index)[0];
                if (value <= points[0])
                {
                    memberships[index] = 1;
                }
                else if (value >= points[1])
                {
                    memberships[index] = 0;
                }
                else
                {
                    memberships[index] = (double)(points[1] - value) / (points[1] - points[0]);
                }
            }
            return FuzzySetFactory.CreateFuzzySet(domain, memberships);
        }

        public static IFuzzySet L(IDomain domain, params double[] points)
        {
            double[] memberships = new double[domain.GetCardinality()];
            for (int index = 0; index < domain.GetCardinality(); index++)
            {
                double value = (double)domain.ElementAt(index)[0];
                if (value <= points[0])
                {
                    memberships[index] = 1;
                }
                else if (value >= points[1])
                {
                    memberships[index] = 0;
                }
                else
                {
                    memberships[index] = (points[1] - value) / (points[1] - points[0]);
                }
            }
            return FuzzySetFactory.CreateFuzzySet(domain, memberships);
        }
        public static IFuzzySet Lambda(IDomain domain, params int[] points)
        {
            double[] memberships = new double[domain.GetCardinality()];
            for (int index = 0; index < domain.GetCardinality(); index++)
            {
                int value = (int)domain.ElementAt(index)[0];
                if (value <= points[0])
                {
                    memberships[index] = 0;
                }
                else if (value >= points[2])
                {
                    memberships[index] = 0;
                }
                else if (value > points[0] && value < points[1])
                {
                    memberships[index] = (double)(value - points[0]) / (points[1] - points[0]);
                }
                else
                {
                    memberships[index] = (double)(points[2] - value) / (points[2] - points[1]);
                }
            }
            return FuzzySetFactory.CreateFuzzySet(domain, memberships);
        }

        public static IFuzzySet Lambda(IDomain domain, params double[] points)
        {
            double[] memberships = new double[domain.GetCardinality()];
            for (int index = 0; index < domain.GetCardinality(); index++)
            {
                double value = (double)domain.ElementAt(index)[0];
                if (value <= points[0])
                {
                    memberships[index] = 0;
                }
                else if (value >= points[2])
                {
                    memberships[index] = 0;
                }
                else if (value > points[0] && value < points[1])
                {
                    memberships[index] = (value - points[0]) / (points[1] - points[0]);
                }
                else
                {
                    memberships[index] = (points[2] - value) / (points[2] - points[1]);
                }
            }
            return FuzzySetFactory.CreateFuzzySet(domain, memberships);
        }
    }
}
