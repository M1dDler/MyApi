using System.Net;

namespace BusinessLogic.Exceptions
{
    public class GroupNotFoundException : BaseException
    {
        public GroupNotFoundException() : base("Group not found", HttpStatusCode.NotFound) { }
    }

}
