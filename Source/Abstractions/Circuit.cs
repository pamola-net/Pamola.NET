using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Numerics;

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
        
        protected override IReadOnlyCollection<Variable> Variables => Components.SelectMany(component => component.Variables).ToList();

        protected override IReadOnlyCollection<Func<Complex>> Equations => Components.SelectMany(component => component.Equations).ToList();
    }
}
