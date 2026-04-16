using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VidySphere.Domain.Entities
{
    public class Tenant : BaseEntity
    {
        // Basic Info
        public string Name { get; set; }              // Organization Name
        public string Code { get; set; }              // Unique identifier (e.g., "TCS", "DU01")
        public string Description { get; set; }

        // Contact Details
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        // Address
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }

        // Branding
        public string LogoUrl { get; set; }
        public string WebsiteUrl { get; set; }

        // Subscription / Plan
        public string SubscriptionPlan { get; set; }  // Basic / Premium / Enterprise
        public DateTime SubscriptionStartDate { get; set; }
        public DateTime? SubscriptionEndDate { get; set; }

        // Status
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }

        // Multi-tenancy control
        public string SubDomain { get; set; }            // e.g., abc.lms.com
        public string Domain { get; set; }            // e.g., abc.lms.com
        public string DatabaseName { get; set; }      // If using DB per tenant

        // Navigation Properties (Important for real project)
      
    }
}
