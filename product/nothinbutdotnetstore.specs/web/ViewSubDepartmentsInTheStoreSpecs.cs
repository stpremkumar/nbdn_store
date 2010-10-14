using System.Collections.Generic;
using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Rhino;
using nothinbutdotnetstore.web.application;
using nothinbutdotnetstore.web.application.model;
using nothinbutdotnetstore.web.infrastructure.frontcontroller;
using nothinbutdotnetstore.web.tasks;
using Rhino.Mocks;

namespace nothinbutdotnetstore.specs.web
{
    public class ViewSubMainDepartmentsInTheStoreSpecs
    {
        public abstract class concern : Observes<ApplicationCommand, ViewSubDepartmentsInTheStore>
        {
        }

        [Subject(typeof(ViewSubDepartmentsInTheStore))]
        public class when_displaying_the_set_of_sub_departments_in_the_store : concern
        {
            Establish c = () =>
            {
                sub_department_repository = the_dependency<SubDepartmentRepository>();
                sub_department_list = new List<SubDepartmentItem> { };
                request = an<Request>();
                response_engine = the_dependency<ResponseEngine>();

                sub_department_repository.Stub(x => x.get_the_sub_departments()).Return(sub_department_list);
            };

            Because b = () =>
                sut.process(request);

            It should_tell_the_response_engine_to_display_the_list_of_departments =
                () => { response_engine.received(x => x.display(sub_department_list)); };

            protected static Request request;
            protected static IEnumerable<SubDepartmentItem> sub_department_list;
            protected static SubDepartmentRepository sub_department_repository;
            static ResponseEngine response_engine;
        }
    }
}