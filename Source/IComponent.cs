using System;
using System.Collections.Generic;
using System.Text;
using System.Numerics;


namespace Pamola
{
    /// <summary>
    /// Basic Interface for all Pamola circuit components.
    /// </summary>
    public interface IComponent
    {
        /// <summary>
        /// Returns the components adjacent to this.
        /// </summary>
        IReadOnlyCollection<IComponent> AdjacentComponents { get; }

        /// <summary>
        /// A collection of appropriate variables relative to the nature of this component.
        /// </summary>
        IReadOnlyCollection<Variable> Variables { get; }

        /// <summary>
        /// A collection of appropriate equations relative to the nature of this component.
        /// </summary>
        IReadOnlyCollection<Func<Complex>> Equations { get; }

    }
}
