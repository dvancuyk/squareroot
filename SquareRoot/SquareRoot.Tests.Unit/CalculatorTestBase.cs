using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SquareRoot.Tests.Unit
{
    /// <summary>
    /// Provides a base for test harness testing the type <see cref="ISquareRootCalculator"/>.
    /// </summary>
    /// <typeparam name="TCalculator">Generic parameter which is restricted to implementations of <see cref="ISquareRootCalculator"/>.</typeparam>
    public abstract class CalculatorTestBase<TCalculator> where TCalculator : ISquareRootCalculator
    {
        #region : Properties :

        protected TCalculator Calculator { get; private set; }

        #endregion

        #region : Constructors :

        /// <summary>
        /// Initializes a new instance of the <see cref="CalculatorTestBase{TCalculator}"/> class.
        /// </summary>
        protected CalculatorTestBase()
        {
            Calculator = Activator.CreateInstance<TCalculator>();
        }

        #endregion

        #region : Unit Tests :

        /// <summary>
        /// Verifies when the value of 1 is passed in, the square root of 1 is returned.
        /// </summary>
        [TestMethod]
        public void CalculateShouldReturn1()
        {
            // Arrange
            var value = 1.0M;
            const decimal expected = 1.0M;

            // Act
            var actual = Calculator.Calculate(value);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Verifies when the value of 4 is passed in, the square root of 2 is returned.
        /// </summary>
        [TestMethod]
        public void CalculateShouldReturn2()
        {
            // Arrange
            var value = 4.0M;
            const decimal expected = 2.0M;

            // Act
            var actual = Calculator.Calculate(value);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Verifies when the value of 16 is passed in, the square root of 4 is returned.
        /// </summary>
        [TestMethod]
        public void CalculateShouldReturn4()
        {
            // Arrange
            var value = 16.0M;
            const decimal expected = 4.0M;

            // Act
            var actual = Calculator.Calculate(value);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Verifies when the value of 12 is passed in, the square root of 3.46 is returned.
        /// </summary>
        [TestMethod]
        public void CalculateShouldReturnCorrectApproximationFor12()
        {
            // Arrange
            var value = 12.0M;
            const decimal expected = 3.46M;

            // Act
            var actual = Calculator.Calculate(value);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        #endregion
    }
}
