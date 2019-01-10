using System;
using System.Collections.Generic;
using System.Text;
using System.Numerics;
using System.Linq;

namespace Pamola
{
    /// <summary>
    /// Terminal class.
    /// </summary>
    public class Terminal : IComponent
    { 
        /// <summary>
        /// Terminal current Current.
        /// </summary>
        public Complex Current { get; private set; }

        /// <summary>
        /// Terminal owner Element.
        /// </summary>
        public Element Element { get; private set; }

        /// <summary>
        /// Terminal current Node.
        /// </summary>
        public Node Node { get; internal set; }
        // TODO: check if internal set or private set

        /// <summary>
        /// Terminal contructor.
        /// </summary>
        /// <param name="ownerElement">Terminal owner Element.</param>
        internal Terminal(Element ownerElement)
        {
            Element = ownerElement;
        }

        /// <summary>
        /// A collection with onwner Element and current Node (when connected).
        /// </summary>
        IReadOnlyCollection<IComponent> IComponent.AdjacentComponents => (new[] { (IComponent)Element, Node }).Where(component => component != null).ToList();
    }
}
