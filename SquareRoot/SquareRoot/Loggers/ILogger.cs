using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquareRoot.Loggers
{
    public interface ILogger
    {
        void Log(LoggingLevel loggingLevel, string information, params object[] arguments);
    }
}
