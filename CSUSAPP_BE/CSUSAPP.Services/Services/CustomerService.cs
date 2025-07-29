// <copyright file="CustomerService.cs" company="Canarys Automations Ltd">
// Copyright (c) Canarys Automations Ltd. All rights reserved.
// </copyright>

using CSUSAPP.Common.DTO;
using CSUSAPP.DataAccess.DataContext;
using CSUSAPP.DataAccess.Entities;
using CSUSAPP.Services.DTO;
using CSUSAPP.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Net;

namespace CSUSAPP.Services.Services
{
    /// <summary>
    /// Implementation of the ICustomer Service.
    /// </summary>
    public class CustomerService : ICustomerService
    {
        private readonly AppDataContext _appDataContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerService"/> class.
        /// </summary>
        /// <param name="appDataContext">appDataContext.</param>
        public CustomerService(AppDataContext appDataContext)
        {
            _appDataContext = appDataContext;
        }

        /// <inheritdoc/>
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
                        Status = s.Status,
                    }).ToList(),
                    Associates = request.Associates.Select(s => new Associates
                    {
                        AssociateName = s.AssociateName,
                        Role = s.Role,
                        ContactInformation = s.ContactInformation,
                    }).ToList(),
                };

                _appDataContext.Add(newCustomer);
                await _appDataContext.SaveChangesAsync();
                response.Statuscode = Convert.ToInt32(HttpStatusCode.OK);
                response.Data = request;
            }
            catch (Exception)
            {
                throw;
            }

            return response;
        }

        /// <inheritdoc/>
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

            var userRole = await _appDataContext.UsersData.Where(x => x.UserId == userId).Select(x => x.Roles).FirstOrDefaultAsync();
            if (userRole == Roles.Admin)
            {
                adminCheck = true;
            }

            var editCustomer = await _appDataContext.CustomerDetails
                    .Include(c => c.SoldServices)
                    .Include(c => c.Associates)
                    .FirstOrDefaultAsync(c => c.Id == request.Id);
            if (editCustomer == null)
            {
                throw new Exception("Customer not found.");
            }

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
                            Status = soldService.Staus,
                        });
                    }
                }
            }

            if (!associateEmptyCheck)
            {
                foreach (var associate in request.Associates)
                {
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
                            ContactInformation = associate.ContactInformation,
                        });
                    }
                }
            }

            await _appDataContext.SaveChangesAsync();
            var response = new ApiResponse()
            {
                Statuscode = Convert.ToInt32(HttpStatusCode.OK),
                Data = editCustomer,
                Success = true,
            };
            return response;
        }

        /// <inheritdoc/>
        public async Task<PaginatedResult<EditCustomerDto>> GetCustomers(PaginationDTO pagination)
        {
            var totalCount = await _appDataContext.CustomerDetails.CountAsync();
            var customers = await _appDataContext.CustomerDetails
                .Include(c => c.SoldServices)
                .Include(c => c.Associates)
                .OrderBy(c => c.Id)
                .Skip((pagination.PageNumber - 1) * pagination.PageSize)
                .Take(pagination.PageSize)
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
                    SaleDate = s.SaleDate,
                }).ToList(),
                Associates = c.Associates.Select(a => new EditAssociateDto
                {
                    Id = a.Id,
                    AssociateName = a.AssociateName,
                    Role = a.Role,
                    ContactInformation = a.ContactInformation,
                }).ToList(),
            }).ToList();

            var totalPages = (int)Math.Ceiling(totalCount / (double)pagination.PageSize);

            return new PaginatedResult<EditCustomerDto>
            {
                PageNumber = pagination.PageNumber,
                PageSize = pagination.PageSize,
                TotalCount = totalCount,
                TotalPages = totalPages,
                Items = customerDto,
            };
        }

        /// <inheritdoc/>
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
                        ContactInformation = a.ContactInformation,
                    }).ToList(),
                }).ToList();

                var response = new ApiResponse()
                {
                    Statuscode = Convert.ToInt32(HttpStatusCode.OK),
                    Data = customers,
                    Success = true,
                };
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
