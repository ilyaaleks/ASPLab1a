using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab01a.handler
{
    public class PostFormHandler:IHttpHandler
    {
        public bool IsReusable => true;

        public void ProcessRequest(HttpContext context)
        {
            HttpRequest request = context.Request;
            HttpResponse response = context.Response;
            string requestType = request.HttpMethod.ToLower();
            if (requestType.Equals("get"))
            {
                getHandler(request, response);
            }
            else if (requestType.Equals("post"))
            {
                postHandler(request, response);
            }
            else
            {
                response.StatusCode = 405;
                response.End();
            }
        }
        public void getHandler(HttpRequest request, HttpResponse response)
        {
            response.TransmitFile("static/FormClient.html");

        }
        public void postHandler(HttpRequest request, HttpResponse response)
        {

            int x = Convert.ToInt32(request.Params["x"]);
            int y = Convert.ToInt32(request.Params["y"]);
            response.ContentType = "text/plain";
            response.Write(x + y);

        }
    }
}