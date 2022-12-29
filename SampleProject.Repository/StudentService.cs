using Dapper;
using SampleProject.Model;
using SampleProject.Repository.Interfaces;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace SampleProject.Repository
{
    public class StudentService : IStudentRepository
    {
        private readonly string _connectionString;

        public StudentService(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<BaseResponse> SelectById(string StudentId)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    DynamicParameters para = new DynamicParameters();

                    para.Add("@SId", StudentId);
                    var results =await connection.QueryAsync<Student>("SelectByIdSP", para, commandType: CommandType.StoredProcedure);
                    return new BaseResponseService().GetSuccessResponse(results);
                }
            }
            catch (SqlException ex)
            {
                return new BaseResponseService().GetErrorResponse(ex);
            }
            catch (Exception ex)
            {
                return new BaseResponseService().GetErrorResponse(ex);
            }
        }
        public async Task<BaseResponse> SelectAllStudents()
        {
            try
            {
                using(var connection = new SqlConnection(_connectionString))
                {
                    DynamicParameters para = new DynamicParameters();

                    var results = await connection.QueryAsync<Student>("SelectSP", para, commandType: CommandType.StoredProcedure);
                    return new BaseResponseService().GetSuccessResponse(results);
                }
            }
            catch(SqlException ex)
            {
                return new BaseResponseService().GetErrorResponse(ex);
            }
            catch(Exception ex)
            {
                return new BaseResponseService().GetErrorResponse(ex);
            }
        }
    }
}
