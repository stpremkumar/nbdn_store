namespace nothinbutdotnetstore.web.infrastructure.frontcontroller
{
    public class DefaultRequestFactory :RequestFactory
    {
        public DefaultRequestFactory()
        {
        }

        public Request create_request_from(System.Web.HttpContext http_context)
        {
            throw new System.NotImplementedException();
        }
    }
}