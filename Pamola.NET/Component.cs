using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pamola
{
    /// <summary>
    /// Basic Class for all Pamola circuit components.
    /// </summary>
    public abstract class Component
        : IComponent
    {
        protected virtual IReadOnlyCollection<IComponent> AdjacentComponents { get; } = Enumerable.Empty<IComponent>().ToArray();

        protected virtual IReadOnlyCollection<Variable> Variables { get; } = Enumerable.Empty<Variable>().ToArray();

        IReadOnlyCollection<IComponent> IComponent.AdjacentComponents => AdjacentComponents;

        IReadOnlyCollection<Variable> IComponent.Variables => Variables;

    }
}
