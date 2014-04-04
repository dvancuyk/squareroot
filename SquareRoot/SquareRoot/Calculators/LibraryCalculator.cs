using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquareRoot
{
    public class LibraryCalculator : SquareRootCalculatorBase
    {
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
            Iterations++;

            var squareRoot = Math.Sqrt((double)some_number);
            return Math.Round((decimal)squareRoot, 2);
        }

        public override string ImplementationName
        {
            get { return "LibraryCalculator"; }
        }
    }
}
