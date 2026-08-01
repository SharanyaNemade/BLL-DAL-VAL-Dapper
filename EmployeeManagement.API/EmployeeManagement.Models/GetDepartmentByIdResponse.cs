using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Entity
{
    public class GetDepartmentByIdResponse
    {
        public int DepartmentID { get; set; }

        public string? DepartmentCode { get; set; }

        public string? DepartmentName { get; set; }

        public short DisplayOrder { get; set; }

        public bool IsActive { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; }

        public int? ModifiedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}
