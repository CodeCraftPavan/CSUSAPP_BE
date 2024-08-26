using CSUSAPP.Common.DTO;
using CSUSAPP.Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSUSAPP.Services.Interfaces
{
    public interface IAddServicesService
    {
        public Task<ApiResponse> AddServices(AddServiceDTO request, Guid userId);
        public Task<ApiResponse> GetAvailableServicesForCustomers(long customerId);
    }
}
