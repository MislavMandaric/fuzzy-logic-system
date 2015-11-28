using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NenrLab1.FuzzyControl;

namespace NenrLab1.Program
{
    public abstract class BaseInferenceSystem
    {
        protected IFuzzyfier fuzzyfier;
        protected IDefuzzyfier defuzzyfier;
        protected ISNorm sNorm;
        protected ITNorm tNorm;
        protected IComplement not;
        protected IImplication implication;
        protected IComposition composition;
        protected IList<Tuple<IList<IFuzzySet>, IFuzzySet>> angleRules;
        protected IList<Tuple<IList<IFuzzySet>, IFuzzySet>> accelerationRules;

        public BaseInferenceSystem(IFuzzyfier fuzzyfier, IDefuzzyfier defuzzyfier)
        {
            this.fuzzyfier = fuzzyfier;
            this.defuzzyfier = defuzzyfier;
        }

        public string Calculate(string input)
        {
            string[] inList = input.Split(' ');

            IDomain domainPosition = DomainFactory.CreateDomain(-1950, 1950, 1);
            IDomain domainSpeed = DomainFactory.CreateDomain(0, 40, 1);
            IDomain domainAngle = DomainFactory.CreateDomain(-90, 90, 1);
            IDomain domainAcceleration = DomainFactory.CreateDomain(-10, 10, 1);

            int position = (-1 * int.Parse(inList[1])) + int.Parse(inList[0]) + (-1 * int.Parse(inList[3])) / 2 + int.Parse(inList[2]) / 2;
            int speed = int.Parse(inList[4]);
            //IFuzzySet position = fuzzyfier.Fuzzyfie(new string[] { pos.ToString() }, domainPosition);
            //IFuzzySet speed = fuzzyfier.Fuzzyfie(new string[] { inList[4] }, domainSpeed);

            IFuzzySet zoPosition = FuzzySetFactory.Lambda(domainPosition, -10, 0, 10);
            IFuzzySet psPosition = FuzzySetFactory.Lambda(domainPosition, 0, 20, 40);
            IFuzzySet pmPosition = FuzzySetFactory.Lambda(domainPosition, 20, 80, 140);
            IFuzzySet pbPosition = FuzzySetFactory.Lambda(domainPosition, 80, 200, 320);
            IFuzzySet phPosition = FuzzySetFactory.Gamma(domainPosition, 200, 680);
            IFuzzySet nsPosition = FuzzySetFactory.Lambda(domainPosition, -40, -20, 0);
            IFuzzySet nmPosition = FuzzySetFactory.Lambda(domainPosition, -140, -80, -20);
            IFuzzySet nbPosition = FuzzySetFactory.Lambda(domainPosition, -320, -200, -80);
            IFuzzySet nhPosition = FuzzySetFactory.L(domainPosition, -680, -200);

            IFuzzySet sSpeed = FuzzySetFactory.L(domainSpeed, 0, 20);
            IFuzzySet mSpeed = FuzzySetFactory.Lambda(domainSpeed, 0, 20, 40);
            IFuzzySet bSpeed = FuzzySetFactory.Gamma(domainSpeed, 20, 40);

            IFuzzySet zoAngle = FuzzySetFactory.Lambda(domainAngle, -5, 0, 5);
            IFuzzySet psAngle = FuzzySetFactory.Lambda(domainAngle, 0, 10, 20);
            IFuzzySet pmAngle = FuzzySetFactory.Lambda(domainAngle, 10, 30, 50);
            IFuzzySet pbAngle = FuzzySetFactory.Gamma(domainAngle, 30, 70);
            IFuzzySet nsAngle = FuzzySetFactory.Lambda(domainAngle, -20, -10, 0);
            IFuzzySet nmAngle = FuzzySetFactory.Lambda(domainAngle, -50, -30, -10);
            IFuzzySet nbAngle = FuzzySetFactory.L(domainAngle, -70, -30);

            IFuzzySet zoAcceleration = FuzzySetFactory.Lambda(domainAcceleration, -2, 0, 2);
            IFuzzySet psAcceleration = FuzzySetFactory.Lambda(domainAcceleration, 0, 4, 8);
            IFuzzySet pbAcceleration = FuzzySetFactory.Gamma(domainAcceleration, 4, 10);
            IFuzzySet nsAcceleration = FuzzySetFactory.Lambda(domainAcceleration, -8, -4, 0);
            IFuzzySet nbAcceleration = FuzzySetFactory.L(domainAcceleration, -10, -4);

            angleRules = new List<Tuple<IList<IFuzzySet>, IFuzzySet>>()
            {
                new Tuple<IList<IFuzzySet>, IFuzzySet>
                (
                    new List<IFuzzySet>(){nhPosition},nmAngle
                ),
                new Tuple<IList<IFuzzySet>, IFuzzySet>
                (
                    new List<IFuzzySet>(){nbPosition},nsAngle
                ),
                new Tuple<IList<IFuzzySet>, IFuzzySet>
                (
                    new List<IFuzzySet>(){nmPosition},nsAngle
                ),
                new Tuple<IList<IFuzzySet>, IFuzzySet>
                (
                    new List<IFuzzySet>(){nsPosition},nsAngle
                ),
                new Tuple<IList<IFuzzySet>, IFuzzySet>
                (
                    new List<IFuzzySet>(){zoPosition},zoAngle
                ),
                new Tuple<IList<IFuzzySet>, IFuzzySet>
                (
                    new List<IFuzzySet>(){psPosition},psAngle
                ),
                new Tuple<IList<IFuzzySet>, IFuzzySet>
                (
                    new List<IFuzzySet>(){pmPosition},psAngle
                ),
                new Tuple<IList<IFuzzySet>, IFuzzySet>
                (
                    new List<IFuzzySet>(){pbPosition},psAngle
                ),
                new Tuple<IList<IFuzzySet>, IFuzzySet>
                (
                    new List<IFuzzySet>(){phPosition},pmAngle
                )
            };

            accelerationRules = new List<Tuple<IList<IFuzzySet>, IFuzzySet>>()
            {
                new Tuple<IList<IFuzzySet>, IFuzzySet>
                (
                    new List<IFuzzySet>(){mSpeed},zoAcceleration
                ),
                //new Tuple<IList<BaseFuzzySet>, BaseFuzzySet>
                //(
                //    new List<BaseFuzzySet>(){bSpeed},nsAcceleration
                //),
                //new Tuple<IList<BaseFuzzySet>, BaseFuzzySet>
                //(
                //    new List<BaseFuzzySet>(){mSpeed,nhPosition},nsAcceleration
                //),
                //new Tuple<IList<BaseFuzzySet>, BaseFuzzySet>
                //(
                //    new List<BaseFuzzySet>(){mSpeed,nbPosition},nsAcceleration
                //),
                //new Tuple<IList<BaseFuzzySet>, BaseFuzzySet>
                //(
                //    new List<BaseFuzzySet>(){mSpeed,nmPosition},zoAcceleration
                //),
                //new Tuple<IList<BaseFuzzySet>, BaseFuzzySet>
                //(
                //    new List<BaseFuzzySet>(){mSpeed,nsPosition},zoAcceleration
                //),
                //new Tuple<IList<BaseFuzzySet>, BaseFuzzySet>
                //(
                //    new List<BaseFuzzySet>(){mSpeed,zoPosition},zoAcceleration
                //),
                //new Tuple<IList<BaseFuzzySet>, BaseFuzzySet>
                //(
                //    new List<BaseFuzzySet>(){mSpeed,psPosition},zoAcceleration
                //),
                //new Tuple<IList<BaseFuzzySet>, BaseFuzzySet>
                //(
                //    new List<BaseFuzzySet>(){mSpeed,pmPosition},zoAcceleration
                //),
                //new Tuple<IList<BaseFuzzySet>, BaseFuzzySet>
                //(
                //    new List<BaseFuzzySet>(){mSpeed,pbPosition},nsAcceleration
                //),
                //new Tuple<IList<BaseFuzzySet>, BaseFuzzySet>
                //(
                //    new List<BaseFuzzySet>(){mSpeed,phPosition},nsAcceleration
                //),
                //new Tuple<IList<BaseFuzzySet>, BaseFuzzySet>
                //(
                //    new List<BaseFuzzySet>(){sSpeed,nhPosition},psAcceleration
                //),
                //new Tuple<IList<BaseFuzzySet>, BaseFuzzySet>
                //(
                //    new List<BaseFuzzySet>(){sSpeed,nbPosition},psAcceleration
                //),
                //new Tuple<IList<BaseFuzzySet>, BaseFuzzySet>
                //(
                //    new List<BaseFuzzySet>(){sSpeed,nmPosition},psAcceleration
                //),
                //new Tuple<IList<BaseFuzzySet>, BaseFuzzySet>
                //(
                //    new List<BaseFuzzySet>(){sSpeed,nsPosition},pbAcceleration
                //),
                //new Tuple<IList<BaseFuzzySet>, BaseFuzzySet>
                //(
                //    new List<BaseFuzzySet>(){sSpeed,zoPosition},pbAcceleration
                //),
                //new Tuple<IList<BaseFuzzySet>, BaseFuzzySet>
                //(
                //    new List<BaseFuzzySet>(){sSpeed,psPosition},pbAcceleration
                //),
                //new Tuple<IList<BaseFuzzySet>, BaseFuzzySet>
                //(
                //    new List<BaseFuzzySet>(){sSpeed,pmPosition},psAcceleration
                //),
                //new Tuple<IList<BaseFuzzySet>, BaseFuzzySet>
                //(
                //    new List<BaseFuzzySet>(){sSpeed,pbPosition},psAcceleration
                //),
                //new Tuple<IList<BaseFuzzySet>, BaseFuzzySet>
                //(
                //    new List<BaseFuzzySet>(){sSpeed,phPosition},psAcceleration
                //)
            };

            IFuzzySet angle = this.GetAngle(new string[] { position.ToString() }, new string[] { speed.ToString() });
            IFuzzySet acceleration = this.GetAcceleration(new string[] { speed.ToString() }, new string[] { position.ToString() });
            string angleValue = this.defuzzyfier.Defuzzyfie(angle);
            string accelerationValue = this.defuzzyfier.Defuzzyfie(acceleration);
            return accelerationValue + ' ' + angleValue;
        }

        protected abstract IFuzzySet GetAngle(params string[][] variables);

        protected abstract IFuzzySet GetAcceleration(params string[][] variables);
    }
}
