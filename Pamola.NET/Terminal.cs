using System;
using System.Collections.Generic;
using System.Text;
using System.Numerics;
using System.Linq;

namespace Pamola
{
    /// <summary>
    /// Represents a terminal or pin of any circuit element.
    /// </summary>
    public class Terminal : IComponent
    { 
        /// <summary>
        /// Current passing through this terminal (positive when entering the element, negative otherwise).
        /// </summary>
        public Complex Current { get; private set; }

        /// <summary>
        /// Terminal owner <see cref="Pamola.Element"/>.
        /// </summary>
        public Element Element { get; private set; }

        /// <summary>
        /// The <see cref="Pamola.Node"/> this termininal is currently connected to (null when disconnected).
        /// </summary>
        public Node Node { get; internal set; }
        // TODO: check if internal set or private set

        /// <summary>
        /// Creates a terminal for a given owner <see cref="Pamola.Element"/>.
        /// </summary>
        /// <param name="ownerElement">Terminal owner Element.</param>
        internal Terminal(Element ownerElement)
        {
            Element = ownerElement;
        }

        /// <summary>
        /// A collection with owner <see cref="Element"/> and current <see cref="Node"/> (when connected).
        /// </summary>
        IReadOnlyCollection<IComponent> IComponent.AdjacentComponents => (new[] { (IComponent)Element, Node }).Where(component => component != null).ToList();
    }
}
