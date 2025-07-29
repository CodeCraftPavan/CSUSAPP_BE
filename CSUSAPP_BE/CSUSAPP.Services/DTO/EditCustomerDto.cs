// <copyright file="EditCustomerDto.cs" company="Canarys Automations Ltd">
// Copyright (c) Canarys Automations Ltd. All rights reserved.
// </copyright>

using CSUSAPP.DataAccess.Entities;

namespace CSUSAPP.Services.DTO
{
    /// <summary>
    /// Represents the data transfer object for editing customer details.
    /// </summary>
    public class EditCustomerDto
    {
        /// <summary>
        /// Gets or sets the unique identifier for the customer details.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Gets or sets the abbreviation for the customer.
        /// </summary>
        public string Abbrevation { get; set; }

        /// <summary>
        /// Gets or sets the full name of the customer.
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// Gets or sets the region of the customer.
        /// </summary>
        public string Region { get; set; }

        /// <summary>
        /// Gets or sets the date when the customer account was created.
        /// </summary>
        public DateTime AccountCreationDate { get; set; }

        /// <summary>
        /// Gets or sets the industry segment of the customer.
        /// </summary>
        public IndSegment IndustrySegment { get; set; }

        /// <summary>
        /// Gets or sets the notes for the customer.
        /// </summary>
        public string Notes { get; set; }

        /// <summary>
        /// Gets or sets the status of the customer.
        /// </summary>
        public Status Status { get; set; }

        /// <summary>
        /// Gets or sets the collection of sold services associated with the customer.
        /// </summary>
        public List<EditSoldServiceDto> SoldServices { get; set; }

        /// <summary>
        /// Gets or sets the collection of associates associated with the customer.
        /// </summary>
        public List<EditAssociateDto> Associates { get; set; }
    }

    /// <summary>
    /// Represents the SoldService object for an associate.
    /// </summary>
    public class EditSoldServiceDto
    {
        /// <summary>
        /// Gets or sets the unique identifier for the sold service.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the service sold.
        /// </summary>
        public string ServiceName { get; set; }

        /// <summary>
        /// Gets or sets the date when the service was sold.
        /// </summary>
        public DateTime SaleDate { get; set; }

        /// <summary>
        /// Gets or sets the Status of the sold service.
        /// </summary>
        public ServiceStatus Staus { get; set; }
    }

    /// <summary>
    /// Represents the edit transfer object for an associate.
    /// </summary>
    public class EditAssociateDto
    {
        /// <summary>
        /// Gets or sets the unique identifier for the associate.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the associate.
        /// </summary>
        public string AssociateName { get; set; }

        /// <summary>
        /// Gets or sets the role of the associate.
        /// </summary>
        public Roles Role { get; set; }

        /// <summary>
        /// Gets or sets the contact information for the associate.
        /// </summary>
        public string ContactInformation { get; set; }
    }
}
