using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Rest;
using Newtonsoft.Json;

namespace WebAPIAuthentication
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class APIAuthorization
    {
        private readonly RequestDelegate _next;
        private IConfiguration _config;
        public APIAuthorization(RequestDelegate next, IConfiguration config)
        {
            _next = next;
            _config = config;

        }

        public async Task Invoke(HttpContext httpContext)
        {


            httpContext.Response.ContentType = "application/json";
            if (!httpContext.Request.Headers.Keys.Contains("apikey"))
            {

                string badrequestString = JsonConvert.SerializeObject(GetStausObject(true));
                await httpContext.Response.WriteAsync(badrequestString);
                return;

            }

            if (!ApiKeyValidation(httpContext))
            {
                string badrequestString = JsonConvert.SerializeObject(GetStausObject(false));
                await httpContext.Response.WriteAsync(badrequestString);
                return;
            }

            await _next.Invoke(httpContext);


        }


        private object GetStausObject(bool isbadRequest)
        {
            return new Result()
            {
                Data = null,
                StatusMessage = isbadRequest == true ? "Bad Request" : "Unauthorized Access",
                StatusCode = 101,
                version = "1.0"
            };
        }

        private bool ApiKeyValidation(HttpContext ctx)
        {

            string headerapikey = ctx.Request.Headers["apikey"].ToString();
            string configapikey = _config["appsettings:apikey"];
            if (string.Compare(EncodeKey(configapikey), DecodeKey(headerapikey), StringComparison.OrdinalIgnoreCase) == 0)
            {
                return true;
            }
            return false;
        }
        public string EncodeKey(string encodedstring)
        {
            byte[] encodedBytes = System.Text.Encoding.Unicode.GetBytes(encodedstring);
            string encodedTxt = Convert.ToBase64String(encodedBytes);
            return encodedTxt;
        }

        public string DecodeKey(string encodedstring)
        {
            byte[] decodedBytes = Convert.FromBase64String(Convert.ToBase64String(System.Text.Encoding.Unicode.GetBytes(encodedstring)));
            string decodedTxt2 = System.Text.Encoding.Unicode.GetString(decodedBytes);
            return decodedTxt2;
        }
    }



    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class APIAuthorizationExtensions
    {
        public static IApplicationBuilder UseApiAuthorization(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<APIAuthorization>();
        }
    }
}
