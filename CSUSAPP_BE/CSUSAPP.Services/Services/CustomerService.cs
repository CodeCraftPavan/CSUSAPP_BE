using Azure;
using CSUSAPP.Common.DTO;
using CSUSAPP.DataAccess.DataContext;
using CSUSAPP.DataAccess.Entities;
using CSUSAPP.Services.DTO;
using CSUSAPP.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CSUSAPP.Services.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly AppDataContext _appDataContext;
        public CustomerService(AppDataContext appDataContext)
        {
            _appDataContext = appDataContext;
        }

        public async Task<ApiResponse> AddCustomer(CustomerDetailsDto request)
        {
            var response = new ApiResponse();
            try
            {
                if (request == null)
                {
                    throw new ArgumentNullException("request cannot be null");
                }
                var newCustomer = new CustomerDetails
                {
                    Abbrevation = request.Abbrevation,
                    FullName = request.FullName,
                    Region = request.Region,
                    IndustrySegment = request.IndustrySegment,
                    AccountCreationDate = request.AccountCreationDate,
                    Notes = request.Notes,
                    Status = request.Status,
                    SoldServices = request.SoldServices.Select(s => new SoldService
                    {
                        ServiceName = s.ServiceName,
                        SaleDate = s.SaleDate,
                        Status = s.status
                    }).ToList(),
                    Associates = request.Associates.Select(s => new Associates
                    {
                        AssociateName = s.AssociateName,
                        Role = s.Role,
                        ContactInformation = s.ContactInformation
                    }).ToList()
                };
                _appDataContext.Add(newCustomer);
                await _appDataContext.SaveChangesAsync();
                response.Statuscode = Convert.ToInt32(HttpStatusCode.OK);
                response.Data = request;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;

        }

        public async Task<ApiResponse> EditCustomer(EditCustomerDto request, Guid userId)
        {

            bool adminCheck = false;
            bool serviceEmptyCheck = false;
            bool associateEmptyCheck = false;
            if (!request.SoldServices.Select(s => s.ServiceName.IsNullOrEmpty()).Any()) //provide dropdown in UI for servicenames.
            {
                serviceEmptyCheck = true;
            }
            if (!request.Associates.Select(s => s.AssociateName.IsNullOrEmpty()).Any()) //provide dropdown in UI for servicenames.
            {
                associateEmptyCheck = true;
            }
            var userRole = await _appDataContext.UsersData.Where(x => x.UserId == userId).Select(x => x.roles).FirstOrDefaultAsync();
            //if (request.Associates.Select(s => s.Role == Roles.Admin).FirstOrDefault())
            if (userRole == Roles.Admin)
            {
                adminCheck = true;
            }
            var editCustomer = await _appDataContext.CustomerDetails
                    .Include(c => c.SoldServices)
                    .Include(c => c.Associates)
                    .FirstOrDefaultAsync(c => c.Id == request.Id);
            if (editCustomer == null) throw new Exception("Customer not found.");
            if (adminCheck)
            {
                editCustomer.FullName = request.FullName;
                editCustomer.Status = request.Status;
            }
            editCustomer.Abbrevation = request.Abbrevation ?? editCustomer.Abbrevation;
            editCustomer.Region = request.Region ?? editCustomer.Region;
            editCustomer.IndustrySegment = editCustomer.IndustrySegment;
            editCustomer.Notes = request.Notes ?? editCustomer.Notes;
            editCustomer.AccountCreationDate = request.AccountCreationDate ;
            if (!serviceEmptyCheck)
            {
                foreach (var soldService in request.SoldServices)
                {
                    //_appDataContext.SoldServices.RemoveRange(soldService);
                    var existingService = editCustomer.SoldServices.FirstOrDefault(s => s.Id == soldService.Id);
                    if (existingService != null)
                    {
                        existingService.ServiceName = soldService.ServiceName;
                        existingService.SaleDate = soldService.SaleDate;
                        existingService.Status = soldService.Staus;
                    }
                    else
                    {
                        editCustomer.SoldServices.Add(new SoldService
                        {
                            ServiceName = soldService.ServiceName,
                            SaleDate = soldService.SaleDate,
                            Status = soldService.Staus
                        });
                    }
                    //editCustomer.SoldServices = request.SoldServices.Where(s => s.Id == request.Id).Select(s => new SoldService
                    //{
                    //    ServiceName = s.ServiceName,
                    //    SaleDate = s.SaleDate
                    //}).ToList();
                }
            }
            if (!associateEmptyCheck)
            {
                foreach (var associate in request.Associates)
                {
                    //_appDataContext.Associates.RemoveRange(associate);
                    //editCustomer.Associates = request.Associates.Where(s => s.Id == request.Id).Select(a => new Associates
                    //{
                    //    AssociateName = a.AssociateName,
                    //    Role = a.Role,
                    //    ContactInformation = a.ContactInformation
                    //}).ToList();
                    var existingAssociate = editCustomer.Associates.FirstOrDefault(s => s.Id == associate.Id);
                    if (existingAssociate != null)
                    {
                        existingAssociate.AssociateName = associate.AssociateName;
                        existingAssociate.Role = associate.Role;
                        existingAssociate.ContactInformation = associate.ContactInformation;
                    }
                    else
                    {
                        editCustomer.Associates.Add(new Associates
                        {
                            AssociateName = associate.AssociateName,
                            Role = associate.Role,
                            ContactInformation = associate.ContactInformation
                        }); 
                    }
                }
            }
            await _appDataContext.SaveChangesAsync();
            var response = new ApiResponse()
            {
                Statuscode = Convert.ToInt32(HttpStatusCode.OK),
                Data = editCustomer,
                Success = true
            };
            return response;
        }

        public async Task<PaginatedResult<EditCustomerDto>> GetCustomers(paginationDTO pagination)
        {
            var totalCount = await _appDataContext.CustomerDetails.CountAsync();

            var customers = await _appDataContext.CustomerDetails
                .Include(c => c.SoldServices)
                .Include(c => c.Associates)
                .OrderBy(c => c.Id)
                .Skip((pagination.pageNumber - 1) * pagination.pageSize)
                .Take(pagination.pageSize)
                .ToListAsync();

            var customerDto = customers.Select(c => new EditCustomerDto
            {
                Id = c.Id,
                Abbrevation = c.Abbrevation,
                FullName = c.FullName,
                Region = c.Region,
                IndustrySegment = c.IndustrySegment,
                AccountCreationDate = c.AccountCreationDate,
                Notes = c.Notes,
                Status = c.Status,
                SoldServices = c.SoldServices.Select(s => new EditSoldServiceDto
                {
                    Id = s.Id,
                    ServiceName = s.ServiceName,
                    SaleDate = s.SaleDate
                }).ToList(),
                Associates = c.Associates.Select(a => new EditAssociateDto
                {
                    Id = a.Id,
                    AssociateName = a.AssociateName,
                    Role = a.Role,
                    ContactInformation = a.ContactInformation
                }).ToList()
            }).ToList();

            var totalPages = (int)Math.Ceiling(totalCount / (double)pagination.pageSize);

            return new PaginatedResult<EditCustomerDto>
            {
                PageNumber = pagination.pageNumber,
                PageSize = pagination.pageSize,
                TotalCount = totalCount,
                TotalPages = totalPages,
                Items = customerDto
            };
        }

        public async Task<List<CustomerDetailsDto>> SearchCustomers(string searchTearm)
        {
            try
            {
                searchTearm = searchTearm.ToLower();

                var query = _appDataContext.CustomerDetails
                    .Include(c => c.SoldServices)
                    .Include(c => c.Associates)
                    .AsQueryable();
                if (!string.IsNullOrWhiteSpace(searchTearm))
                {
                    query = query.Where(c => c.Abbrevation.Contains(searchTearm) || c.FullName.Contains(searchTearm));
                }
                var customers = await query.ToListAsync();

                return customers.Select(c => new CustomerDetailsDto
                {
                    Abbrevation = c.Abbrevation,
                    FullName = c.FullName,
                    Region = c.Region,
                    IndustrySegment = c.IndustrySegment,
                    AccountCreationDate = c.AccountCreationDate,
                    Notes = c.Notes,
                    Status = c.Status,
                    SoldServices = c.SoldServices.Select(s => new SoldServiceDto()
                    {
                        Id = s.Id,
                        ServiceName = s.ServiceName,
                        SaleDate = s.SaleDate,
                    }).ToList(),
                    Associates = c.Associates.Select(a => new AssociateDto()
                    {
                        Id = c.Id,
                        AssociateName = a.AssociateName,
                        Role = a.Role,
                        ContactInformation = a.ContactInformation
                    }).ToList()
                }).ToList();

                var response = new ApiResponse()
                {
                    Statuscode = Convert.ToInt32(HttpStatusCode.OK),
                    Data = customers,
                    Success = true
                };
                //return customers;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
