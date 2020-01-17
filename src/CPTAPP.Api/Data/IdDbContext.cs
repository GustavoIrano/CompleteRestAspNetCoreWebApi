using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CPTAPP.Api.Data
{
    public class IdDbContext : IdentityDbContext
    {
        public IdDbContext(DbContextOptions<IdDbContext> options) : base(options) {}
    }
}
