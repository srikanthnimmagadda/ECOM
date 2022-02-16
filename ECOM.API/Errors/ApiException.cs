namespace ECOM.API.Errors
{
    public class ApiException : ApiResponse
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="statusCode"></param>
        /// <param name="message"></param>
        /// <param name="details"></param>
        public ApiException(int statusCode, string message = null, string details = null)
            : base(statusCode, message)
        {
            Details = details;
        }

        /// <summary>
        /// 
        /// </summary>
        public string Details { get; set; }
    }
}