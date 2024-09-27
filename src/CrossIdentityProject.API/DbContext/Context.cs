using CrossIdentityProject.API.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CrossIdentityProject.API.DbContext
{
    public class Context:IdentityDbContext<AppUser,AppRole,int>
    {
        public Context(DbContextOptions<Context> options):base(options)
        {
                
        }
    }
}
