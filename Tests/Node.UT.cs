using System;
using System.Linq;
using Xunit;

namespace Pamola.UT
{
    public class NodeUT
    {
        /// <summary>
        /// Checks if <see cref="Pamola.Node.AdjacentComponents"/> list matches the <see cref="Pamola.Node.Terminals"/> list.
        /// </summary>
        [Fact]
        public void AdjacentComponentsMatchTerminals()
        {
            var element = new MockedElement(2);
            var node = element.Terminals.First().ConnectTo(element.Terminals.Last());

            IComponent component = node;
            Assert.Equal(component.AdjacentComponents, node.Terminals);
        }
    }
}
