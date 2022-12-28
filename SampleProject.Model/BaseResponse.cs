using System;
using System.Collections.Generic;
using System.Text;

namespace SampleProject.Model
{
    public class BaseResponse
    {
        public bool Success { get; set; } //whether success or not as true or false
        public string Message { get; set; }// needed message
        public string ErrorType { get; set; }
        public object Data { get; set; }//result that should be send
        public int ExceptionNumber { get; set; } // exception no to be send

        //we can send these five responses to the font end 
    }

    public class ErrorResponse
    {
        public string Message { get; set; }// needed message
    }
}
