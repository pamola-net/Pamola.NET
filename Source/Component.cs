using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pamola
{
    /// <summary>
    /// Proxies <see cref="IComponent"/> Interface and hides its members.
    /// </summary>
    public abstract class Component
        : IComponent
    {
        /// <summary>
        /// Returns the components adjacent to this.
        /// </summary>
        protected virtual IReadOnlyCollection<IComponent> AdjacentComponents { get; } = Enumerable.Empty<IComponent>().ToArray();

        /// <summary>
        /// A collection of appropriate variables relative to the nature of this component.
        /// </summary>
        protected virtual IReadOnlyCollection<Variable> Variables { get; } = Enumerable.Empty<Variable>().ToArray();

        IReadOnlyCollection<IComponent> IComponent.AdjacentComponents => AdjacentComponents;
        
        IReadOnlyCollection<Variable> IComponent.Variables => Variables;

    }
}
