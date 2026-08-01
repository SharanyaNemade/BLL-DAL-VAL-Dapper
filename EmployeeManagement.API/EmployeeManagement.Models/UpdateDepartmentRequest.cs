using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EmployeeManagement.Entity
{
    public class UpdateDepartmentRequest
    {
        public int DepartmentID { get; set; }

        public string? DepartmentCode { get; set; }

        public string? DepartmentName { get; set; }

        public short DisplayOrder { get; set; }

        public bool IsActive { get; set; }

        public string? UserId { get; set; }

        [JsonIgnore]
        public string? IPAddress { get; set; }
    }
}
