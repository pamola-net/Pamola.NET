using System;
using System.Collections.Generic;
using System.Text;

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
        

    }
}
