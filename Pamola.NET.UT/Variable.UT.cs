using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using Xunit;

namespace Pamola.UT
{
    /// <summary>
    /// Tests the methods of <see cref="Pamola.Variable"/>
    /// </summary>
    public class VariableUT
    {
        /// <summary>
        /// Data for <see cref="VariableUT.GetterReturnsValue(Complex)"/> test.
        /// </summary>
        public static IEnumerable<object[]> ValueData { get; } = new List<object[]>()
        {
            new object[] {new Complex(0.0,0.0)},
            new object[] {new Complex(1.0,1.0)},
            new object[] {new Complex(1.0,-1.0)},
            new object[] {new Complex(-1.0,1.0)},
            new object[] {new Complex(-1.0,-1.0)},
            new object[] {new Complex(-1.1,-1.1)}
        };

        /// <summary>
        /// Checks if variable returns the data values.
        /// </summary>
        /// <param name="returnValue">Return value for getter method.</param>
        [Theory]
        [MemberData(nameof(ValueData))]
        public void GetterReturnsValue(Complex returnValue)
        {
            var myVariable = new Variable(
                () => returnValue,
                null);
            Assert.Equal(returnValue, myVariable.Getter());
        }

        /// <summary>
        /// Checks if variable sets the data values properly.
        /// </summary>
        /// <param name="setValue">Set value for setter method.</param>
        [Theory]
        [MemberData(nameof(ValueData))]
        public void SetterSetsValue(Complex setValue)
        {
            var settedValue = new Complex(0.0, 0.0);
            var myVariable = new Variable(
                () => settedValue, 
                value => settedValue = value);

            myVariable.Setter(setValue);
            Assert.Equal(setValue, myVariable.Getter());

        }
    }
}
