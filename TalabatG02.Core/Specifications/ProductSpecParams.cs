namespace TalabatG02.Core.Specifications
{
    public class ProductSpecParams
    {
        private const int MaxPageSize = 10;

        private int PageSize = 5;
        public int pageSize
        {
            get { return PageSize; }
            set { PageSize = value > MaxPageSize ? MaxPageSize : value; }
        }
        public int PageIndex { get; set; } = 1;

        public string? sort { get; set; }
        public int? brandid { get; set; }
        public int? typeid { get; set; }
        private string search { get; set; }
        public string? Search
        {
            get { return search; }
            set { search = value.ToLower(); }
        }

    }
}
