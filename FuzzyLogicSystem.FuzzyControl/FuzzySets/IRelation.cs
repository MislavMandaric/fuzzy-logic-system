using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NenrLab1.FuzzyControl
{
    public interface IRelation
    {
        bool TestSymmetric();
        bool TestReflexive();
        bool TestTransitive(IComposition composition);
        bool TestEquivalence(IComposition composition);
        IFuzzySet Project(IDomain domain);
        IFuzzySet CylindricalExtension(IDomain domain);
        IFuzzySet Composition(IFuzzySet other, IComposition composition);
    }
}
