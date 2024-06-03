using AspReactApp.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace AspReactApp.Server.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Person> Persons { get; set; }
    }
}
