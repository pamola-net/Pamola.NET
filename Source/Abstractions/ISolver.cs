using System;
using System.Collections.Generic;
using System.Text;
using System.Numerics;

namespace Pamola
{
    public interface ISolver
    {
        IReadOnlyList<Complex> Solve(IReadOnlyList<Func<IReadOnlyList<Complex>, Complex>> equations);
    }
}
