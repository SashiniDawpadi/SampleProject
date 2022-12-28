using Dapper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using SampleProject.Model;
using SampleProject.Repository.Interfaces;

namespace SampleProject.Repository
{
    public class UserService : IUserRepository
    {

        private readonly string _connectionString;
        public UserService(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<BaseResponse> SelectValidUser(string UserName, string NICNo)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    DynamicParameters para = new DynamicParameters();

                    para.Add("@UserName", UserName);
                    para.Add("@NICNo", NICNo);
                    var results = await connection.QueryAsync<User>("[wal].[SelectUserDummy]", para, commandType: CommandType.StoredProcedure);

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
    }
}
