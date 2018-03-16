using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NorthwindEntities
{
    // It's a "best practice" to name your classes in the singular form
    [Table("Categories")]
    public class Category
    {
        // A property for each column in the DB table
        [Key] // "Annotation" - Primary Key
        public int CategoryID { get; set; }

        [Required, StringLength(15)] public string CategoryName { get; set; }
        public string Description { get; set; }
        public byte[] Picture { get; set; }
        [StringLength(40)] public string PictureMimeType { get; set; }
    }
}
