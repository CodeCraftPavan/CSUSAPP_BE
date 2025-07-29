// <copyright file="ICustomerService.cs" company="Canarys Automations Ltd">
// Copyright (c) Canarys Automations Ltd. All rights reserved.
// </copyright>

using CSUSAPP.Common.DTO;
using CSUSAPP.Services.DTO;

namespace CSUSAPP.Services.Interfaces
{
    /// <summary>
    /// Interface for Customer Service.
    /// </summary>
    public interface ICustomerService
    {
        /// <summary>
        /// Add a new customer.
        /// </summary>
        /// <param name="request">request.</param>
        /// <returns>It returns ApiResponse.</returns>
        public Task<ApiResponse> AddCustomer(CustomerDetailsDto request);

        /// <summary>
        /// Edit a new customer.
        /// </summary>
        /// <param name="request">request.</param>
        /// <param name="userId">userId.</param>
        /// <returns>It returns ApiResponse.</returns>
        public Task<ApiResponse> EditCustomer(EditCustomerDto request, Guid userId);

        /// <summary>
        /// Get Customers.
        /// </summary>
        /// <param name="pagination">pagination.</param>
        /// <returns>It returns Paginated Customer response.</returns>
        public Task<PaginatedResult<EditCustomerDto>> GetCustomers(PaginationDTO pagination);

        /// <summary>
        /// Search Customers.
        /// </summary>
        /// <param name="searchTearm">searchTearm.</param>
        /// <returns>It returns list of Customer details.</returns>
        public Task<List<CustomerDetailsDto>> SearchCustomers(string searchTearm);
    }
}