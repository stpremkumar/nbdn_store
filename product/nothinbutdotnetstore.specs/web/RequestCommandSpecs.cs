 using Machine.Specifications;
 using Machine.Specifications.DevelopWithPassion.Rhino;
 using nothinbutdotnetstore.web.infrastructure;
using Rhino.Mocks;

namespace nothinbutdotnetstore.specs.web
 {   
     public class RequestCommandSpecs
     {
         public abstract class concern : Observes<RequestCommand,
                                             DefaultRequestCommand>
         {
        
         }

         [Subject(typeof(DefaultRequestCommand))]
         public class when_determinining_if_it_can_process_a_request : concern
         {
             Establish c = () =>
             {
                 request_command_specification = the_dependency<RequestCommandSpecification>();
                 request = an<Request>();

                 request_command_specification.Stub(x => x.Satisfies(request)).Return(true);
             };

             Because b = () =>
                 result = sut.can_handle(request);

             It should_make_the_determination_by_using_its_request_specification = () =>
                 result.ShouldBeTrue();


             static bool result;
             static Request request;
             static RequestCommandSpecification request_command_specification;
         }
     }

     
 }
