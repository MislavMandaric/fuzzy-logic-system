using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NenrLab1.FuzzyControl;

namespace NenrLab1.Program
{
    public class CenterOfAreaDefuzzyfier : IDefuzzyfier
    {
        public string Defuzzyfie(IFuzzySet set)
        {
            double sumNumerator = 0.0;
            double sumDenominator = 0.0;
            for (int i = 0; i < set.GetDomain().GetCardinality(); i++)
            {
                sumNumerator += (set.GetMembershipFor(set.GetDomain().ElementAt(i)) * (int)set.GetDomain().ElementAt(i)[0]);
                sumDenominator += set.GetMembershipFor(set.GetDomain().ElementAt(i));
            }
            return Convert.ToInt32(sumNumerator / sumDenominator).ToString();
        }
    }
}
