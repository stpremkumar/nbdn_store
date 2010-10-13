using System;
using System.Web;

namespace nothinbutdotnetstore.web.infrastructure
{
    public class RequestHandler : IHttpHandler
    {
        
        RequestFactory request_factory;
        FrontController front_controller;

        public RequestHandler(RequestFactory request_factory, FrontController front_controller)
        {
            this.request_factory = request_factory;
            this.front_controller = front_controller;
        }
        public void ProcessRequest(HttpContext context)
        {
            var request = request_factory.create_from(context);
            front_controller.process(request);
        }

        public bool IsReusable
        {
            get { throw new NotImplementedException(); }
        }
    }
}