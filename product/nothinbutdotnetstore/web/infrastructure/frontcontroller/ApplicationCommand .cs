using nothinbutdotnetstore.web.application;

namespace nothinbutdotnetstore.web.infrastructure.frontcontroller
{
    public interface ApplicationCommand 
    {
        Response process(Request request);
    }
}