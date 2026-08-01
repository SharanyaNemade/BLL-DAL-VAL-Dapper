using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using EmployeeManagement.Data;
using EmployeeManagement.DAL;
using EmployeeManagement.Entity;


namespace EmployeeManagement.DAL
{
    public class DepartmentDAL
    {
        private readonly IDbConnection db;

        public DepartmentDAL()
        {
            db = new DapperContext().GetConnection();
        }

        #region Create

        public async Task<string> CreateDepartmentAsync(CreateDepartmentRequest request)
        {
            var parameters = new DynamicParameters();

            parameters.Add("@DepartmentCode", request.DepartmentCode);
            parameters.Add("@DepartmentName", request.DepartmentName);
            parameters.Add("@DisplayOrder", request.DisplayOrder);
            parameters.Add("@IsActive", request.IsActive);
            parameters.Add("@UserID", request.UserId);
            parameters.Add("@IPAddress", request.IPAddress);

            parameters.Add("@Output",
                dbType: DbType.String,
                size: 500,
                direction: ParameterDirection.Output);

            await db.ExecuteAsync(
                "Department_Create",
                parameters,
                commandType: CommandType.StoredProcedure);

            return parameters.Get<string>("@Output");
        }

        #endregion

        #region Update

        public async Task<string> UpdateDepartmentAsync(UpdateDepartmentRequest request)
        {
            var parameters = new DynamicParameters();

            parameters.Add("@DepartmentID", request.DepartmentID);
            parameters.Add("@DepartmentCode", request.DepartmentCode);
            parameters.Add("@DepartmentName", request.DepartmentName);
            parameters.Add("@DisplayOrder", request.DisplayOrder);
            parameters.Add("@IsActive", request.IsActive);
            parameters.Add("@UserID", request.UserId);
            parameters.Add("@IPAddress", request.IPAddress);

            parameters.Add("@Output",
                dbType: DbType.String,
                size: 500,
                direction: ParameterDirection.Output);

            await db.ExecuteAsync(
                "Department_Update",
                parameters,
                commandType: CommandType.StoredProcedure);

            return parameters.Get<string>("@Output");
        }

        #endregion

        #region Delete

        public async Task<string> DeleteDepartmentAsync(DeleteDepartmentRequest request)
        {
            var parameters = new DynamicParameters();

            parameters.Add("@DepartmentID", request.DepartmentID);
            parameters.Add("@UserID", request.UserId);
            parameters.Add("@IPAddress", request.IPAddress);

            parameters.Add("@Output",
                dbType: DbType.String,
                size: 500,
                direction: ParameterDirection.Output);

            await db.ExecuteAsync(
                "Department_Delete",
                parameters,
                commandType: CommandType.StoredProcedure);

            return parameters.Get<string>("@Output");
        }

        #endregion

        #region Get By Id

        public async Task<GetDepartmentByIdResponse?> GetDepartmentByIdAsync(GetDepartmentByIdRequest request)
        {
            var parameters = new DynamicParameters();

            parameters.Add("@DepartmentID", request.DepartmentID);

            parameters.Add("@Output",
                dbType: DbType.String,
                size: 500,
                direction: ParameterDirection.Output);

            var result = await db.QueryFirstOrDefaultAsync<GetDepartmentByIdResponse>(
                "Department_GetById",
                parameters,
                commandType: CommandType.StoredProcedure);

            return result;
        }

        #endregion

        #region Get List

        public async Task<GetDepartmentListResult> GetDepartmentListAsync(GetDepartmentListRequest request)
        {
            var parameters = new DynamicParameters();

            parameters.Add("@DepartmentCode", request.DepartmentCode);
            parameters.Add("@DepartmentName", request.DepartmentName);
            parameters.Add("@IsActive", request.IsActive);
            parameters.Add("@PageNumber", request.PageNumber);
            parameters.Add("@PageSize", request.PageSize);

            parameters.Add("@RowsCount",
                dbType: DbType.Int32,
                direction: ParameterDirection.Output);

            parameters.Add("@Output",
                dbType: DbType.String,
                size: 500,
                direction: ParameterDirection.Output);

            var result = await db.QueryAsync<GetDepartmentListResponse>(
                "Department_GetList",
                parameters,
                commandType: CommandType.StoredProcedure);

            return new GetDepartmentListResult
            {
                DepartmentList = result.ToList(),
                RowsCount = parameters.Get<int>("@RowsCount"),
                Output = parameters.Get<string>("@Output")
            };
        }

        #endregion
    }
}
