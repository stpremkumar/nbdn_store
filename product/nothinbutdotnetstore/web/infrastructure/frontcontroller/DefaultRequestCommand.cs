namespace nothinbutdotnetstore.web.infrastructure.frontcontroller
{
    public class DefaultRequestCommand : RequestCommand
    {
        RequestCommandSpecification request_command_specification;
        ApplicationCommand application_command;

        public DefaultRequestCommand(RequestCommandSpecification request_command_specification,
                                     ApplicationCommand application_command)
        {
            this.request_command_specification = request_command_specification;
            this.application_command = application_command;
        }

        public void process(Request request)
        {
            application_command.process(request);
        }

        public bool can_handle(Request request)
        {
            return request_command_specification(request);
        }
    }
}