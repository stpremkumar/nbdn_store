using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Rhino;
using nothinbutdotnetstore.web.infrastructure;
using nothinbutdotnetstore.web.infrastructure.frontcontroller;

namespace nothinbutdotnetstore.specs.web
{
    public class RequestCommandSpecs
    {
        public abstract class concern : Observes<RequestCommand,
                                            DefaultRequestCommand>
        {
            Establish c = () =>
            {
                provide_a_basic_sut_constructor_argument<RequestCommandSpecification>(x => true);
                request = an<Request>();
            };

            protected static Request request;
        }

        [Subject(typeof(DefaultRequestCommand))]
        public class when_determinining_if_it_can_process_a_request : concern
        {
            Because b = () =>
                result = sut.can_handle(request);

            It should_make_the_determination_by_using_its_request_specification = () =>
                result.ShouldBeTrue();

            static bool result;
        }

        [Subject(typeof(DefaultRequestCommand))]
        public class when_processing_a_request : concern
        {
            Establish c = () =>
            {
                application_command = the_dependency<ApplicationCommand>();
            };

            Because b = () =>
                sut.process(request);

            It should_delegate_the_processing_to_the_application_specific_command = () =>
                application_command.received(command => command.process(request));

            static ApplicationCommand application_command;
        }
    }
}