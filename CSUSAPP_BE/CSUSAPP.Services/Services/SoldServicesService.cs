// <copyright file="SoldServicesService.cs" company="Canarys Automations Ltd">
// Copyright (c) Canarys Automations Ltd. All rights reserved.
// </copyright>

using CSUSAPP.Common.DTO;
using CSUSAPP.DataAccess.DataContext;
using CSUSAPP.DataAccess.Entities;
using CSUSAPP.Services.DTO;
using CSUSAPP.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace CSUSAPP.Services.Services
{
    /// <summary>
    /// Implementation of the ISoldService Service.
    /// </summary>
    public class SoldServicesService : ISoldServicesService
    {
        private readonly AppDataContext _appDataContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="SoldServicesService"/> class with the specified application data context.
        /// </summary>
        /// <param name="appDataContext">appDataContext.</param>
        public SoldServicesService(AppDataContext appDataContext)
        {
            _appDataContext = appDataContext;
        }

        /// <inheritdoc/>
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
            catch (Exception)
            {
                throw;
            }
        }

        /// <inheritdoc/>
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
                    Success = true,
                };
                return response;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
