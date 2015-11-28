using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NenrLab1.FuzzyControl
{
    public interface IDomain
    {
        object[] FromStringRepresentation(string[] values);
        int GetIndexOfElement(object[] values);
        object[] ElementAt(int index);
        int GetCardinality();
        IDomain[] GetDomainComponents();
    }
}
