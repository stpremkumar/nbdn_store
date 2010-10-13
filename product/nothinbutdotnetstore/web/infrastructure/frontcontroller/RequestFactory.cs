using System.Web;

namespace nothinbutdotnetstore.web.infrastructure.frontcontroller
{
    public interface RequestFactory
    {
        Request create_request_from(HttpContext http_context);
    }
}