using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSUSAPP.Services.DTO
{
    public class AvailableServiceDto
    {
        public long Id { get; set; }
        public string ServiceName { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
