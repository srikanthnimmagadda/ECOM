namespace ECOM.Core.Specifications
{
    public class ProductSpecParams
    {
        /// <summary>
        /// 
        /// </summary>
        private const int MaxPageSize = 50;

        /// <summary>
        /// 
        /// </summary>
        public int PageIndex { get; set; } = 1;

        /// <summary>
        /// 
        /// </summary>
        private int _pageSize = 5;

        /// <summary>
        /// 
        /// </summary>
        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = (value > MaxPageSize) ? MaxPageSize : value;
        }

        /// <summary>
        /// 
        /// </summary>
        public int? BrandId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? TypeId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Sort { get; set; }

        /// <summary>
        /// 
        /// </summary>
        private string _search;

        /// <summary>
        /// 
        /// </summary>
        public string Search
        {
            get => _search;
            set => _search = value.ToLower();
        }
    }
}
