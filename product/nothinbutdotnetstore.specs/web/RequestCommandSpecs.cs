 using Machine.Specifications;
 using Machine.Specifications.DevelopWithPassion.Rhino;
 using nothinbutdotnetstore.web.infrastructure;

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
                 request = an<Request>();
             };

             Because b = () =>
                 result = sut.can_handle(request);

             It should_make_the_determination_by_using_its_request_specification = () =>
                 result.ShouldBeTrue();


             static bool result;
             static Request request;
         }
     }
 }
