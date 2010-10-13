using System;
using System.Collections.Generic;

namespace nothinbutdotnetstore.web.infrastructure
{
    public class DefaultRequestCommandRegistry : RequestCommandRegistry
    {
        IEnumerable<RequestCommand> commands;
        public DefaultRequestCommandRegistry(IEnumerable<RequestCommand> commands)
        {
            this.commands = commands;
        }

        public RequestCommand get_the_command_that_can_process(Request request)
        {
            RequestCommand rc = commands.GetEnumerator().Current;
            return rc;

            //throw new NotImplementedException();
        }

    }
}