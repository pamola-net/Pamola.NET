﻿using System;
using System.Linq;
using Xunit;

namespace Pamola.UT
{
    public class TerminalUT
    {
        [Fact]
        public void ElementMatchesCreator()
        {
            var element = new MockedElement(1);
            Assert.Equal(element, element.Terminals.First().Element); 
        }
    
        [Fact]
        public void DisconnectedIsNull()
        {
            var element = new MockedElement(1);
            Assert.Null(element.Terminals.First().Node);
        }

        [Fact]
        public void ConnectedMatchesNode()
        {
            var element = new MockedElement(2);
            var node = element.Terminals.First().ConnectTo(element.Terminals.Last());

            Assert.NotNull(element.Terminals.First().Node);
            Assert.Equal(node, element.Terminals.First().Node);
        }

        [Fact]
        public void DisconnectedAdjacentComponentsMatchesElement()
        {
            var element = new MockedElement(1);
            IComponent component = element.Terminals.First();
            Assert.Equal(component.AdjacentComponents, new[]{element});
        }

        [Fact]
        public void ConnectedAdjacentComponentsMatchesElementAndNode()
        {
            var element = new MockedElement(2);
            var node = element.Terminals.First().ConnectTo(element.Terminals.Last());

            IComponent component = element.Terminals.First();
            Assert.Equal(component.AdjacentComponents, new[] { (IComponent)element, node });
        }

    }
}
