 using System.Collections.Generic;
 using System.Linq;
 using Machine.Specifications;
 using Machine.Specifications.DevelopWithPassion.Rhino;
 using nothinbutdotnetstore.web.infrastructure;
 using Machine.Specifications.DevelopWithPassion.Extensions;
 using Rhino.Mocks;

namespace nothinbutdotnetstore.specs.web
 {   
     public class RequestCommandRegistrySpecs
     {
         public abstract class concern : Observes<RequestCommandRegistry,
                                             DefaultRequestCommandRegistry>
         {
             Establish c = () =>
             {
                 all_commands = new List<RequestCommand>();
                 request = an<Request>();
                 Enumerable.Range(1,100).each(x => all_commands.Add(an<RequestCommand>()));
                 provide_a_basic_sut_constructor_argument<IEnumerable<RequestCommand>>(all_commands);
             };

             protected static IList<RequestCommand> all_commands;
             protected static Request request;
         }

         [Subject(typeof(DefaultRequestCommandRegistry))]
         public class when_retrieving_a_command_that_can_process_a_request_and_it_has_the_command : concern
         {
             Establish c = () =>
             {
                 the_command_that_can_process_the_request = an<RequestCommand>();
                 all_commands.Add(the_command_that_can_process_the_request);
                 the_command_that_can_process_the_request.Stub(command => command.can_handle(request)).Return(true);
             };

             Because b = () =>
                 result = sut.get_the_command_that_can_process(request);

        
             It should_return_the_command_that_can_process_the_request = () =>        
                 result.ShouldEqual(the_command_that_can_process_the_request);

             static RequestCommand result;
             static RequestCommand the_command_that_can_process_the_request;
         }

         [Subject(typeof(DefaultRequestCommandRegistry))]
         public class when_retrieving_a_command_that_can_process_a_request_and_it_does_not_have_the_command : concern
         {
             Because b = () =>
                 result = sut.get_the_command_that_can_process(request);


             It should_return_the_command_that_can_process_the_request = () =>
                 result.ShouldBeAn<MissingRequestCommand>();

             static RequestCommand result;
         }
     }
 }
