namespace nothinbutdotnetstore.web.infrastructure.frontcontroller
{
    public class DefaultFrontController : FrontController
    {
        CommandRegistry registry;

        public DefaultFrontController():this(new DefaultCommandRegistry())
        {
        }

        public DefaultFrontController(CommandRegistry registry)
        {
            this.registry = registry;
        }

        public void process(Request request)
        {
            registry.get_the_command_that_can_process(request).process(request);
        }
    }
}