using System;
using System.Collections.Generic;
using System.Text;

namespace Pamola
{
    /// <summary>
    /// Basic Interface for all Pamola components.
    /// </summary>
    public interface IComponent
    {
        /// <summary>
        /// Returns the components adjacent to this component.
        /// </summary>
        IReadOnlyCollection<IComponent> AdjacentComponents { get; }


    }
}
