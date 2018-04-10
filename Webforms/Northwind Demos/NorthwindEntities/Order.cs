using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NorthwindEntities
{
    [Table("Orders")]
    public class Order
    {
        #region Column Mappings
        [Key]
        public int OrderID { get; set; }
        public string CustomerID { get; set; }
        public int? EmployeeID { get; set; }
        public DateTime? OrderDate { get; set; }
        public DateTime? RequiredDate { get; set; }
        public DateTime? ShippedDate { get; set; }
        public int? ShipVia { get; set; }
        public decimal? Freight { get; set; }
        public string ShipName { get; set; }
        public string ShipAddress { get; set; }
        public string ShipCity { get; set; }
        public string ShipRegion { get; set; }
        public string ShipPostalCode { get; set; }
        public string ShipCountry { get; set; }

        [NotMapped]
        public string OrderInfo
        {
            get
            {
                string text = $"{OrderID} -  {OrderDate?.ToLongDateString()}";
                text = text.EndsWith("-") ? text.Replace("-", "") : text;
                return text;
            }
        }
        #endregion
    }
}
