namespace TalabatG02.APIs.Errors
{
    public class ApiValidationErrorResponse:ApiErrorResponse //StatisCode=>Message
    {
        public IEnumerable<string> Errors { get; set; }
        public ApiValidationErrorResponse():base(400)
        {
            Errors = new List<string>();
        }
    }
}
