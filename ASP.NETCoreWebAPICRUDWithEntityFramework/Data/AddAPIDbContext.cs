using ASP.NETCoreWebAPICRUD.Models;
using Microsoft.EntityFrameworkCore;

namespace ASP.NETCoreWebAPICRUD.Data
{
    public class AddAPIDbContext : DbContext
    {
        public AddAPIDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Contact> Contacts { get; set; }
    }
}
