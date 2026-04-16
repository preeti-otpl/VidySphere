using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VidySphere.Domain.Entities
{
    public class User : BaseEntity
    {
        // Basic Info

        public string Name
        {
            get => $"{FirstName} {LastName}";
            set
            {
                var parts = value.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                FirstName = parts.Length > 0 ? parts[0] : "";
                LastName = parts.Length > 1 ? parts[1] : "";
            }
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        // Authentication
        public string PasswordHash { get; set; }

        // Role (Admin, Instructor, Student)
        public string Role { get; set; }

        // Tenant Mapping (VERY IMPORTANT)
        public int TenantId { get; set; }
        public Tenant Tenant { get; set; }

        // Profile
        public string ProfileImageUrl { get; set; }
        public DateTime? DateOfBirth { get; set; }

        // Status
        public bool IsActive { get; set; }
        public bool IsEmailVerified { get; set; }

        // Security
        public int FailedLoginAttempts { get; set; }
        public DateTime? LastLoginAt { get; set; }
    }
}
