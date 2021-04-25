namespace API.Errors
{
    public class ErrorException : ErrorResponse
    {
        public string Trace { get; set; }

        public ErrorException(int code, string message = null, string trace = null) 
            : base(code, message)
        {
            Trace = trace;
        }
    }
}