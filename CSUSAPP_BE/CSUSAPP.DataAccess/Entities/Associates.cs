using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSUSAPP.DataAccess.Entities
{
    [Table("associates")]
    public class Associates
    {
        [Key]
        public long Id { get; set; }
        public string AssociateName { get; set; }
        public Roles Role { get; set; }
        public string ContactInformation { get; set; }

        // Foreign Key
        public long CustomerDetailsId { get; set; }
        public CustomerDetails CustomerDetails { get; set; }
    }

    public enum Roles
    {
        Admin,
        Users
    }
}
