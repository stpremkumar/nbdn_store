namespace nothinbutdotnetstore.web.infrastructure
{
    public class DefaultFrontController : FrontController
    {
        readonly RequestCommandRegistry registry;

        public DefaultFrontController(RequestCommandRegistry registry)
        {
            this.registry = registry;
        }

        public void process(Request request)
        {
            RequestCommand rc = registry.get_the_command_that_can_process(request);
            rc.process(request);
        }
    }
}