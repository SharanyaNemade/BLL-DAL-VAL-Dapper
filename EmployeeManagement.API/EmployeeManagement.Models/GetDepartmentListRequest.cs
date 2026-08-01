using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Entity
{
    public class GetDepartmentListRequest
    {
        public string? DepartmentCode { get; set; }

        public string? DepartmentName { get; set; }

        public string? UserId { get; set; }

        public int? IsActive { get; set; }

        public int PageNumber { get; set; } = 1;

        public int PageSize { get; set; } = 10;
    }
}
