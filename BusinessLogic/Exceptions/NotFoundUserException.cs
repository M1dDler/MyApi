using System.Net;

namespace BusinessLogic.Exceptions
{
    public class NotFoundUserException : BaseException
    {
        public NotFoundUserException() : base("User not found!", HttpStatusCode.NotFound) { }
    }

}
