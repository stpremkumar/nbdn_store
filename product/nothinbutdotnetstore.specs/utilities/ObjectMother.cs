using System.IO;
using System.Web;

namespace nothinbutdotnetstore.specs.utilities
{
    public class ObjectMother
    {
        public static HttpContext create_http_context()
        {
            return new HttpContext(create_request(), create_response());
        }

        static HttpRequest create_request()
        {
            return new HttpRequest("blah.aspx", "http://localhost/blah.asxp", string.Empty);
        }

        static HttpResponse create_response()
        {
            return new HttpResponse(new StringWriter());
        }
    }
}