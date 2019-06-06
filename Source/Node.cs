using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using System.Linq;

namespace Pamola
{
    /// <summary>
    /// Represents the connection between two or more terminals.
    /// </summary>
    public sealed class Node :
        Component
    {
        /// <summary>
        /// Current operating voltage.
        /// </summary>
        public Complex Voltage { get; private set; }

        internal List<Terminal> terminals = new List<Terminal>();

        internal Node(){}

        /// <summary>
        /// Get all terminals connected to this node.
        /// </summary>
        public IReadOnlyCollection<Terminal> Terminals { get => terminals; }

        protected override IReadOnlyCollection<IComponent> AdjacentComponents { get => Terminals; }

        protected override IReadOnlyCollection<Variable> Variables { get => new[] { new Variable(() => Voltage, value => Voltage = value) }; }

        protected override IReadOnlyCollection<Func<Complex>> Equations => new List<Func<Complex>>() { CurrentSum };

        internal Complex CurrentSum()
        {
            return Terminals.Select(t => t.Current).Aggregate((l, r) => l + r);
        }
    }
}
