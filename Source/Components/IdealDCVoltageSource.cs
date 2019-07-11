using System;
using System.Collections.Generic;
using System.Text;
using System.Numerics;

namespace Pamola.Components
{
    public class IdealDCVoltageSource:
        Dipole
    {
        public double Voltage { get; private set; }

        public IdealDCVoltageSource(double voltage)
        {
            Voltage = voltage;
        }

        private Complex VoltageDrop()
        {
            if (!Positive.IsConnected() || !Negative.IsConnected()) return new Complex();

            var V = Positive.Node.Voltage - Negative.Node.Voltage;

            return V - Voltage;

        }

        protected override IReadOnlyCollection<Variable> Variables => new List<Variable>();

        protected override IReadOnlyCollection<Func<Complex>> DipoleEquations => new List<Func<Complex>>() { VoltageDrop };

    }
}
