using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NenrLab1.FuzzyControl;

namespace NenrLab1.Program
{
    public interface IFuzzyfier
    {
        IFuzzySet Fuzzyfie(string[] value, IDomain domain);
    }
}
