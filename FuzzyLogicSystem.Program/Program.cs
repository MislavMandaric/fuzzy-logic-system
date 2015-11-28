using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NenrLab1.FuzzyControl;

namespace NenrLab1.Program
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IFuzzyfier fuzzyfier = new SingletonFuzzyfier();
            IDefuzzyfier defuzzyfier = new CenterOfAreaDefuzzyfier();
            BaseInferenceSystem system = new LarsenSystem(fuzzyfier, defuzzyfier);
            while (true)
            {
                string inLine = Console.ReadLine();
                if (inLine == "KRAJ")
                {
                    break;
                }
                string outLine = system.Calculate(inLine);
                Console.WriteLine(outLine);
                Console.Out.Flush();
            }
        }
    }
}
