using System;
using System.Collections.Generic;
using System.Text;
using System.Numerics;
using System.Linq;

namespace Pamola.UT
{
    public class MockedSolver : ISolver
    {
        public IReadOnlyList<Complex> SolvedState { get; set; }

        public IReadOnlyList<Complex> Solve(IReadOnlyList<Func<IReadOnlyList<Complex>, Complex>> equations)
        {
            return SolvedState;
        }
    }
}
