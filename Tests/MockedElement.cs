using System;
using System.Collections.Generic;
using System.Text;

namespace Pamola.UT
{
    /// <summary>
    /// Simple mock for testing <see cref="Element"/> class.
    /// </summary>
    public class MockedElement : 
        Element
    {
        /// <summary>
        /// Create a <see cref="MockedElement"/> with the given amount of terminals.
        /// </summary>
        /// <param name="numberOfTerminals">Number of terminals for testing.</param>
        public MockedElement(int numberOfTerminals) : base(numberOfTerminals) { }

        protected override IReadOnlyCollection<Variable> Variables => throw new NotImplementedException();
    }
}
