using DataEntities;       // Access to CodeDemo class
using System.Data.Entity; // Access to DbContext and DbSet<T> classes

namespace ServerSide.DAL
{
    // As a DbContext class, our DemoLibraryContext becomes like a
    // "virtual" database. Each DbSet<T> property in our class is
    // like a "virtual" database table.
    internal class DemoLibraryContext : DbContext
    {
        public DemoLibraryContext() : base("DefaultConnection")
        {
        }

        public DbSet<CodeDemo> CodeDemos { get; set; }
    }
}
