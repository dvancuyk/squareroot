using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquareRoot
{
    /// <summary>
    /// This is the ugly brute force method which simple iterates through the numbers until it finds the closest approximation to the nearest 1/100ths.
    /// </summary>
    public class BruteForceCalculator : SquareRootCalculatorBase
    {

        /// <summary>
        /// Gets the name of the implementation.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public override string ImplementationName
        {
            get { return "BruteForceCalculator"; }
        }

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

            decimal square_root = 1.00M;
            decimal incrementalValue = 1.00M;
            while (!IsSquareRoot(some_number, square_root))
            {
                square_root = LoopAtIncrement(some_number, square_root, incrementalValue);
                incrementalValue /= 10;
            }

            return Math.Round(square_root, 2);
        }

        /// <summary>
        /// Loops with increments of <paramref name="incrementalAmount"/> until the square root of the <paramref name="value"/> is the the last iteration where 
        /// it's squared value is still less than or equal to the original number represented by <paramref name="some_number"/>.
        /// </summary>
        /// <param name="some_number">The some_number.</param>
        /// <param name="value">The value.</param>
        /// <param name="incrementalAmount">The incremental amount.</param>
        /// <returns></returns>
        private decimal LoopAtIncrement(decimal some_number, decimal value, decimal incrementalAmount)
        {
            while (value * value <= some_number)
            {
                base.Iterations++;
                value += incrementalAmount;
            }

            return value - incrementalAmount;
        }
    }
}
