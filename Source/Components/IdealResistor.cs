using System;
using System.Collections.Generic;
using System.Text;
using System.Numerics;

namespace Pamola.Components
{
    public class IdealResistor : 
        Dipole
    {
        public double Resistance { get; private set; }

        public IdealResistor(double resistance)
        {
            if (resistance < 0.0)
                throw new ArgumentOutOfRangeException(
                    nameof(resistance),
                    resistance,
                    "Negative resistance values are phisically impossible.");

            Resistance = resistance; 
        }

        private Complex OhmsLaw()
        {
            if (!Positive.IsConnected() || !Negative.IsConnected()) return new Complex();

            var V = Positive.Node.Voltage - Negative.Node.Voltage;
            var I = Positive.Current;
            var R = Resistance;

            return V - R * I;
        }   

        protected override IReadOnlyCollection<Variable> Variables => new List<Variable>();

        protected override IReadOnlyCollection<Func<Complex>> DipoleEquations => new List<Func<Complex>>() { OhmsLaw };
        
        //TODO: Create an Ideal Voltage Source.
    }
}
