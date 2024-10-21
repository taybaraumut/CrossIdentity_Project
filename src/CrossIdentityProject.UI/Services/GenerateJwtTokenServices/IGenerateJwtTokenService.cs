using NuGet.Common;

namespace CrossIdentityProject.UI.Services.GenerateJwtTokenServices
{
    public interface IGenerateJwtTokenService
    {
        public Task<string> JwtToken();
    }
}
