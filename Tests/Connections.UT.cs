using System;
using System.Linq;
using Xunit;

namespace Pamola.UT
{
    public class ConnectionsUT
    {
        [Fact]
        public void IsConnected()
        {
            MockedElement element = new MockedElement(2);
            Assert.All(element.Terminals, (terminal) => Assert.False(terminal.IsConnected()));

            var terminals = element.Terminals.ToList();
            terminals[0].ConnectTo(terminals[1]);

            Assert.All(element.Terminals, (terminal) => Assert.True(terminal.IsConnected()));
        }

        [Fact]
        public void Disconnection()
        {
            MockedElement element = new MockedElement(2);
            var terminals = element.Terminals.ToList();
            Node node = terminals[0].ConnectTo(terminals[1]);

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
            Node node = terminals[0].ConnectTo(terminals[1]);

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

            Node previousNode = terminals1.First().ConnectTo(terminals2.First());

            Node newNode = terminals1.Last().ConnectTo(terminals2.First());

            Assert.Empty(previousNode.Terminals);

            Assert.False(terminals1.First().IsConnected());

            Assert.Equal(newNode, terminals1.Last().Node);
            Assert.Equal(newNode, terminals2.First().Node);
        }

        /// <summary>
        /// Checks a connection between two nodes.
        /// </summary>
        [Fact]
        public void ConnectN2N()
        {
            MockedElement element1 = new MockedElement(2);
            MockedElement element2 = new MockedElement(2);

            var terminals1 = element1.Terminals.ToList();
            var terminals2 = element2.Terminals.ToList();

            Node node1 = terminals1.First().ConnectTo(terminals1.Last());
            Node node2 = terminals2.First().ConnectTo(terminals2.Last());

            Node node3 = node1.ConnectTo(node2);

            Assert.Equal(node3, node1);

            Assert.Empty(node2.Terminals);

            Assert.Equal(terminals1.Union(terminals2), node1.Terminals);

            Assert.All(node1.Terminals, (terminal) => Assert.True(terminal.IsConnected()));
        }

        /// <summary>
        /// Terminal cannot connect to himself.
        /// </summary>
        [Fact]
        public void ConnectT2Self()
        {
            MockedElement element = new MockedElement(1);

            var terminal = element.Terminals.First();

            Assert.Throws<InvalidOperationException>(() => terminal.ConnectTo(terminal));

        }

        [Fact]
        public void ConnectAllThrowsOnLessThanTwo()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new MockedElement(1).Terminals.ConnectAll());
        }

        [Theory]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        public void ConnectAllWorks(int numberOfTerminals)
        {
            var terminals = new MockedElement(numberOfTerminals).Terminals;
            Assert.Equal(terminals, terminals.ConnectAll().Terminals); 
        }
    }
}
