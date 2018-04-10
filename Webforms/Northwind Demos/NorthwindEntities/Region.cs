using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NorthwindEntities
{
    [Table("Region")]
    public class Region
    {
        #region ColumnMappings
        [Key]
        public int RegionID { get; set; }
        public string RegionDescription { get; set; }
        #endregion
    }
}
