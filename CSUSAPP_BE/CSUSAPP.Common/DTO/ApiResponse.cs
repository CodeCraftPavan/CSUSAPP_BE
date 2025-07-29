// <copyright file="ApiResponse.cs" company="Canarys Automations Ltd">
// Copyright (c) Canarys Automations Ltd. All rights reserved.
// </copyright>

namespace CSUSAPP.Common.DTO
{
    /// <summary>
    /// Represents a standard API response structure.
    /// </summary>
    public class ApiResponse
    {
        /// <summary>
        /// Gets or sets the Statuscode for the Response.
        /// </summary>
        public int Statuscode { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the API call was successful.
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// Gets or sets the data returned by the API call.
        /// </summary>
        public object Data { get; set; }

        /// <summary>
        /// Gets or sets the message associated with the API response.
        /// </summary>
        public string Message { get; set; }
    }
}