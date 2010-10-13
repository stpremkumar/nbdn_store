using System.Collections.Generic;
using System.Linq;

namespace nothinbutdotnetstore.web.infrastructure
{
    public class DefaultRequestCommandRegistry : RequestCommandRegistry
    {
        IEnumerable<RequestCommand> all_commands;

        public DefaultRequestCommandRegistry(IEnumerable<RequestCommand> all_commands)
        {
            this.all_commands = all_commands;
        }

        public RequestCommand get_the_command_that_can_process(Request request)
        {
            return all_commands.FirstOrDefault(x => x.can_handle(request)) ?? new MissingRequestCommand();
        }
    }
}