using System;
using System.Collections.Generic;
using System.Text;
using System.Numerics;
using System.Linq;

namespace Pamola
{
    public static class Solver
    {
        public static void Solve(this Circuit circuit, ISolver solver)
        {
            var component = (IComponent)circuit;
            var equations = component.Equations;
            var variables = component.Variables;

            // [complex] -> set all variables
            // listA = [1,2,3,4]
            // listB = [10,15,14,18]
            // listC = listA.Zip(listB, (A, B) => B-A)
            // print(listC)
            // [9, 13, 11, 14] 

            solver.Solve(
                equations.Select(equation => new Func<IReadOnlyList<Complex>, Complex>(
                    values =>
                    {
                        variables.Zip(
                            values, 
                            (variable, value) => 
                            { 
                                variable.Setter(value); 
                                return value; 
                            }).ToList();
                        return equation();
                    })).ToList());

            //TODO: Insert a separate method to set all variables in a circuit.
            //TODO: Finish solver class/interface.
            //TODO: Create a ground component.
            //TODO: Create unit tests.

        }
    }
}
