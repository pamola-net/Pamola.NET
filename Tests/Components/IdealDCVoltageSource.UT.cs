using System;
using System.Linq;
using Xunit;
using Pamola.Components;
using System.Numerics;
using System.Collections.Generic;

namespace Pamola.UT.Components
{
    public class IdealDCVoltageSourceUT
    {

        public static IEnumerable<object[]> ValueData { get; } = new List<object[]>()
        {
            new object[]
            {
                new Complex(0.0,0.0),
                new Complex(0.0,0.0),
                0.0,
                new Complex(0.0,0.0)
            },

            new object[]
            {
                new Complex(1.0,0.0),
                new Complex(0.0,0.0),
                1.0,
                new Complex(0.0,0.0)
            },

            new object[]
            {
                new Complex(-1.0,0.0),
                new Complex(0.0,1.0),
                -1.0,
                new Complex(0.0,-1.0)
            }

        };

        [Theory]
        [InlineData(0.0)]
        [InlineData(3.2)]
        [InlineData(-3.2)]
        public void VoltageYieldsValue(double voltage)
        {
            var V = new IdealDCVoltageSource(voltage);

            Assert.Equal(voltage, V.Voltage);
        }

        [Fact]
        public void FollowsVoltageDropDisconnected()
        {
            var V1 = new IdealDCVoltageSource(1.0);
            var V2 = new IdealDCVoltageSource(1.0);
            var V3 = new IdealDCVoltageSource(1.0);

            var equations1 = ((IComponent)V1).Equations;
            var equations2 = ((IComponent)V2).Equations;
            var equations3 = ((IComponent)V3).Equations;

            V2.Positive.ConnectTo(V3.Negative);

            Assert.Equal(default(Complex), equations1.First()());
            Assert.Equal(default(Complex), equations2.First()());
            Assert.Equal(default(Complex), equations3.First()());
        }

        [Theory]
        [MemberData(nameof(ValueData))]
        public void FollowsVoltageDropConnected(
            Complex voltageNode1,
            Complex voltageNode2,
            double voltage,
            Complex expectedValue)
        {
            var V = new IdealDCVoltageSource(voltage);
            var dipole = new MockedDipole();

            var equation = ((IComponent)V).Equations.First();

            IComponent node1 = V.Positive.ConnectTo(dipole.Positive);
            IComponent node2 = V.Negative.ConnectTo(dipole.Negative);

            node1.Variables.First().Setter(voltageNode1);
            node2.Variables.First().Setter(voltageNode2);

            Assert.Equal(expectedValue, equation());
        }


        [Fact]
        public void NumberOfEquationsEqualsTwo()
        {
            IComponent V = new IdealDCVoltageSource(1.0);
            var equations = V.Equations;

            Assert.Equal(2, equations.Count);
        }

        [Fact]
        public void VariablesReturnEmptyList()
        {
            IComponent V = new IdealDCVoltageSource(1.0);
            Assert.Empty(V.Variables);
        }

    }
}
