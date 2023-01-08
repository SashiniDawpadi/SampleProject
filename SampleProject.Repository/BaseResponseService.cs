using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using SampleProject.Model;
using System.Security.Cryptography;
using System.Data.SqlClient;

namespace SampleProject.Repository
{
    public class BaseResponseService
    {
        public BaseResponse GetSuccessResponse()
        {
            return new BaseResponse() { Success = true, Message = "Success", ErrorType = "NA" };
        }

        public BaseResponse GetSuccessResponse(object data)
        {
            var serializeOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };
            string jsonString = System.Text.Json.JsonSerializer.Serialize(data, serializeOptions);
            return new BaseResponse() { Success = true, Message = "Success", ErrorType = "NA", Data = jsonString };

            //encryption disable.
            //return new BaseResponse() { Success = true, Message = "Success", ErrorType = "NA", Data = data };
        }

        public BaseResponse GetErrorResponse(SqlException ex)
        {
            ErrorResponse error = new ErrorResponse();
            error.Message = ex.Message;

          //  if (ex.Number == 50005)
           // {
                return new BaseResponse() { Success = false, Message = ex.Message, ErrorType = "VAL", Data = error, ExceptionNumber = ex.Number };
           // }

           // return GetErrorResponse((Exception)ex);
        }

        public BaseResponse GetErrorResponse(Exception ex)
        {
            return new BaseResponse() { Success = false, Message = "Action will be canceled!", ErrorType = "EX" };
        }

    }
}
