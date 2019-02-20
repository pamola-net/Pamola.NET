using System;
using System.Linq;
using Xunit;

namespace Pamola.UT
{
    public class ConnectionsUT
    {
        [Fact]
        public void ChecksIsConnected()
        {
            MockedElement element = new MockedElement(2);
            Assert.All(element.Terminals, (terminal) => Assert.False(terminal.IsConnected()));

            var terminals = element.Terminals.ToList();
            terminals[0].ConnectTo(terminals[1]);

            Assert.All(element.Terminals, (terminal) => Assert.True(terminal.IsConnected()));
        }

        [Fact]
        public void ChecksDisconnect()
        {
            MockedElement element = new MockedElement(2);
            var terminals = element.Terminals.ToList();
            var node = terminals[0].ConnectTo(terminals[1]);

            terminals[0].Disconnect();
            Assert.All(element.Terminals, (terminal) => Assert.False(terminal.IsConnected()));

            Assert.Empty(node.Terminals);
        }

        /// <summary>
        /// Checks a connection between two terminals that are currently disconnected.
        /// </summary>
        [Fact]
        public void ConnectT2TFromDisconnected()
        {
            MockedElement element = new MockedElement(2);
            var terminals = element.Terminals.ToList();
            var node = terminals[0].ConnectTo(terminals[1]);

            Assert.All(terminals, terminal => Assert.Equal(node, terminal.Node));
        }

        /// <summary>
        /// Checks a connection between two terminals when any is connected.
        /// </summary>
        [Fact]
        public void ConnectT2TFromConnected()
        {
            MockedElement element1 = new MockedElement(2);
            MockedElement element2 = new MockedElement(1);

            var terminals1 = element1.Terminals.ToList();
            var terminals2 = element2.Terminals.ToList();

            var previousNode = terminals1.First().ConnectTo(terminals2.First());

            var newNode = terminals1.Last().ConnectTo(terminals2.First());

            Assert.Empty(previousNode.Terminals);

            Assert.False(terminals1.First().IsConnected());

            Assert.Equal(newNode, terminals1.Last().Node);
            Assert.Equal(newNode, terminals2.First().Node);
        }
    }
}
