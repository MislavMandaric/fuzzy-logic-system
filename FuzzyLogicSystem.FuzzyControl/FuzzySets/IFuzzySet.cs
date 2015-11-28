using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NenrLab1.FuzzyControl
{
    public interface IFuzzySet : IRelation
    {
        IDomain GetDomain();
        double GetMembershipFor(object[] value);
        IFuzzySet SNorm(IFuzzySet other, ISNorm sNorm);
        IFuzzySet TNorm(IFuzzySet other, ITNorm tNorm);
        IFuzzySet Not(IComplement complement);
        IFuzzySet Implication(IFuzzySet other, IImplication implication);
    }
}
