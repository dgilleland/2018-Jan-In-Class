using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataEntities
{
    // Since this class is the <T> in a DbSet<T> of our DemoLibraryContext,
    // the properties of this class effectively act as the "columns" of
    // the database table.
    [Table("CodeDemos")] // <-- This is called an "Attribute"
    public class CodeDemo
    {
        public int CodeDemoID { get; set; } // EF "assumed" this was the PK
        [Required] // The following property will be mapped as a NOT NULL column
        [StringLength(25)] // The property's db column will be a varchar(25)
        public string Name { get; set; }
        [StringLength(300)]
        public string Description { get; set; }
    }
}
