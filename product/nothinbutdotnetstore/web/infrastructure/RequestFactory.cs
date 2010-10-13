using System.Web;

namespace nothinbutdotnetstore.web.infrastructure
{
    public interface RequestFactory
    {
        Request create_request_from(HttpContext http_context);
    }
}