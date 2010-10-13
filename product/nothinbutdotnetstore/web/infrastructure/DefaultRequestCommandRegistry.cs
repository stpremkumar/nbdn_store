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
            //MissingRequestCommand mrc = new MissingRequestCommand();
            foreach (var item in all_commands)
            {
                if (item.can_handle(request))
                return item;
            }
            return new MissingRequestCommand();
        }
    }
}