using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Api.Master.Core.Tools
{
    public class Success : JsonResult
    {
        private HttpStatusCode _statusCode = HttpStatusCode.OK;
        private object _data = null;
        private List<string> _messages;

        public Success() : this(HttpStatusCode.OK)
        {
        }

        public Success(object json = null, List<string> messages = null) : base(json)
        {
            _messages = messages;
            _data = json;
        }

        public override void ExecuteResult(ActionContext context)
        {
            context.HttpContext.Response.StatusCode = (int)_statusCode;
            base.ExecuteResult(context);
        }

        public override Task ExecuteResultAsync(ActionContext context)
        {
            Dictionary<string, object> response = new Dictionary<string, object>();
            response.Add("isSuccess", true);
            response.Add("statusCode", _statusCode);
            response.Add("data", _data);
            response.Add("messages", _messages);
            var json = JsonConvert.SerializeObject(response);
            context.HttpContext.Response.StatusCode = (int)_statusCode;
            context.HttpContext.Response.ContentType = "application/json";
            context.HttpContext.Response.WriteAsync(json);
            return base.ExecuteResultAsync(context);
        }
    }
}
