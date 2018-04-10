using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NorthwindEntities
{
    [Table("Employees")]
    public class Employee
    {
        #region Column Mappings
        [Key]
        public int EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string Lastname { get; set; }
        public string Title { get; set; }
        public string TitleOfCourtesy { get; set; }
        public DateTime? BirthDate { get; set; }
        public DateTime? HireDate { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string HomePhone { get; set; }
        public string Extension { get; set; }
        public byte[] Photo { get; set; }
        public string PhotoMimeType { get; set; }
        public string Notes { get; set; }
        public int? ReportsTo { get; set; }
        public string PhotoPath { get; set; }
        public DateTime LastModified { get; set; } = DateTime.Now;

        [NotMapped]
        public string FullName { get { return $"{FirstName} {Lastname}"; } }
        [NotMapped]
        public string FormalName { get { return $"{Lastname}, {FirstName}"; } }
        #endregion
    }
}
