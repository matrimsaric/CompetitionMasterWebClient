using ServerCommonModule.Database.Interfaces;
using ServerCommonModule.Database;
using System.Data.Common;
using System.Reflection;
using System.Xml;
using UserDomainServer.Security.Exceptions;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;

namespace UserDomainServer.Middleware
{
    public class ErrorLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        //private readonly IEnvironmentParameters _environmentParameters;
        //private readonly ILogContextExtensions _logContextExtensions;
        private readonly ILogger<ErrorLoggingMiddleware> _logger;

        public ErrorLoggingMiddleware(RequestDelegate next, ILogger<ErrorLoggingMiddleware> logger)//, IEnvironmentParameters environmentParameters, ILogContextExtensions logContextExtensions
        {
            _next = next;
            //_environmentParameters = environmentParameters;
            //_logContextExtensions = logContextExtensions;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            // NOTE - we can handle different exception types here for the moment they are all calling essentially
            // identical sub methods but we could also report differently dependant on exception type.
            // this also pulls a large amount of generic error handling from the application
            try
            {
                await _next(context);
            }
            catch (DbException databaseException)
            {
                LogDatabaseException(databaseException);

                await HandleExceptionAsync(context, databaseException).ConfigureAwait(false);
            }
            //catch (LongRunningException longRunningException)
            //{
            //    LogException(longRunningException);

            //    await HandleLongRunningExceptionAsync(context, longRunningException).ConfigureAwait(false);
            //}
            catch (AggregateException aggregateException)
            {
                LogException(aggregateException);

                await HandleAggregateExceptionAsync(context, aggregateException).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                LogException(ex);

                await HandleExceptionAsync(context, ex).ConfigureAwait(false);
            }
        }

        private void LogDatabaseException(DbException databaseException)
        {
            //databaseException.GetDatabaseInformation(out Guid sessionId, out string serverName, out string databaseName, out string commandText, out IEnumerable<ParameterInfo> parameters, out string errorNumber);
            //string message = "{Action}: {ExceptionMessage}";

            //using (_logContextExtensions.PushProperty(DbUtility.SESSION_ID, sessionId))
            //using (_logContextExtensions.PushProperty(DbUtility.SERVER, serverName))
            //using (_logContextExtensions.PushProperty(DbUtility.DATABASE, databaseName))
            //using (_logContextExtensions.PushProperty(DbUtility.COMMANDTEXT, commandText))
            //using (_logContextExtensions.PushProperty(DbUtility.PARAMETERS, parameters, true))
            //using (_logContextExtensions.PushProperty(DbUtility.ERROR_NUMBER, errorNumber))
            //{
            //    _logger.LogError(databaseException, message, "Database Error", databaseException.Message);
            //}
        }

        private void LogException(Exception ex)
        {
            MessageId messageId = ex.GetMessageId();

            if (messageId == MessageId.NotSpecified)
            {
                string message = "{Action}: {ExceptionMessage}";

                _logger.LogError(ex, message, "Error", ex.Message);
            }
            else
            {
                string invariantMessage = ex.GetInvariantMessage();
                invariantMessage = "{Action}: " + invariantMessage;

                object[] invariantMessageArgs = ex.GetInvariantMessageArgs();
                if (invariantMessageArgs.Length > 0)
                {
                    List<object> invariantMessageArgsWithAction = new List<object>(invariantMessageArgs);
                    invariantMessageArgsWithAction.Insert(0, "Error");
                    invariantMessageArgs = invariantMessageArgsWithAction.ToArray();
                }
                else
                {
                    invariantMessageArgs = new object[1];
                    invariantMessageArgs[0] = "Error";
                }

                _logger.LogError(ex, invariantMessage, invariantMessageArgs);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";

            ExceptionViewModel returnException = GetExceptionViewModel(exception);

            context.Response.StatusCode = returnException.MessageId switch
            {
                MessageId.NoContent => StatusCodes.Status404NotFound,

                MessageId.AuthorizationTokenNotValid or
                MessageId.UserNotFound or
                MessageId.NullParameter or
                MessageId.Security => (int)StatusCodes.Status403Forbidden,

                _ => (int)StatusCodes.Status500InternalServerError,
            };
            string result = Serialize(returnException);

            return context.Response.WriteAsync(result);
        }

        private static string Serialize(ExceptionViewModel returnException)
        {
            DefaultContractResolver contractResolver = new DefaultContractResolver
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            };

            string result = JsonConvert.SerializeObject(returnException, new JsonSerializerSettings
            {
                ContractResolver = contractResolver,
                Formatting = Newtonsoft.Json.Formatting.Indented
            });
            return result;
        }

        //private Task HandleLongRunningExceptionAsync(HttpContext context, LongRunningException exception)
        //{
        //    context.Response.ContentType = "application/json";

        //    ExceptionViewModel returnException = GetExceptionViewModel(exception);

        //    context.Response.StatusCode = (int)StatusCodes.Status500InternalServerError;
        //    string result = Serialize(returnException);
        //    return context.Response.WriteAsync(result);
        //}

        private Task HandleAggregateExceptionAsync(HttpContext context, AggregateException exception)
        {
            context.Response.ContentType = "application/json";

            ExceptionViewModel returnException = GetExceptionViewModel(exception);

            context.Response.StatusCode = (int)StatusCodes.Status500InternalServerError;
            string result = Serialize(returnException);
            return context.Response.WriteAsync(result);
        }

        private ExceptionViewModel GetExceptionViewModel(Exception ex)
        {
            MessageId messageId = ex.GetMessageId();

            // ** 20220201 AQ 6530
            string msg = ex.Message;

            ExceptionViewModel exceptionViewModel = new ExceptionViewModel()
            {
                // could adjust this according to a setting as to showing detailed or friendly messages
                ClassName = ex.GetType().Name.Split('.').Reverse().First(),
                InnerException = null,
                Message = msg,
                StackTrace = null,
                MessageId = messageId,
            };

            //if (_environmentParameters.ShowVerboseErrors)
            //{
            //    exceptionViewModel.InnerException = ex.InnerException != null ? GetExceptionViewModel(ex.InnerException) : null;
            //    exceptionViewModel.StackTrace = ex.StackTrace != null ? ex.StackTrace.Split(Environment.NewLine).ToList() : null;
            //}
            return exceptionViewModel;

        }

        private ExceptionViewModel GetExceptionViewModel(AggregateException ex)
        {
            // aggregate exceptions can be large so flatten into a single exception before returning
            Exception master = ex.Flatten();

            MessageId messageId = MessageId.InternalError;

            List<ExceptionViewModel> multiList = new List<ExceptionViewModel>();

            for (int cnt = 0; cnt < ex.InnerExceptions.Count; cnt++)
            {
                multiList.Add(GetExceptionViewModel(ex.InnerExceptions[cnt]));
            }

            //if (_environmentParameters.ShowVerboseErrors)
            //{
            //    return new ExceptionViewModel()
            //    {
            //        // could adjust this according to a setting as to showing detailed or friendly messages
            //        ClassName = ex.GetType().Name.Split('.').Reverse().First(),
            //        InnerException = null,
            //        InnerExceptions = multiList,
            //        Message = ex.Message,
            //        StackTrace = ex.StackTrace != null ? ex.StackTrace.Split(Environment.NewLine).ToList() : null,
            //        MessageId = messageId,
            //    };
            //}
            //else
            //{
                return new ExceptionViewModel()
                {
                    // could adjust this according to a setting as to showing detailed or friendly messages
                    ClassName = ex.GetType().Name.Split('.').Reverse().First(),
                    InnerException = null,
                    InnerExceptions = multiList,
                    Message = ex.Message,
                    StackTrace = null,
                    MessageId = messageId,
                };
            //}

        }
    }




    public static class ExceptionMiddlewareExtensions
    {
        public static void UseCustomExceptionMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ErrorLoggingMiddleware>();
        }
    }
}
