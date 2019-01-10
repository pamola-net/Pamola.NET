using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace Pamola
{
    /// <summary>
    /// Class for circuit nodes.
    /// </summary>
    public class Node :
        IComponent
    {
        /// <summary>
        /// Node current Voltage.
        /// </summary>
        public Complex Voltage { get; private set; }
        
        public IReadOnlyCollection<IComponent> AdjacentComponents => throw new NotImplementedException();
    }
}
