using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace Pamola
{
    /// <summary>
    /// Represents a variable in a circuit.
    /// </summary>
    public sealed class Variable
    {
        /// <summary>
        /// Generates a <see cref="Variable"/> with the given getter and setter.
        /// </summary>
        /// <param name="getter">A method that returns the variable value.</param>
        /// <param name="setter">A method that updates the variable value.</param>
        public Variable(Func<Complex> getter, Action<Complex> setter)
        {
            Getter = getter;
            Setter = setter;
        }

        /// <summary>
        /// A method that returns the current value of a <see cref="Pamola.Variable"/>.
        /// </summary>
        public Func<Complex> Getter { get; private set; }

        /// <summary>
        /// A method that allows updating the value of a <see cref="Pamola.Variable"/>.
        /// </summary>
        public Action<Complex> Setter { get; private set; }
    }
}
