using CSUSAPP.Common.DTO;
using CSUSAPP.Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSUSAPP.Services.Interfaces
{
    public interface IAssociateService
    {
        public Task<ApiResponse> AddAssociatesServices(AssociateDTO request, Guid userId);

        public Task<ApiResponse> EditAssociatesServices(AssociateDTO request, Guid userId);
    }
}
