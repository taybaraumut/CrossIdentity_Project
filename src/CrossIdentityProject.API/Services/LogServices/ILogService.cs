using System.Xml.Linq;

namespace CrossIdentityProject.API.Services.LogServices
{
    public interface ILogService
    {
        public void Register_Sucess_Logger(string name, string surname, string email,string username,string district,string city);
        public void Login_Sucess_Logger(string name,string surname,string email);      
    }
}
