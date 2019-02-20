using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Pamola
{
    public static class Connections
    {
        /// <summary>
        /// Checks if <paramref name="terminal"/> is connected to any node.
        /// </summary>
        /// <param name="terminal">Analysed terminal.</param>
        /// <returns>Returns <c>true</c> if connected to any node. Otherwise, <c>false</c>.</returns>
        public static bool IsConnected(this Terminal terminal) => 
            terminal.ThrowOnNull(nameof(terminal)).Node != null;

        /// <summary>
        /// Unbinds <paramref name="terminal"/> from its node. Do nothing if already unbinded.
        /// </summary>
        /// <param name="terminal">Analysed terminal.</param>
        public static void Disconnect(this Terminal terminal)
        {
            Node node = terminal.ThrowOnNull(nameof(terminal)).Node;

            node?.terminals.Remove(terminal);

            terminal.Node = null;

            if (node?.Terminals.Count == 1) node.Terminals.First().Disconnect();
        }

        /// <summary>
        /// Unbinds <paramref name="terminal"/> from current <see cref="Node"/> and binds it to <paramref name="node"/>.
        /// </summary>
        /// <param name="terminal">Analysed terminal.</param>
        /// <param name="node">Target node.</param>
        /// <returns>Target node.</returns>
        public static Node ConnectTo(this Terminal terminal, Node node)
        {
            terminal.Disconnect();
            
            terminal.Node = node.ThrowOnNull(nameof(node));

            node.terminals.Add(terminal);

            return node;
        }

        /// <summary>
        /// Unbinds <paramref name="terminal"/> from current <see cref="Node"/> and binds it to <paramref name="node"/>.
        /// </summary>
        /// <param name="node">Target node.</param>
        /// <param name="terminal">Analysed terminal.</param>
        /// <returns>Target node.</returns>
        public static Node ConnectTo(this Node node, Terminal terminal) => 
            terminal.ConnectTo(node);

        /// <summary>
        /// Binds two <see cref="Terminal"/> objets to the same node.
        /// </summary>
        /// <param name="source">Source terminal.</param>
        /// <param name="target">Target terminal.</param>
        /// <returns>A new node connected to both terminals.</returns>
        public static Node ConnectTo(this Terminal source, Terminal target) =>
            source.ConnectTo(new Node()).ConnectTo(target);

        /// <summary>
        /// Binds all terminals from both nodes in <paramref name="source"/>.
        /// </summary>
        /// <param name="source">Source node.</param>
        /// <param name="target">Target node.</param>
        /// <returns>Source node.</returns>
        public static Node ConnectTo(this Node source, Node target)
        {
            target.Terminals.ToList().ForEach(terminal => terminal.ConnectTo(source));
            return source;
        }
    }
}
