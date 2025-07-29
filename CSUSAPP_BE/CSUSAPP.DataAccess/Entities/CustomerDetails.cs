// <copyright file="CustomerDetails.cs" company="Canarys Automations Ltd">
// Copyright (c) Canarys Automations Ltd. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSUSAPP.DataAccess.Entities
{
    /// <summary>
    /// Represents the customer details in the application.
    /// </summary>
    [Table("customer_details")]
    public class CustomerDetails
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
        /// Gets or sets the contact information for the customer.
        /// </summary>
        public string Region { get; set; }

        /// <summary>
        /// Gets or sets the contact information for the customer.
        /// </summary>
        public IndSegment IndustrySegment { get; set; }

        /// <summary>
        /// Gets or sets the contact information for the customer.
        /// </summary>
        public DateTime AccountCreationDate { get; set; }

        // check with possible sales property

        /// <summary>
        /// Gets or sets the notes for the customer.
        /// </summary>
        public string Notes { get; set; }

        /// <summary>
        /// Gets or sets the status of the customer.
        /// </summary>
        public Status Status { get; set; }

        // Navigation Properties

        /// <summary>
        /// Gets or sets the collection of sold services associated with the customer.
        /// </summary>
        public ICollection<SoldService> SoldServices { get; set; }

        /// <summary>
        /// Gets or sets the collection of associates associated with the customer.
        /// </summary>
        public ICollection<Associates> Associates { get; set; }
    }

    /// <summary>
    /// Represents the industry segment of a customer in the application.
    /// </summary>
    public enum IndSegment
    {
        Main,
        Sub,
        SubSub,
    }

    /// <summary>
    /// Represents the status of a customer in the application.
    /// </summary>
    public enum Status
    {
        Active,
        Dormant,
        Status,
        Lost,
        Rejected,
        Unknown,
    }
}
