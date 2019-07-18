using System;
using System.Linq;
using Xunit;

namespace Pamola.UT
{
    /// <summary>
    /// Refers to tests of <see cref="Pamola.Helper"/>.
    /// </summary>
    public class HelperUT
    {
        [Fact]
        public void ThrowsOnNull()
        {
            object obj = null;
            Assert.Throws<ArgumentNullException>(() => obj.ThrowOnNull());
        }

        [Fact]
        public void ChainsObjects()
        {
            object obj = new object();
            Assert.Equal(obj, obj.ThrowOnNull());
        }
    }
}
