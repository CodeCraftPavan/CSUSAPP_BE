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
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CSUSAPP.Services.Services
{
    public class AssociateService : IAssociateService
    {
        private readonly AppDataContext _appDataContext;
        public AssociateService(AppDataContext appDataContext)
        {
            _appDataContext = appDataContext;
        }

        public async Task<ApiResponse> AddAssociatesServices(AssociateDTO request, Guid userId)
        {
            try
            {
                if (request == null) throw new ArgumentNullException(nameof(request));
                var addAssociates = new Associates();
                addAssociates.AssociateName = request.AssociateName;
                addAssociates.Role = request.Roles;
                addAssociates.ContactInformation = request.ContactInformation;
                addAssociates.CustomerDetailsId = request.CustomerId;
                addAssociates.UpdatedBy = userId;
                await _appDataContext.AddAsync(addAssociates);
                _appDataContext.SaveChanges();
                var response = new ApiResponse()
                {
                    Statuscode = Convert.ToInt32(HttpStatusCode.OK),
                    Data = addAssociates,
                    Success = true
                };
                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task<ApiResponse> EditAssociatesServices(AssociateDTO request, Guid userId)
        {
            try
            {
                if (request == null) throw new ArgumentNullException(nameof(request));
                var addSoldeServices = new SoldService();
                var customer = await _appDataContext.CustomerDetails.Where(x => x.Id == request.CustomerId).FirstOrDefaultAsync();
                var existingAssociate = await _appDataContext.Associates
                    .Where(x => x.Id == request.AssociateId && x.CustomerDetailsId == request.CustomerId)
                    .FirstOrDefaultAsync();
                if (customer.Associates == null)
                {
                    throw new Exception("service Not Found. Please add the service.");
                }
                else
                {
                    existingAssociate.Role = request.Roles;
                    existingAssociate.AssociateName = request.AssociateName;
                    existingAssociate.ContactInformation = request.ContactInformation;
                    existingAssociate.UpdatedBy = userId;
                    _appDataContext.Update(existingAssociate);
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
