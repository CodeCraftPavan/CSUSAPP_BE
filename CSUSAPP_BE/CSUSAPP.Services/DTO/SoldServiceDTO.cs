using CSUSAPP.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSUSAPP.Services.DTO
{
    public class SoldServiceDTO
    {
        public int CustomerId { get; set; }
        public int ServiceId { get; set;}
        public string ServiceName { get; set; }
        public DateTime SaleDate { get; set; }
        public ServiceStatus Status { get; set; }
    }

    public class EditSoldServiceDTO
    {
        public int CustomerId { get; set; }
        public int ServiceId { get; set; }
        public string ServiceName { get; set; }
        public ServiceStatus Status { get; set; }
    }
}
