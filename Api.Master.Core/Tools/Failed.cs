using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Api.Master.Core.Tools
{
    public class Failed : JsonResult
    {
        private HttpStatusCode _statusCode = HttpStatusCode.BadRequest;
        private Exception _ex = null;

        public Failed() : this(HttpStatusCode.BadRequest)
        {
        }

        public Failed(HttpStatusCode statusCode, Exception ex = null) : base(ex)
        {
            _statusCode = statusCode;
            _ex = ex;
        }

        public override void ExecuteResult(ActionContext context)
        {
            context.HttpContext.Response.StatusCode = (int)_statusCode;
            base.ExecuteResult(context);
        }

        public override Task ExecuteResultAsync(ActionContext context)
        {
            Dictionary<string, object> response = new Dictionary<string, object>();
            response.Add("isSuccess", false);
            response.Add("statusCode", _statusCode);
            response.Add("error", _ex.Message);
            response.Add("exception",JsonConvert.SerializeObject(_ex));
            var json = JsonConvert.SerializeObject(response);
            context.HttpContext.Response.StatusCode = (int)_statusCode;
            context.HttpContext.Response.ContentType = "application/json";
            context.HttpContext.Response.WriteAsync(json);
            return base.ExecuteResultAsync(context);
        }
    }
}
