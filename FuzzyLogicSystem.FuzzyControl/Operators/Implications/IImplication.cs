using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NenrLab1.FuzzyControl
{
    public interface IImplication
    {
        IFuzzySet Calculate(IFuzzySet first, IFuzzySet second);
    }
}
