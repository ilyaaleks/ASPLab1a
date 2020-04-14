using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab01a.handler
{
    public class SumHandler : IHttpHandler
    {
        public bool IsReusable => true;

        public void ProcessRequest(HttpContext context)
        {
            HttpRequest request = context.Request;
            HttpResponse response = context.Response;
            int x= Convert.ToInt32(request.Params["X"]);
            int y =Convert.ToInt32(request.Params["Y"]);
            response.ContentType = "text/html";
            response.Write(x+y);
        }
    }
}