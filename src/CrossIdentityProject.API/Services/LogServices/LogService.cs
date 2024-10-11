namespace CrossIdentityProject.API.Services.LogServices
{
    public class LogService : ILogService
    {
        private readonly ILogger<LogService> logger;

        public LogService(ILogger<LogService> logger)
        {
            this.logger = logger;
        }

        public void Login_Sucess_Logger(string name , string surname , string email)
        {
           logger.Log(LogLevel.Information,new EventId(1), "Login Process Successful", null,(state,exception)=>state.ToString());   
            
           logger.Log(LogLevel.Information, new EventId(1), $"Name : {name}" 
               + $"Surname : {surname}" 
               + $"Email : {email}", null, (state, exception) => state.ToString());
        }

        public void Register_Sucess_Logger(string name, string surname, string email, string username, string district, string city)
        {
            logger.Log(LogLevel.Information, new EventId(2), "Register Process Successful", null, (state, exception) => state.ToString());

            logger.Log(LogLevel.Information, new EventId(2),
                $"Name : {name} " 
                + $"Surname : {surname} " 
                + $"Email : {email} " 
                + $"Username : {username} " 
                + $"District : {district} " 
                + $"City : {city}", null, (state, exception) => state.ToString());
        }
    }
}
