using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquareRoot
{
    /// <summary>
    /// A concrete implementation of <see cref="ISquareRootCalculator"/> which performs an approach similiar to the binary search pattern.
    /// </summary>
    public class BinarySearchCalculator : SquareRootCalculatorBase
    {
        /// <summary>
        /// Gets the name of the implementation.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public override string ImplementationName
        {
            get { return "BinarySearchCalculator"; }
        }

        protected decimal Number { get; private set; }

        /// <summary>
        /// Calculates the square root of the number provided in <paramref name="some_number" />.
        /// </summary>
        /// <param name="some_number">A value which must be over the value of 0.</param>
        /// <returns>
        /// A float value to the nearest 1/100ths which is the square root of the provided value in <paramref name="some_number" />.
        /// </returns>
        public override decimal Calculate(decimal some_number)
        {
            base.Validate(some_number);
            Number = some_number;

            return Math.Round(FindSquareRoot(some_number, 0, some_number), 2);
        }

        protected virtual decimal FindSquareRoot(decimal value, decimal lowerBound, decimal upperBound)
        {
            Iterations++;

            value = (upperBound + lowerBound) / 2M;

            if (IsSquareRoot(Number, value))
            {
                return value;
            }
            if (value * value > Number)
            {
                return FindSquareRoot(value, lowerBound, value);
            }
            else
            {
                return FindSquareRoot(value, value, upperBound);
            }
        }
    }
}
