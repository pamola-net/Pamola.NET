using System;
using System.Collections.Generic;
using System.Text;

namespace Pamola
{
    public static class CircuitFactory
    {
        /// <summary>
        /// Creates a <see cref="Circuit"/> based on <paramref name="component"/>&apos;s recursive connections.
        /// </summary>
        /// <param name="component">The source component.</param>
        /// <returns>A Circuit containg the recursive components.</returns>
        public static Circuit GetCircuit(this IComponent component)
        {
            ISet<IComponent> currentComponents = new HashSet<IComponent>();
            component.InsertInternals(currentComponents);
            return new Circuit(currentComponents);
        }
        
        private static void InsertInternals(this IComponent component, ISet<IComponent> currentComponents)
        {
            if (currentComponents.Add(component))
            {
                foreach(var adjacent in component.AdjacentComponents)
                {
                    adjacent.InsertInternals(currentComponents);
                }
            }
        }

    }
}
