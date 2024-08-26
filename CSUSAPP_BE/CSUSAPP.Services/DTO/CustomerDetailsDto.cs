using CSUSAPP.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSUSAPP.Services.DTO
{
    public class CustomerDetailsDto
    {
        public string Abbrevation { get; set; }
        public string FullName { get; set; }
        public string Region { get; set; }
        public IndSegment IndustrySegment { get; set; }
        public DateTime AccountCreationDate { get; set; }
        public string Notes { get; set; }
        public Status Status { get; set; }
        public List<SoldServiceDto> SoldServices { get; set; }
        public List<AssociateDto> Associates { get; set; }
    }

    public class SoldServiceDto
    {
        public long Id { get; set; }
        public string ServiceName { get; set; }
        public DateTime SaleDate { get; set; }
        public ServiceStatus status { get; set; }
    }

    public class AssociateDto
    {
        public long Id { get; set; }
        public string AssociateName { get; set; }
        public Roles Role { get; set; }
        public string ContactInformation { get; set; }
    }
}
