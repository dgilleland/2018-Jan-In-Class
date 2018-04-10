using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NorthwindEntities
{
    [Table("Territories")]
    public class Territory
    {
        #region Column Mappings
        [Key]
        public string TerritoryID { get; set; }
        public string TerritoryDescription { get; set; }
        public int RegionID { get; set; }
        #endregion
    }
}
