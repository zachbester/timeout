using System;

namespace API.Errors
{
    public class ErrorResponse
    {
        public int Code { get; set; }
        public string Message { get; set; }

        public ErrorResponse(int code, string message = null)
        {
            Code = code;
            Message = message ?? GetDefaultMessage(code);
        }

        private string GetDefaultMessage(int code)
        {
            return code switch 
            {
                400 => "A bad request, you have made",
                401 => "Authorized, you are not",
                404 => "Resource found, it was not",
                500 => "Errors are the path to the dark side. Errors lead to anger. Anger leads to hate. Hate leads to career change",
                _   => null
            };
        }
    }
}