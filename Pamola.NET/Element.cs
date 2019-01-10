using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Pamola
{
    /// <summary>
    /// Base class for circuit elements.
    /// </summary>
    public abstract class Element :
        IComponent
    {

        private readonly List<Terminal> terminals = new List<Terminal>();

        /// <summary>
        /// Element constructor.
        /// </summary>
        /// <param name="numberOfTerminals">Number of terminals to be created inside Element.</param>
        protected Element(int numberOfTerminals)
        {
            if (numberOfTerminals<=0)
                throw new ArgumentOutOfRangeException(nameof(numberOfTerminals), numberOfTerminals, "Number of terminals should be a positive non null value.");

            terminals.AddRange(Enumerable.Range(0, numberOfTerminals).Select(_ => new Terminal(this)));
        }



        public IReadOnlyCollection<Terminal> Terminals{ get; }

        public IReadOnlyCollection<IComponent> AdjacentComponents { get; }
    }
}
