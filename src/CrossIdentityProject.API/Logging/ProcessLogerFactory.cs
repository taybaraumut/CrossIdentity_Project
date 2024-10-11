using CrossIdentityProject.API.Logging;

namespace CrossIdentityProject.API.Logger
{
    public class ProcessLogerFactory : ILoggerProvider
    {
        public ILogger CreateLogger(string message)
        {
           return new ProcessLoger();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
