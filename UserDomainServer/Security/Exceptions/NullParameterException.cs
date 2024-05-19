namespace UserDomainServer.Security.Exceptions
{
    public class NullParameterException : Exception
    {
        public NullParameterException()
        {

        }

        public NullParameterException(string message)
        : base(message)
        {
        }

        public NullParameterException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
