using System.Net;

namespace PTM.BLL.Utilities.CustomExceptions
{
    public class UserPasswordExpiredException : Exception
    {
        public UserPasswordExpiredException()
        {

        }
        public UserPasswordExpiredException(string message)
       : base(message)
        {

        }

        public UserPasswordExpiredException(string message, Exception inner)
      : base(message, inner)
        {

        }
    }
}
