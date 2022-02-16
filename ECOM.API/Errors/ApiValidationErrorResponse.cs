namespace ECOM.API.Errors
{
    public class ApiValidationErrorResponse : ApiResponse
    {
        /// <summary>
        /// 
        /// </summary>
        public ApiValidationErrorResponse() : base(400)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        public IEnumerable<string> Errors { get; set; }
    }
}