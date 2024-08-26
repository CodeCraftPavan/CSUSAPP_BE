using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSUSAPP.DataAccess.Entities
{
    [Table("user_details")]
    public class UsersData
    {
        [Key]
        public Guid UserId { get; set; }
        public Roles roles { get; set;}
        public string? firstName { get; set; }
        public string? lastName { get; set; }
        public string? userEMailId { get; set; }
        public string? password { get; set; }
        public string? salt { get; set; }
    }
}
