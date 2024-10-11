
using System.Linq.Expressions;

namespace CrossIdentityProject.API.Logging
{
    public class ProcessLoger :ILogger
    {

        public IDisposable? BeginScope<TState>(TState state) where TState : notnull
        {
            throw new NotImplementedException();
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            throw new NotImplementedException();
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
        {
            string log_message = formatter(state,exception);
            log_message = $"{DateTime.Now:dddd:MMMM:yyyy}" + $"{log_message}";
        }
    }
}
