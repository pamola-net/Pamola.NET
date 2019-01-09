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
        /// 
        /// </summary>
        IReadOnlyCollection<IComponent> AdjacentComponents { get; }


    }
}
