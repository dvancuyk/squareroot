using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquareRoot
{
    /// <summary>
    /// Provides common functionality for all concrete implementations of <see cref="ISquareRootCalculator"/>.
    /// </summary>
    public abstract class SquareRootCalculatorBase : ISquareRootCalculator
    {
        #region : Methods :

        protected void Validate(decimal some_number)
        {
            if (some_number <= 0)
            {
                throw new ArgumentOutOfRangeException("Value must be greater than 0.");
            }
        }

        /// <summary>
        /// Calculates the square root of the number provided in <paramref name="some_number" />.
        /// </summary>
        /// <param name="some_number">A value which must be over the value of 0.</param>
        /// <returns>
        /// A float value to the nearest 1/100ths which is the square root of the provided value in <paramref name="some_number" />.
        /// </returns>
        public abstract decimal Calculate(decimal some_number);

        /// <summary>
        /// Determines whether the <paramref name="expectedSquareRoot"/> is an acceptable approximation for the square root of <paramref name="some_number"/>.
        /// </summary>
        /// <param name="some_number">The some_number.</param>
        /// <param name="expectedSquareRoot">The expected square root.</param>
        /// <returns></returns>
        protected bool IsSquareRoot(decimal some_number, decimal expectedSquareRoot)
        {
            var delta = .001M;

            var squaredValue = expectedSquareRoot * expectedSquareRoot;
            var acceptableLowerRange = some_number - delta;
            var acceptableUpperRange = some_number + delta;

            return squaredValue > acceptableLowerRange && squaredValue < acceptableUpperRange;
        }

        #endregion

        #region : Properties :

        /// <summary>
        /// Gets the name of the implementation.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public abstract string ImplementationName { get;}

        /// <summary>
        /// Gets or sets the iterations each implementation processed before arriving at the closest approximation.
        /// </summary>
        /// <value>
        /// The iterations.
        /// </value>
        public int Iterations { get; set; }

        #endregion
    }
}
