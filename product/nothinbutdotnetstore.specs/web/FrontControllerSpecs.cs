 using Machine.Specifications;
 using Machine.Specifications.DevelopWithPassion.Rhino;
 using nothinbutdotnetstore.web.infrastructure;
 using Rhino.Mocks;

namespace nothinbutdotnetstore.specs.web
 {   
     public class FrontControllerSpecs
     {
         public abstract class concern : Observes<FrontController,
                                             DefaultFrontController>
         {
        
         }

         [Subject(typeof(DefaultFrontController))]
         public class when_processing_a_request : concern
         {
             Establish c = () =>
             {
                 request_command_registry = the_dependency<RequestCommandRegistry>();
                 command_that_can_process_the_request = an<RequestCommand>();
                 request = an<Request>();

                 request_command_registry.Stub(registry => registry.get_the_command_that_can_process(request)).Return(
                     command_that_can_process_the_request);
             };

             Because b = () =>
                 sut.process(request);

             It should_delegate_the_processing_to_the_command_that_can_process_the_request = () =>
                 command_that_can_process_the_request.received(command => command.process(request));

             static RequestCommand command_that_can_process_the_request;
             static Request request;
             static RequestCommandRegistry request_command_registry;
         }
     }
 }
