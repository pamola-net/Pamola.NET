using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Pamola
{
    public class Circuit : Element
    {
        public IReadOnlyCollection<IComponent> Components { get; private set; }

        internal Circuit(IEnumerable<IComponent> components) : 
            base(components.
                OfType<Terminal>().
                Where((terminal) => !terminal.IsConnected()))
        {
            Components = components.ToList();
        }

        protected override IReadOnlyCollection<Variable> Variables => throw new NotImplementedException();

    }
}
