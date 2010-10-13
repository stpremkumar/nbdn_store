using System;

namespace nothinbutdotnetstore.web.infrastructure
{
    public class DefaultFrontController : FrontController
    {
        RequestCommandRegistry registry;

        public DefaultFrontController(RequestCommandRegistry registry)
        {
            this.registry = registry;
        }

        public void process(Request request)
        {
            registry.get_the_command_that_can_process(request).process(request);
        }
    }
}