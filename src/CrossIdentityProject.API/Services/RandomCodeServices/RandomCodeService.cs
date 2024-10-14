namespace CrossIdentityProject.API.Services.RandomCodeServices
{
    public class RandomCodeService : IRandomCodeService
    {
        public ushort GetCode()
        {
            var random_number = new Random();
            var number = random_number.Next(1000,9999);
            return (ushort)number;
        }
    }
}
