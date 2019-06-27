using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Numerics;

namespace Pamola.Components
{
    /// <summary>
    /// Implements an abstract <see cref="Pamola.Components.Dipole"/> circuit element.
    /// </summary>
    public abstract class Dipole : 
        Element
    {
        public Dipole() : base(2)
        { }

        public Terminal Positive { get => Terminals.First(); }

        public Terminal Negative { get => Terminals.Last(); }

        private Complex CurrentBehaviour() => Positive.Current + Negative.Current;

        protected override IReadOnlyCollection<Func<Complex>> Equations
        {
            get => DipoleEquations.Concat(new List<Func<Complex>>(){ CurrentBehaviour }).ToList();
        }

        protected abstract IReadOnlyCollection<Func<Complex>> DipoleEquations { get; }

    }
}
