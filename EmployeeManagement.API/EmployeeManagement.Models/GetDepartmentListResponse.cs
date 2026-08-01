using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Entity
{
    public class GetDepartmentListResponse
    {
        public int DepartmentID { get; set; }

        public string? DepartmentCode { get; set; }

        public string? DepartmentName { get; set; }

        public short DisplayOrder { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}
