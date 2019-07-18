using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Pamola.NET.UT")]

namespace Pamola
{
    internal static class Helper
    {
        /// <summary>
        /// Throws <see cref="ArgumentNullException"/> when <paramref name="source"/> is null.
        /// </summary>
        /// <typeparam name="T"><paramref name="source"/> type.</typeparam>
        /// <param name="source">Analysed object.</param>
        /// <param name="parameterName">Local name of <paramref name="source"/>.</param>
        /// <returns></returns>
        public static T ThrowOnNull<T>(this T source,string parameterName = "")
        {
            if (source==null) throw new ArgumentNullException(parameterName);            
            return source;
        }
    }
}
