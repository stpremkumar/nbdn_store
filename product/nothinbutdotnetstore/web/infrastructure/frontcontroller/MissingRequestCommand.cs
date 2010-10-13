using System;
using nothinbutdotnetstore.web.application;

namespace nothinbutdotnetstore.web.infrastructure.frontcontroller
{
    public class MissingRequestCommand  : RequestCommand
    {
        public Response process(Request request)
        {
            throw new NotImplementedException();
        }

        public bool can_handle(Request request)
        {
            throw new NotImplementedException();
        }
    }
}