// <copyright file="PaginationDTO.cs" company="Canarys Automations Ltd">
// Copyright (c) Canarys Automations Ltd. All rights reserved.
// </copyright>

namespace CSUSAPP.Common.DTO
{
    /// <summary>
    /// Represents pagination parameters for API requests.
    /// </summary>
    public class PaginationDTO
    {
        /// <summary>
        /// Gets or sets the page number for the request.
        /// </summary>
        public int PageNumber { get; set; } = 1;

        /// <summary>
        /// Gets or sets the number of items per page for the request.
        /// </summary>
        public int PageSize { get; set; } = 10;
    }

    /// <summary>
    /// Represents a paginated result for API responses.
    /// </summary>
    /// <typeparam name="T">T.</typeparam>
    public class PaginatedResult<T>
    {
        /// <summary>
        /// Gets or sets the page number of the result.
        /// </summary>
        public int PageNumber { get; set; }

        /// <summary>
        /// Gets or sets the number of items per page in the result.
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// Gets or sets the total number of items across all pages.
        /// </summary>
        public int TotalCount { get; set; }

        /// <summary>
        /// Gets or sets the total number of pages available based on the total count and page size.
        /// </summary>
        public int TotalPages { get; set; }

        /// <summary>
        /// Gets or sets the list of items for the current page.
        /// </summary>
        public List<T> Items { get; set; }
    }
}