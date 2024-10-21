namespace CrossIdentityProject.API.Models
{
    public class Deneme
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public bool TwoFactor { get; set; }

        public string ErrorMessage { get; set; }
    }
}
