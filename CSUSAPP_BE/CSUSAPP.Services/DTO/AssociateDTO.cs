using CSUSAPP.DataAccess.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSUSAPP.Services.DTO
{
    public class AssociateDTO
    {
        public int AssociateId { get; set; }
        public int CustomerId { get; set; }
        public string AssociateName {  get; set; }
        public string ContactInformation { get; set; }
        public Guid UpdatedBy { get; set; }
        public Roles Roles { get; set; }
    }
}
