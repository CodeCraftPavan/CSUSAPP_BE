using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSUSAPP.DataAccess.Entities
{
    [Table("customer_details")]
    public class CustomerDetails
    {
        public long Id { get; set; }
        public string Abbrevation { get; set; }
        public string FullName { get; set; }
        public string Region { get; set; }
        public IndSegment IndustrySegment { get; set; }
        public DateTime AccountCreationDate { get; set; }
          //check with possible sales property
        public string Notes { get; set; }
        public Status Status { get; set; }

        // Navigation Properties
        public ICollection<SoldService> SoldServices { get; set; }
        public ICollection<Associates> Associates { get; set; }
    }
    public enum IndSegment
    {
        Main,
        Sub,
        SubSub
    }

    public enum Status
    {
        Active,
        Dormant,
        Status,
        Lost,
        Rejected,
        Unknown
    }
}
