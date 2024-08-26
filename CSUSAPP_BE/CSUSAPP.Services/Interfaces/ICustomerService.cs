using CSUSAPP.Common.DTO;
using CSUSAPP.DataAccess.Entities;
using CSUSAPP.Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSUSAPP.Services.Interfaces
{
    public interface ICustomerService
    {
        public Task<ApiResponse> AddCustomer(CustomerDetailsDto request);
        public Task<ApiResponse> EditCustomer(EditCustomerDto request, Guid userId);
        public Task<List<EditCustomerDto>> GetCustomers();
        public Task<List<CustomerDetailsDto>> SearchCustomers(string searchTearm);
    }
}
    