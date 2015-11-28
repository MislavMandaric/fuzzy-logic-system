using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NenrLab1.FuzzyControl
{
    public interface IComposition
    {
        IFuzzySet Calculate(IFuzzySet first, IFuzzySet second);
    }
}
