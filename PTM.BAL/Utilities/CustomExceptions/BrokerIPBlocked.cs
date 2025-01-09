using System.Net;

namespace PTM.BLL.Utilities.CustomExceptions
{
    public class BrokerIPBlocked : Exception
    {
        public BrokerIPBlocked()
        {
                
        }
        public BrokerIPBlocked(string message)
            : base(message)
        {

        }

        public BrokerIPBlocked(string message, Exception inner)
         : base(message,inner)
        {

        }
    }
}
