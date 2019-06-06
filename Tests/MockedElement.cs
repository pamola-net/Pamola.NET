using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Numerics;

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

        protected override IReadOnlyCollection<Variable> Variables => new List<Variable>();

        protected override IReadOnlyCollection<Func<Complex>> Equations => new List<Func<Complex>>();
    }
}
