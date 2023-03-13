using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TPNivel3
{
    /// <summary>
    /// Descripción breve de Global
    /// </summary>
    public class Global : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.Write("Hola a todos");
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}