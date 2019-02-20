using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Pamola
{
    /// <summary>
    /// Base <see cref="Pamola.Element"/> class for any and all circuit elements.
    /// </summary>
    public abstract class Element :
        Component
    {
        private readonly List<Terminal> terminals = new List<Terminal>();

        /// <summary>
        /// Creates an <see cref="Pamola.Element"/> with the given amount of terminals.
        /// </summary>
        /// <param name="numberOfTerminals">Number of terminals to be created inside Element.</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="numberOfTerminals"/> is less than or equal to 0.</exception>
        protected Element(int numberOfTerminals)
        {
            if (numberOfTerminals<=0)
                throw new ArgumentOutOfRangeException(nameof(numberOfTerminals), numberOfTerminals, "Number of terminals should be a positive non null value.");

            terminals.AddRange(Enumerable.Range(0, numberOfTerminals).Select(_ => new Terminal(this)));
        }

        /// <summary>
        /// Represents the terminals of this <see cref="Pamola.Element"/>.
        /// </summary>
        public IReadOnlyCollection<Terminal> Terminals{ get => terminals; }

        /// <summary>
        /// Returns all <see cref="Pamola.IComponent"/> directly connected to this.
        /// </summary>
        protected override IReadOnlyCollection<IComponent> AdjacentComponents => Terminals;

        protected abstract override IReadOnlyCollection<Variable> Variables { get; }


    }
}
