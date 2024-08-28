using CSUSAPP.Common.DTO;
using CSUSAPP.Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSUSAPP.Services.Interfaces
{
    public interface ISoldServicesService
    {
        public Task<ApiResponse> AddSoldServices(SoldServiceDTO request, Guid userId);
        public Task<ApiResponse> EditSoldServices(SoldServiceDTO request, Guid userId);
    }
}
