using SquareRoot.Loggers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace SquareRoot
{
    class Program
    {
        private static readonly ILogger _logger = new ConsoleLogger();
        private static readonly Stopwatch stopWatch = new Stopwatch();

        static void Main(string[] args)
        {
            var calculators = new List<ISquareRootCalculator>
            {
                    new BruteForceCalculator(),
                    new BinarySearchCalculator(),
                    new LibraryCalculator()
            };
            Console.WriteLine("This is an app to calculate the square root and look at statistics of the different approaches.");
            
            var response = PrintPromptMessage();
            while (response.Length > 0 && response.ToUpper()[0] != 'Q')
            {
                try
                {
                    Console.WriteLine();

                    var number = decimal.Parse(response);
                    foreach (var calculator in calculators)
                    {
                        PrintStatistics(calculator, number);
                        calculator.Iterations = 0;
                    }

                    Console.WriteLine();

                    Console.WriteLine("Enter any button to continue...");
                    Console.ReadLine();
                    Console.Clear();

                    response = PrintPromptMessage();
                }
                catch (Exception exception)
                {
                    _logger.Log(LoggingLevel.Warning, exception.Message);
                }
            }
        }

        private static void PrintStatistics(ISquareRootCalculator calculator, decimal number)
        {
            stopWatch.Start();

            var result = calculator.Calculate(number);

            stopWatch.Stop();

            _logger.Log(LoggingLevel.Info, "{0} : {1}", calculator.ImplementationName, result.ToString("G"));
            _logger.Log(LoggingLevel.Info, "\tElapsed Time (in ticks): {0}", stopWatch.ElapsedTicks);
            _logger.Log(LoggingLevel.Info, "\tNumber of Iterations: {0}", calculator.Iterations);

            stopWatch.Reset();
        }

        private static string PrintPromptMessage()
        {
            Console.Write("Please enter the number (enter q to quit): ");
            return Console.ReadLine();
        }
    }
}
