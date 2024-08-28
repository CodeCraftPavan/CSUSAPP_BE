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
    public class SoldServicesService : ISoldServicesService
    {
        private readonly AppDataContext _appDataContext;
        public SoldServicesService(AppDataContext appDataContext) 
        {
            _appDataContext = appDataContext;
        }
        public async Task<ApiResponse> AddSoldServices(SoldServiceDTO request, Guid userId)
        {
            try
            {
                if (request == null) throw new ArgumentNullException(nameof(request));
                var addSoldeServices = new SoldService();
                var customer = await _appDataContext.CustomerDetails.Where(x => x.Id == request.CustomerId).FirstOrDefaultAsync();
                if (customer.SoldServices != null)
                {
                    throw new Exception("service already has being served to customer");
                }
                else
                {
                    addSoldeServices.ServiceName = request.ServiceName;
                    addSoldeServices.Status = request.Status;
                    addSoldeServices.SaleDate = DateTime.Now;
                    addSoldeServices.CustomerDetailsId = request.CustomerId;
                    addSoldeServices.UpdatedBy = userId;
                    await _appDataContext.AddAsync(addSoldeServices);
                    _appDataContext.SaveChanges();
                }
                var response = new ApiResponse()
                {
                    Statuscode = Convert.ToInt32(HttpStatusCode.OK),
                    Data = addSoldeServices,
                };
                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        public async Task<ApiResponse> EditSoldServices(SoldServiceDTO request, Guid userId)
        {
            try
            {
                if (request == null) throw new ArgumentNullException(nameof(request));
                var addSoldeServices = new SoldService();
                var customer = await _appDataContext.CustomerDetails.Where(x => x.Id == request.CustomerId).FirstOrDefaultAsync();
                var soldService = await _appDataContext.SoldServices
                    .Where(x => x.Id == request.ServiceId && x.CustomerDetailsId == request.CustomerId)
                    .FirstOrDefaultAsync();
                if (customer.SoldServices == null)
                {
                    throw new Exception("service Not Found. Please add the service.");
                }
                else
                {
                    soldService.Status = request.Status;
                    soldService.ServiceName = request.ServiceName;
                    soldService.SaleDate = request.SaleDate;
                    soldService.UpdatedBy = userId;
                    _appDataContext.Update(soldService);
                    _appDataContext.SaveChanges();
                }
                var response = new ApiResponse()
                {
                    Statuscode = Convert.ToInt32(HttpStatusCode.OK),
                    Data = addSoldeServices,
                    Success = true
                };
                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
