using System;
using System.Collections.Generic;
using System.Text;
using System.Numerics;

namespace Pamola
{
    public class IdealResistor : 
        Dipole
    {
        public double Resistance { get; private set; }

        public IdealResistor(double resistance)
        {
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

        //TODO: Unit tests for IdealResistor.
        //TODO: Create a Ideal Voltage Source.
    }
}
