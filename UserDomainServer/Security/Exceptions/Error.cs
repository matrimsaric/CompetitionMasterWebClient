namespace UserDomainServer.Security.Exceptions
{
    public enum ErrorType
    {
        None = 0,
        Warning = 1,
        Error = 2,
    }


    public class Error
    {
        public int Code { get; set; }

        public bool RowError { get; set; }

        public ErrorType ErrorType { get; set; }

        public string Description { get; set; }

       
    }

    public class ExceptionViewModel
    {
        public string ClassName { get; set; }
        public string Message { get; set; }
        public ExceptionViewModel InnerException { get; set; }
        public List<ExceptionViewModel> InnerExceptions { get; set; }

        public List<string> StackTrace { get; set; }

        public MessageId MessageId { get; set; }

        public override string ToString()
        {
            string inner = String.Empty;
            if (InnerException != null)
            {
                inner = "InnerException: " + InnerException.ToString();
            }
            string stack = String.Empty;

            if (StackTrace != null)
            {
                stack = "StackTrace: ";
                for (int a = 0; a < StackTrace.Count; a++)
                {
                    stack += StackTrace[a];
                }

            }
            return $"{MessageId} {ClassName}{Environment.NewLine} Message:{Message} {Environment.NewLine} {stack} {Environment.NewLine}{Environment.NewLine} {inner}";

        }
    }
}
