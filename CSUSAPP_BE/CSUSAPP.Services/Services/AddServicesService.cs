using CSUSAPP.Common.DTO;
using CSUSAPP.DataAccess.DataContext;
using CSUSAPP.DataAccess.Entities;
using CSUSAPP.Services.DTO;
using CSUSAPP.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CSUSAPP.Services.Services
{
    public class AddServicesService : IAddServicesService
    {
        private readonly AppDataContext _appDataContext;
        public AddServicesService(AppDataContext appDataContext)
        {
            _appDataContext = appDataContext;
        }
        public async Task<ApiResponse> AddServices(AddServiceDTO request, Guid userId)
        {
            var roleCheck = await _appDataContext.UsersData.Where(x => x.UserId == userId).Select(x => x.roles).FirstOrDefaultAsync();
            if (roleCheck != DataAccess.Entities.Roles.Admin)
            {
                throw new ArgumentException("Forbidden. Only admins can add services.");
                //return Forbid(new { message = "Forbidden. Only admins can add services." });
            }
            var newService = new DataAccess.Entities.Services
            {
                ServiceName = request.ServiceName,
                CreatedDate = DateTime.UtcNow,
                CreatedByUserId = userId
            };

            // Add and save to the database
            _appDataContext.Services.Add(newService);
            await _appDataContext.SaveChangesAsync();
            var response = new ApiResponse()
            {
                Statuscode = Convert.ToInt32(HttpStatusCode.OK),
                Data = newService,
                Success = true
            };
            return response;
        }

        public async Task<ApiResponse> GetAvailableServicesForCustomers(long customerId)
        {
            // Check if the customer exists
            var customer = await _appDataContext.CustomerDetails
                .Include(c => c.SoldServices)
                .FirstOrDefaultAsync(c => c.Id == customerId);

            if (customer == null)
            {
                throw new ArgumentException("Customer is not available.");
                //return NotFound(new { message = "Customer not found." });
            }           
            var soldServices = customer.SoldServices.Select(s => s.ServiceName).ToList();
            
            var availableServices = await _appDataContext.Services
                .Where(s => !soldServices.Contains(s.ServiceName))
                .Select(s => new AvailableServiceDto
                {
                    Id = s.Id,
                    ServiceName = s.ServiceName,
                    CreatedDate = s.CreatedDate
                })
                .ToListAsync();
            var response = new ApiResponse()
            {
                Statuscode = Convert.ToInt32(HttpStatusCode.OK),
                Data = availableServices,
                Success = true
            };
            return response;
        }
    }
}
