// The Entity Framework (EF) is a library of classes that allow
// us to interact and exchange data from database tables into
// classes that we define in our application.
// If we create classes that mirror the structure of the 
// database tables, then we can create a "Context" class
// that mirrors the database as a whole.
//  NorthwindContext               <==> NorthwindExtended database
//  Properties of NorthwindContext <==> tables in the database
//  Properties of Entities         <==> columns in a specific table
using NorthwindEntities; // To reference our Entity classes
using System.Data.Entity; // From the EF, for DbContext class

namespace NorthwindSystem.DAL
{
    // Act like a "virtual representation" of my database & its tables
    // We declare the class as "internal" so that it cannot be used
    // from outside this project's DLL (or "assembly").
    internal class NorthwindContext : DbContext // : represents inheritance
    {
        // The name "NW" identifies which connection string settings to use in the web.config file.
        public NorthwindContext() : base("name=NW")
        {
            // By default, the DbContext will create the database & its tables
            // based on the structure of this "context" class.
            // This process is called "initializing" the database.
            // We can turn it off by one of two approaches.
            // A) Modify the web.config to include instructions to NOT initialize for this class
            //    <contexts>
            //      <context type="NorthwindSystem.DAL.NorthwindContext, NorthwindSystem"
            //               disableDatabaseInitialization="true" />
            //    </contexts>
            // B) From within the NorthwindContext constructor, set the database's initializer to NULL
            //    Database.SetInitializer<NorthwindContext>(null);
        }

        // Properties that map Entitites to the DB tables
        // Entity Framework does NOT associate these property names
        // with the table names; the table names are based on how
        // they are defined in the Entity classes.
        public DbSet<Product> Products { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
