using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EngLabAPI.DTOs.Staff
{
    public class UpdateStaffDTO
    {
        public string? StaffCode { get; set; }
        public string? FullName { get; set; }

        public string? Gender { get; set; }

        public string? Email { get; set; }

        public string? PhoneNumber { get; set; }

        public string? Address { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public DateTime? HireDate { get; set; }

        public DateTime? EndDate { get; set; }

        public bool? IsActive { get; set; }

        public int RoleId { get; set; }
    }
}