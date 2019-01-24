using System;
using System.Linq;
using Xunit;

namespace Pamola.UT
{
    public class ElementUT
    {
        /// <summary>
        /// Tests the proper creation of terminals in any <see cref="Pamola.Element"/> inheritor.
        /// </summary>
        /// <param name="numberOfTerminals"></param>
        /// <param name="expectedException"></param>
        [Theory]
        [InlineData(-1,true)]
        [InlineData(0,true)]
        [InlineData(1,false)]
        [InlineData(2, false)]
        [InlineData(100, false)]
        public void TerminalCreation(int numberOfTerminals, bool expectedException)
        {
            if (expectedException) Assert.Throws<ArgumentOutOfRangeException>(() => new MockedElement(numberOfTerminals));
            else new MockedElement(numberOfTerminals);
        }

        /// <summary>
        /// Tests if number of terminails created are equal to the number of terminals in any <see cref="Pamola.Element"/>.
        /// </summary>
        /// <param name="numberOfTerminals"></param>
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(100)]
        public void TerminalsMatchElementContent(int numberOfTerminals)
        {
            var element = new MockedElement(numberOfTerminals);
            Assert.Equal(numberOfTerminals, element.Terminals.Count);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(100)]
        public void AdjacentComponentsMatchTerminals(int numberOfTerminals)
        {
            var element = new MockedElement(numberOfTerminals);
            Assert.Equal(element.AdjacentComponents, element.Terminals);
        }
    }
}
