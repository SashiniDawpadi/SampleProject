using Dapper;
using SampleProject.Model;
using SampleProject.Repository.Interfaces;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Threading.Tasks;
using System.Xml.Linq;

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
                    var results =await connection.QueryAsync<Student>("SelectSP", para, commandType: CommandType.StoredProcedure);
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

        public async Task<BaseResponse> DeleteStudent(string StudentId)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    DynamicParameters para = new DynamicParameters();
                    para.Add("@SId", StudentId);
                   

                    var results = await connection.QueryAsync<Student>("DeleteStudentSP", para, commandType: CommandType.StoredProcedure);
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

        public async Task<BaseResponse> AddStudent(Student student)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    Console.WriteLine(student.StudentId);
                    Console.WriteLine(student.fName);
                    Console.WriteLine(student.lName);
                    Console.WriteLine(student.DateOfBirth);
                    Console.WriteLine(student.Address);


                    DynamicParameters para = new DynamicParameters();
                    para.Add("@SId", student.StudentId);
                    para.Add("@fName", student.fName);
                    para.Add("@lName", student.lName);
                    para.Add("@DateOfBirth", student.DateOfBirth);
                    para.Add("@Address", student.Address);

                    

                    var results = await connection.QueryAsync<Student>("AddStudentSP", para, commandType: CommandType.StoredProcedure);
                    Console.WriteLine("\n" + results + "\n");
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


        public async Task<BaseResponse> UpdateStudent(string studentId , Student studentDetails)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    DynamicParameters para = new DynamicParameters();
                    para.Add("@SId", studentId);
                    para.Add("@fName", studentDetails.fName);
                    para.Add("@lName", studentDetails.lName);
                    para.Add("@DOB", studentDetails.DateOfBirth);
                    para.Add("@Address", studentDetails.Address);



                    var results = await connection.QueryAsync<Student>("UpdateStudentSP", para, commandType: CommandType.StoredProcedure);
                    Console.WriteLine("\n" + results + "\n");
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
