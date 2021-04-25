using System.Collections.Generic;

namespace API.Errors
{
    public class ErrorResponseValidate : ErrorResponse
    {
        public IEnumerable<string> Errors { get; set; }

        public ErrorResponseValidate() : base(400)
        {

        }        
    }
}