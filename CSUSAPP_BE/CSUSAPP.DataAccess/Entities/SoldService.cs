using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSUSAPP.DataAccess.Entities
{
    [Table("sold_services")]
    public class SoldService
    {
        [Key]
        public long Id { get; set; }
        public string ServiceName { get; set; }
        public DateTime SaleDate { get; set; }
        public ServiceStatus Status { get; set;}
        public Guid UpdatedBy { get; set; }

        // Foreign Key
        public long CustomerDetailsId { get; set; }
        public CustomerDetails CustomerDetails { get; set; }
    }
    public enum ServiceStatus
    {
        Active,
        Inactive
    }
}
