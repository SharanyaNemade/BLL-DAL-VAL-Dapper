using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using EmployeeManagement.Data;
using EmployeeManagement.Entity;
using EmployeeManagement.Common;
using EmployeeManagement.DAL;


namespace EmployeeManagement.BLL
{
    public class DepartmentBLL
    {
        #region Create

        public async Task<ExpandoObject> CreateAsync(CreateDepartmentRequest request)
        {
            dynamic objDepartmentRes = new ExpandoObject();

            objDepartmentRes.resultStatus = MessageStatusEntity.fail;
            objDepartmentRes.httpStatusCode = 500;

            request.IPAddress = General.GetVisitorIPAddress();

            try
            {
                string result = await new DepartmentDAL().CreateDepartmentAsync(request);

                if (result == "Inserted")
                {
                    objDepartmentRes.resultStatus = MessageStatusEntity.success;
                    objDepartmentRes.httpStatusCode = 200;
                }

                objDepartmentRes.resultMessage = result;
            }
            catch (Exception ex)
            {
                objDepartmentRes.resultMessage = ex.Message;
            }

            return objDepartmentRes;
        }

        #endregion

        #region Update

        public async Task<ExpandoObject> UpdateAsync(UpdateDepartmentRequest request)
        {
            dynamic objDepartmentRes = new ExpandoObject();

            objDepartmentRes.resultStatus = MessageStatusEntity.fail;
            objDepartmentRes.httpStatusCode = 500;

            request.IPAddress = General.GetVisitorIPAddress();

            try
            {
                string result = await new DepartmentDAL().UpdateDepartmentAsync(request);

                if (result == "Updated")
                {
                    objDepartmentRes.resultStatus = MessageStatusEntity.success;
                    objDepartmentRes.httpStatusCode = 200;
                }

                objDepartmentRes.resultMessage = result;
            }
            catch (Exception ex)
            {
                objDepartmentRes.resultMessage = ex.Message;
            }

            return objDepartmentRes;
        }

        #endregion

        #region Delete

        public async Task<ExpandoObject> DeleteAsync(DeleteDepartmentRequest request)
        {
            dynamic objDepartmentRes = new ExpandoObject();

            objDepartmentRes.resultStatus = MessageStatusEntity.fail;
            objDepartmentRes.httpStatusCode = 500;

            request.IPAddress = General.GetVisitorIPAddress();

            try
            {
                string result = await new DepartmentDAL().DeleteDepartmentAsync(request);

                if (result == "Deleted")
                {
                    objDepartmentRes.resultStatus = MessageStatusEntity.success;
                    objDepartmentRes.httpStatusCode = 200;
                }

                objDepartmentRes.resultMessage = result;
            }
            catch (Exception ex)
            {
                objDepartmentRes.resultMessage = ex.Message;
            }

            return objDepartmentRes;
        }

        #endregion

        #region Get By Id

        public async Task<ExpandoObject> GetByIdAsync(GetDepartmentByIdRequest request)
        {
            dynamic objDepartmentRes = new ExpandoObject();

            objDepartmentRes.resultStatus = MessageStatusEntity.fail;
            objDepartmentRes.httpStatusCode = 500;

            try
            {
                var result = await new DepartmentDAL().GetDepartmentByIdAsync(request);

                if (result != null)
                {
                    objDepartmentRes.resultStatus = MessageStatusEntity.success;
                    objDepartmentRes.httpStatusCode = 200;
                    objDepartmentRes.resultMessage = "Record fetched successfully.";
                    objDepartmentRes.result = result;
                }
                else
                {
                    objDepartmentRes.resultMessage = "Department not found.";
                }
            }
            catch (Exception ex)
            {
                objDepartmentRes.resultMessage = ex.Message;
            }

            return objDepartmentRes;
        }

        #endregion

        #region Get List

        public async Task<ExpandoObject> GetListAsync(GetDepartmentListRequest request)
        {
            dynamic objDepartmentRes = new ExpandoObject();

            objDepartmentRes.resultStatus = MessageStatusEntity.fail;
            objDepartmentRes.httpStatusCode = 500;

            try
            {
                var result = await new DepartmentDAL().GetDepartmentListAsync(request);

                objDepartmentRes.resultStatus = MessageStatusEntity.success;
                objDepartmentRes.httpStatusCode = 200;
                objDepartmentRes.resultMessage = result.Output;

                objDepartmentRes.result = new
                {
                    departmentList = result.DepartmentList,
                    rowsCount = result.RowsCount
                };
            }
            catch (Exception ex)
            {
                objDepartmentRes.resultMessage = ex.Message;
            }

            return objDepartmentRes;
        }

        #endregion
    }
}
