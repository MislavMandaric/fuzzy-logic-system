using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NenrLab1.FuzzyControl;

namespace NenrLab1.Program
{
    public class MamdaniSystem : BaseInferenceSystem
    {
        public MamdaniSystem(IFuzzyfier fuzzyfier, IDefuzzyfier defuzzyfier)
            : base(fuzzyfier, defuzzyfier)
        {
            this.sNorm = new ZadehS();
            this.tNorm = new ZadehT();
            this.not = new ZadehNot();
            this.implication = new Mamdani();
            this.composition = new MaxMin();
        }

        protected override IFuzzySet GetAngle(params string[][] variables)
        {
            IList<IFuzzySet> sets = new List<IFuzzySet>();
            IFuzzySet set;
            foreach (var rule in angleRules)
            {
                IList<double> values = new List<double>();
                for (int i = 0; i < rule.Item1.Count; i++)
                {
                    IFuzzySet variable = rule.Item1[i];
                    double value = variable.GetMembershipFor(variable.GetDomain().FromStringRepresentation(variables[i]));
                    values.Add(value);
                }
                double min = values.Min();
                set = FuzzySetFactory.CreateFuzzySet(rule.Item2.GetDomain(), Enumerable.Repeat(min, rule.Item2.GetDomain().GetCardinality()));
                sets.Add(set.TNorm(rule.Item2, tNorm));
            }
            set = sets.Aggregate((current, next) => current.SNorm(next, sNorm));
            return set;
        }

        protected override IFuzzySet GetAcceleration(params string[][] variables)
        {
            IList<IFuzzySet> sets = new List<IFuzzySet>();
            IFuzzySet set;
            foreach (var rule in accelerationRules)
            {
                IList<double> values = new List<double>();
                for (int i = 0; i < rule.Item1.Count; i++)
                {
                    IFuzzySet variable = rule.Item1[i];
                    double value = variable.GetMembershipFor(variable.GetDomain().FromStringRepresentation(variables[i]));
                    values.Add(value);
                }
                double min = values.Min();
                set = FuzzySetFactory.CreateFuzzySet(rule.Item2.GetDomain(), Enumerable.Repeat(min, rule.Item2.GetDomain().GetCardinality()));
                sets.Add(set.TNorm(rule.Item2, tNorm));
            }
            set = FuzzySetFactory.CreateFuzzySet(accelerationRules[0].Item2.GetDomain(), Enumerable.Repeat(0.0, accelerationRules[0].Item2.GetDomain().GetCardinality()));
            return sets.Aggregate((current, next) => current.SNorm(next, sNorm));
        }
    }
}
