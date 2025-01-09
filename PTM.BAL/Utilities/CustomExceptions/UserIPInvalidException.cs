using System.Net;

namespace PTM.BLL.Utilities.CustomExceptions
{
    public class UserIPInvalidException : Exception
    {
        public UserIPInvalidException()
        {
                
        }
        public UserIPInvalidException(string message)
            : base(message)
        {

        }

        public UserIPInvalidException(string message, Exception inner)
         : base(message,inner)
        {

        }
    }
}
