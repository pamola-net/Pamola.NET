using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace Pamola
{
    /// <summary>
    /// Represents the connection between two or more terminals.
    /// </summary>
    public class Node :
        Component
    {
        /// <summary>
        /// Current operating voltage.
        /// </summary>
        public Complex Voltage { get; private set; }

        //TODO: Check if private or internal
        internal List<Terminal> terminals = new List<Terminal>();

        public IReadOnlyCollection<Terminal> Terminals { get => terminals; }

        protected override IReadOnlyCollection<IComponent> AdjacentComponents { get => Terminals; }
        protected override IReadOnlyCollection<Variable> Variables { get => new[] { new Variable(() => Voltage, value => Voltage = value) }; }
    }
}
