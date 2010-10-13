using System.Web;

namespace nothinbutdotnetstore.web.infrastructure.frontcontroller.stubs
{
    public class StubRequestFactory : RequestFactory
    {
        public Request create_request_from(HttpContext http_context)
        {
            return new StubRequest();
        }

        class StubRequest : Request
        {
        }
    }
}