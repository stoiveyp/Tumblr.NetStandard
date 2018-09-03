using System.Net;
using Tumblr.NetStandard.Models;

namespace Tumblr.NetStandard
{
    public class ErrorCall
    {
        private const string LoggedInCallMadeAnonymouslyText = "Unable to get this data when not logged in";

        public static ApiResponse<T> NetworkError<T>()
        {
            //TECHDEBT: String localisation
            return new ApiResponse<T> { Success = false,Meta = new ResponseMetaData{Code=HttpStatusCode.InternalServerError,Message="Problem connecting to Tumblr. Please try again"}, Response = default(T)};
        }

        public static ApiResponse<T> Unknown<T>()
        {
            return new ApiResponse<T> { Success = false,Meta = new ResponseMetaData{Code=HttpStatusCode.InternalServerError,Message="Unknown error. Please try again"}, Response = default(T)};
        }

        public static ApiResponse<T> NotLoggedIn<T>()
        {
            return new ApiResponse<T> { Success = false, Meta = new ResponseMetaData { Code = HttpStatusCode.InternalServerError, Message = LoggedInCallMadeAnonymouslyText }, Response = default(T) };
        }
    }
}