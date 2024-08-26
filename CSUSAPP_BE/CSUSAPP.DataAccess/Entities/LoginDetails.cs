using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSUSAPP.DataAccess.Entities
{
    [Table("session_info")]
    public class LoginDetails
    {
        [Key]
        public long Id { get; set; }
        public Guid ExtLogInId { get; set; }
        public string EmailId { get; set; }
        public string? SessionToken { get; set; }
        public DateTime? LoggedInAt { get; set; }
        public LoginStatus Status { get; set; }
    }
    public enum LoginStatus
    {
        pending,
        completed
    }
}
