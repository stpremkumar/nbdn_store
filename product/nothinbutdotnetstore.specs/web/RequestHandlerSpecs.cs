 using System.Web;
 using Machine.Specifications;
 using Machine.Specifications.DevelopWithPassion.Rhino;
 using nothinbutdotnetstore.specs.utilities;
 using nothinbutdotnetstore.web.infrastructure;
 using Rhino.Mocks;

namespace nothinbutdotnetstore.specs.web
 {   
     public class RequestHandlerSpecs
     {
         public abstract class concern : Observes<IHttpHandler,
                                             RequestHandler>
         {
        
         }

         [Subject(typeof(RequestHandler))]
         public class when_processing_an_incoming_http_context : concern
         {
             Establish c = () =>
             {
                 front_controller = the_dependency<FrontController>();
                 request_factory = the_dependency<RequestFactory>();
                 the_http_context = ObjectMother.create_http_context();
                 request = an<Request>();

                 request_factory.Stub(factory => factory.create_request_from(the_http_context)).Return(request);
             };

             Because b = () =>
                 sut.ProcessRequest(the_http_context);

             It should_delegate_the_processing_of_a_request_to_our_front_controller = () =>
                 front_controller.received(controller => controller.process(request));

             static FrontController front_controller;
             static Request request;
             static HttpContext the_http_context;
             static RequestFactory request_factory;
         }
     }
 }
