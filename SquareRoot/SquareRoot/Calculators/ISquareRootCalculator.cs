using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquareRoot
{
    /// <summary>
    /// Contract which defines a means to calculate a square root.
    /// </summary>
    public interface ISquareRootCalculator
    {
        /// <summary>
        /// Calculates the square root of the number provided in <paramref name="some_number"/>.
        /// </summary>
        /// <param name="some_number">A value which must be over the value of 0.</param>
        /// <returns>A decimal value to the nearest 1/100ths which is the square root of the provided value in <paramref name="some_number"/>.</returns>
        decimal Calculate(decimal some_number);

        /// <summary>
        /// Gets or sets the iterations each implementation processed before arriving at the closest approximation.
        /// </summary>
        /// <value>
        /// The iterations.
        /// </value>
        int Iterations { get; set; }

        /// <summary>
        /// Gets the name of the implementation.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        string ImplementationName { get; }
    }
}
