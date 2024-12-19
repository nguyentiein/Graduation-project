using FPM.Resourses.DTOs.Log.Request;
using FPM.Services.IServices;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;

namespace FPM.API.Controllers.Middlewares
{
    public sealed class RequestResponseLoggerMiddleware
    {
        #region Properties
        private readonly RequestDelegate _next;
        #endregion

        #region Constructor
        public RequestResponseLoggerMiddleware(RequestDelegate next)
        {
            this._next = next;
        }
        #endregion

        #region Method
        public async Task InvokeAsync(HttpContext httpContext, ILogService logService)
        {
            var log = logService.LogModel;

            log.RequestDateTimeUtc = DateTime.UtcNow;
            HttpRequest request = httpContext.Request;

            // Log
            log.TraceId = httpContext.TraceIdentifier;
            log.ClientIp = request.HttpContext.Connection.RemoteIpAddress?.ToString() ?? string.Empty;
            log.Node = RequestResponseLoggerOption.Name;

            // Request
            log.RequestMethod = request.Method;
            log.RequestPath = request.Path;
            log.RequestQuery = request.QueryString.ToString();
            log.RequestQueries = FormatQueries(request.QueryString.ToString());
            log.RequestHeaders = FormatHeaders(request.Headers);
            log.RequestBody = await ReadBodyFromRequest(request);
            log.RequestScheme = request.Scheme;
            log.RequestHost = request.Host.ToString();
            log.RequestContentType = request.ContentType ?? string.Empty;

            // Change HttpResponseStream (read-only) by MemoryStream (allow write)
            HttpResponse response = httpContext.Response;
            var originalResponseBody = response.Body;
            using var newResponseBody = new MemoryStream();
            response.Body = newResponseBody;

            // Call the next middleware in the pipeline
            try
            {
                await _next(httpContext);
            }
            catch (Exception exception)
            {
                // Exception: but was not managed at app.UseExceptionHandler() or by any middleware
                LogError(log, exception);
            }

            newResponseBody.Seek(0, SeekOrigin.Begin);
            var responseBodyText = await new StreamReader(response.Body).ReadToEndAsync();

            newResponseBody.Seek(0, SeekOrigin.Begin);
            await newResponseBody.CopyToAsync(originalResponseBody);

            // Response
            log.ResponseContentType = response.ContentType;
            log.ResponseStatus = response.StatusCode.ToString();
            log.ResponseHeaders = FormatHeaders(response.Headers);
            log.ResponseBody = responseBodyText;
            log.ResponseDateTimeUtc = DateTime.UtcNow;

            // Exception: but was managed at app.UseExceptionHandler() or by any middleware
            var contextFeature = httpContext.Features.Get<IExceptionHandlerPathFeature>();
            if (contextFeature != null && contextFeature.Error != null)
            {
                LogError(log, contextFeature.Error);
            }

            await logService.Logging();
        }

        #endregion


        #region Private work
        private void LogError(RequestResponseLogModel log, Exception exception)
        {
            Log.Error(exception, $"LogId: {log.LogId}");

            log.ExceptionMessage = exception.Message;
            log.ExceptionStackTrace = exception.StackTrace;
        }

        private Dictionary<string, string> FormatHeaders(IHeaderDictionary headers)
        {
            Dictionary<string, string> pairs = new();
            foreach (var header in headers)
                pairs.Add(header.Key, header.Value);

            return pairs;
        }

        private List<KeyValuePair<string, string>> FormatQueries(string queryString)
        {
            List<KeyValuePair<string, string>> pairs = new();
            string key, value;
            foreach (var query in queryString.TrimStart('?').Split("&"))
            {
                var items = query.Split("=");
                key = items.Count() >= 1 ? items[0] : string.Empty;
                value = items.Count() >= 2 ? items[1] : string.Empty;
                if (!string.IsNullOrEmpty(key))
                {
                    pairs.Add(new KeyValuePair<string, string>(key, value));
                }
            }

            return pairs;
        }

        private async Task<string> ReadBodyFromRequest(HttpRequest request)
        {
            // Ensure the request's body can be read multiple times (for the next middlewares in the pipeline).
            request.EnableBuffering();
            using var streamReader = new StreamReader(request.Body, leaveOpen: true);
            var requestBody = await streamReader.ReadToEndAsync();

            // Reset the request's body stream position for next middleware in the pipeline.
            request.Body.Position = 0;

            return requestBody;
        }
        #endregion

    }
}
