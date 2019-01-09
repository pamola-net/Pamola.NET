using System;
using System.Collections.Generic;
using System.Text;

namespace Pamola
{
    /// <summary>
    /// Terminal class 
    /// </summary>
    public class Terminal : IComponent
    {
        public IReadOnlyCollection<IComponent> AdjacentComponents => throw new NotImplementedException();

    }
}
