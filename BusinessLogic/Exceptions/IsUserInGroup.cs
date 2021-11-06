using System.Net;

namespace BusinessLogic.Exceptions
{
    internal class IsUserInGroup : BaseException
    {
        public IsUserInGroup() : base("User already added", HttpStatusCode.Found) { }
    }
}
