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
        IComponent
    {
        /// <summary>
        /// Current operating voltage.
        /// </summary>
        public Complex Voltage { get; private set; }
        
        public IReadOnlyCollection<IComponent> AdjacentComponents => throw new NotImplementedException();
    }
}
