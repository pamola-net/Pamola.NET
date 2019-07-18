using System;
using System.Linq;
using System.Numerics;
using System.Collections.Generic;
using Xunit;
using Pamola.Components;

namespace Pamola.UT
{
    public class IdealResistorUT
    {

        public static IEnumerable<object[]> ValueData { get; } = new List<object[]>()
        {
            new object[]
            {
                new Complex(12.0,0.0),
                new Complex(0.0,0.0),
                new Complex(0.0, 0.0),
                3.0,
                new Complex(12.0,0.0)
            },

            new object[]
            {
                new Complex(-12.0,0.0),
                new Complex(-24.0,0.0),
                new Complex(4.0, 0.0),
                3.0,
                new Complex(0.0,0.0)
            },

            new object[]
            {
                new Complex(0.0,0.0),
                new Complex(0.0,-3.0),
                new Complex(-3.0, 0.0),
                1.0,
                new Complex(3.0,3.0)
            }

        };

        [Theory]
        [InlineData(0.0)]
        [InlineData(3.2)]
        public void ResistanceYieldsValue(double resistance)
        {
            var R = new IdealResistor(resistance);

            Assert.Equal(resistance, R.Resistance);
        }
        
        [Theory]
        [InlineData(0.0, false)]
        [InlineData(3.1, false)]
        [InlineData(-2.5, true)]
        public void IdealResistorCreation(double resistance, bool expectedException)
        {
            if (expectedException)
                Assert.Throws<ArgumentOutOfRangeException>(() => new IdealResistor(resistance));
            else new IdealResistor(resistance);
        }

        [Fact]
        public void FollowsOhmsLawsDisconnected()
        {
            var R1 = new IdealResistor(1.0);
            var R2 = new IdealResistor(1.0);
            var R3 = new IdealResistor(1.0);

            var equations1 = ((IComponent) R1).Equations;
            var equations2 = ((IComponent) R2).Equations;
            var equations3 = ((IComponent) R3).Equations;

            R2.Positive.ConnectTo(R3.Negative);

            Assert.Equal(default(Complex), equations1.First()());
            Assert.Equal(default(Complex), equations2.First()());
            Assert.Equal(default(Complex), equations3.First()());
        }

        [Theory]
        [MemberData(nameof(ValueData))]
        public void FollowsOhmsLawsConnected(
            Complex voltageNode1, 
            Complex voltageNode2, 
            Complex current, 
            double resistance, 
            Complex expectedValue)
        {

            var R = new IdealResistor(resistance);
            var dipole = new MockedDipole();

            var equation = ((IComponent)R).Equations.First();

            IComponent node1 = R.Positive.ConnectTo(dipole.Positive);
            IComponent node2 = R.Negative.ConnectTo(dipole.Negative);

            IComponent positive = R.Positive;

            node1.Variables.First().Setter(voltageNode1);
            node2.Variables.First().Setter(voltageNode2);
            positive.Variables.First().Setter(current);

            Assert.Equal(expectedValue, equation());
        }

        [Fact]
        public void NumberOfEquationsEqualsTwo()
        {
            IComponent R = new IdealResistor(1.0);
            var equations = R.Equations;

            Assert.Equal(2, equations.Count);
        }

        [Fact]
        public void VariablesReturnEmptyList()
        {
            IComponent R = new IdealResistor(1.0);
            Assert.Empty(R.Variables);
        }
    }
}
