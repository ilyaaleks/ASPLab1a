using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab01a.handler
{
    public class AIA : IHttpHandler
    {
        public bool IsReusable => true;

        public void ProcessRequest(HttpContext context)
        {
            HttpRequest request = context.Request;
            HttpResponse response = context.Response;
            string requestType = request.HttpMethod.ToLower();
            response.ContentType = "text/plain";
            if (requestType.Equals("get"))
            {
                getHandler(request, response);
            }
            else if (requestType.Equals("post"))
            {
                postHandler(request, response);
            }
            else if(requestType.Equals("put"))
            {
                putHandler(request, response);
            }
            else
            {
                response.StatusCode = 405;
                response.End();
            }
        }
        public void getHandler(HttpRequest request, HttpResponse response)
        {
            String parmA = request.QueryString["ParmA"];
            String parmB = request.QueryString["ParmB"];
            response.Write($"AIA:ParmA = {parmA},ParmB = {parmB}");
            
        }
        public void postHandler(HttpRequest request, HttpResponse response)
        {
           
            String parmA = request.Params["parmA"];
            String parmB = request.Params["parmB"];
            response.Write($"AIA:ParmA = {parmA},ParmB = {parmB}");
            
        }
        public void putHandler(HttpRequest request, HttpResponse response)
        {
            String parmA = request.Params["parmA"];
            String parmB = request.Params["parmB"];
            response.Write($"AIA:ParmA = {parmA},ParmB = {parmB}");
        }
    }
}