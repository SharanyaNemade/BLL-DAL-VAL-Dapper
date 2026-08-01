using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Entity
{
    public class GetDepartmentListResult
    {
        public List<GetDepartmentListResponse> DepartmentList { get; set; } = new();

        public int RowsCount { get; set; }

        public string? Output { get; set; }
    }
}
