using DataEntities;       // Access to CodeDemo class
using System.Data.Entity; // Access to DbContext and DbSet<T> classes

namespace ServerSide.DAL
{
    internal class DemoLibraryContext : DbContext
    {
        public DemoLibraryContext() : base("DefaultConnection")
        {
        }

        public DbSet<CodeDemo> CodeDemos { get; set; }
    }
}
