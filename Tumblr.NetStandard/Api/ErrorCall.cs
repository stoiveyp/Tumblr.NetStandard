using System.Net;

namespace Tumblr.NetStandard.Api
{
    public class ErrorCall
    {
        private const string LoggedInCallMadeAnonymouslyText = "Unable to get this data when not logged in";

        public static ApiResponse<T> NetworkError<T>()
        {
            //TECHDEBT: String localisation
            return new ApiResponse<T> { Success = false,Meta = new ResponseMetaData{Code=HttpStatusCode.InternalServerError,Message="Problem connecting to Tumblr. Please try again"}, Response = default};
        }

        public static ApiResponse<T> Unknown<T>()
        {
            return new ApiResponse<T> { Success = false,Meta = new ResponseMetaData{Code=HttpStatusCode.InternalServerError,Message="Unknown error. Please try again"}, Response = default};
        }

        public static ApiResponse<T> NotLoggedIn<T>()
        {
            return new ApiResponse<T> { Success = false, Meta = new ResponseMetaData { Code = HttpStatusCode.InternalServerError, Message = LoggedInCallMadeAnonymouslyText }, Response = default };
        }
    }
}