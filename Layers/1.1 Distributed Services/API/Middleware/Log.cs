using System.IO;
using System.Threading.Tasks;
using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.DataContracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;

namespace Coworking.API.Middleware
{
    public class Log
    {
        private readonly RequestDelegate _next;
        private readonly TelemetryClient _telemetryClient;

        public Log(RequestDelegate next, TelemetryClient telemetryClient)
        {
            _next = next;
            _telemetryClient = telemetryClient;
        }

        public async Task Invoke(HttpContext context)
        {
            var requesBodyStream = new MemoryStream();
            var originalRequestBody = context.Request.Body;

            await context.Request.Body.CopyToAsync(requesBodyStream);
            requesBodyStream.Seek(0, SeekOrigin.Begin);

            var url = UriHelper.GetDisplayUrl(context.Request);
            var resquestBodyText = new StreamReader(requesBodyStream).ReadToEnd();

            requesBodyStream.Seek(0, SeekOrigin.Begin);
            context.Request.Body = requesBodyStream;

            await _next(context);

            context.Request.Body = originalRequestBody;

            Tracerequest(resquestBodyText, url, context.Request.Method);
        }

        private void Tracerequest(string payload, string url, string method)
        {
            var telemetry = new TraceTelemetry("TRAZA PERSONALIZADA: " + url);

            telemetry.Properties.Add("Body", payload);
            telemetry.Properties.Add("Method", method);
           _telemetryClient.TrackTrace(telemetry);
        }
    }
}