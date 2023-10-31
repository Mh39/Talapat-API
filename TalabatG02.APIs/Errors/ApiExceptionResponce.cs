namespace TalabatG02.APIs.Errors
{
    public class ApiExceptionResponce:ApiErrorResponse
    {
        private readonly int statusCode;

        public string? Details { get; set; }
        public ApiExceptionResponce(int statusCode,string? Message=null,string? Details=null):base(statusCode,Message)
        {
            this.Details = Details;
        }
    }
}
