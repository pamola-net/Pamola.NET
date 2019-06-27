using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using System.Numerics;
using System.Linq;

namespace Pamola.UT
{
    public class DipoleUT
    {

        public static IEnumerable<object[]> ValueData { get; } = new List<object[]>()
        {
            new object[] 
            {
                new Complex(2.0,2.0),
                new Complex(-2.0,2.0), 
                new Complex(0.0,4.0)
            },
            new object[] 
            {
                new Complex(2.0,2.0),
                new Complex(-2.0,-2.0), 
                new Complex(0.0,0.0)
            },
            new object[] {
                new Complex(2.0,2.0),
                new Complex(2.0,2.0),
                new Complex(4.0,4.0)},
            new object[] {
                new Complex(-2.0,-2.0),
                new Complex(-2.0,-2.0),
                new Complex(-4.0,-4.0)
            }
        };

        [Theory]
        [MemberData(nameof(ValueData))]
        public void DipoleCurrentsBehaveProperly(Complex positiveCurrent, Complex negativeCurrent, Complex currentSum)
        {
            var dipole = new MockedDipole();
            
            IComponent positive = dipole.Positive;
            IComponent negative = dipole.Negative;
            positive.Variables.First().Setter(positiveCurrent);
            negative.Variables.First().Setter(negativeCurrent);

            Assert.Equal(currentSum, ((IComponent)dipole).Equations.First()());
        }
    }
}
