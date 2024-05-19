using System.Reflection;
using System;
using System.Collections.Generic;

namespace UserDomainServer.Security.Exceptions
{
    public static class ExceptionExtensions
    {
        public const string MESSAGE_ID = "MessageID";
        public const string INVARIANT_MESSAGE = "InvariantMessage";
        public const string INVARIANT_MESSAGE_ARGS = "InvariantMessageArgs";

        private const string SESSION_ID = "SessionId";
        private const string SERVER = "ServerName";
        private const string DATABASE = "DatabaseName";
        private const string COMMANDTEXT = "CommandText";
        private const string PARAMETERS = "Params";
        private const string ERROR_NUMBER = "ErrorNumber";

        public static Exception WithInvariantLog(this Exception exception, string invariantMessage, params object[] invariantMessageArgs)
        {
            exception.Data[INVARIANT_MESSAGE] = invariantMessage;
            if (invariantMessageArgs != null)
            {
                for (int i = 0; i < invariantMessageArgs.Length; i++)
                    exception.Data[INVARIANT_MESSAGE_ARGS + i] = invariantMessageArgs[i];
            }
            return exception;
        }

        public static Exception WithDatabaseInformation(this Exception exception, Guid sessionId, string serverName, string databaseName, string commandText, IEnumerable<ParameterInfo> parameters, string errorNumber)
        {
            exception.Data[SESSION_ID] = sessionId;
            exception.Data[SERVER] = serverName;
            exception.Data[DATABASE] = databaseName;
            exception.Data[COMMANDTEXT] = commandText;
            exception.Data[PARAMETERS] = parameters;
            exception.Data[ERROR_NUMBER] = errorNumber;
            return exception;
        }

        public static Exception WithInvariantLog(this Exception exception, MessageId messageId, string invariantMessage, params object[] invariantMessageArgs)
        {
            exception.Data[MESSAGE_ID] = messageId;

            return WithInvariantLog(exception, invariantMessage, invariantMessageArgs);
        }

        public static MessageId GetMessageId(this Exception exception)
        {
            if (exception.Data.Contains(MESSAGE_ID))
                return (MessageId)exception.Data[MESSAGE_ID];
            else
                return MessageId.NotSpecified;
        }

        public static string GetInvariantMessage(this Exception exception)
        {
            return GetProperty<string>(exception, INVARIANT_MESSAGE);
        }

        private static T GetProperty<T>(Exception exception, string propertyName)
        {
            if (exception.Data.Contains(propertyName))
                return (T)exception.Data[propertyName];
            else
                return default;
        }

        public static object[] GetInvariantMessageArgs(this Exception exception)
        {
            List<object> args = new List<object>();
            int i = 0;
            while (exception.Data.Contains(INVARIANT_MESSAGE_ARGS + i))
            {
                args.Add(exception.Data[INVARIANT_MESSAGE_ARGS + i]);
                i++;
            }

            return args.ToArray();

        }

        public static void GetDatabaseInformation(this Exception exception, out Guid sessionId, out string serverName, out string databaseName, out string commandText, out IEnumerable<ParameterInfo> parameters, out string errorNumber)
        {
            sessionId = GetProperty<Guid>(exception, SESSION_ID);
            serverName = GetProperty<string>(exception, SERVER);
            databaseName = GetProperty<string>(exception, DATABASE);
            commandText = GetProperty<string>(exception, COMMANDTEXT);
            parameters = GetProperty<IEnumerable<ParameterInfo>>(exception, PARAMETERS);
            errorNumber = GetProperty<string>(exception, ERROR_NUMBER);
        }
    }
}
