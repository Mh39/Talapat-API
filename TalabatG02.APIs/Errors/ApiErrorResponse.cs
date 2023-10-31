namespace TalabatG02.APIs.Errors
{
    public class ApiErrorResponse
    {
        public int StatusCode { get; set; }
        public string? Message { get; set; }
        public ApiErrorResponse(int statusCode,string? message=null)
        {
            this.StatusCode = statusCode;
            Message = message ?? GetDefaultMessageForStatusCode(statusCode);
        }
        private string? GetDefaultMessageForStatusCode(int statusCode) 
        {
            return statusCode switch
            {
                400 => "A bad Request , You Have Made",
                401 => "Authorized, You Are Not",
                404 => "Resourses Not Found",
                500 => "There is Server Error",
                _ => null
            };

        }
    }
}
