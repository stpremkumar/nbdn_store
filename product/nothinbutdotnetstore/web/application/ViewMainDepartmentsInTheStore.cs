using nothinbutdotnetstore.web.infrastructure.frontcontroller;
using nothinbutdotnetstore.web.infrastructure.frontcontroller.stubs;
using nothinbutdotnetstore.web.tasks;
using nothinbutdotnetstore.web.tasks.stubs;

namespace nothinbutdotnetstore.web.application
{
    public class ViewMainDepartmentsInTheStore : ApplicationCommand
    {
        DepartmentRepository department_repository;
        ResponseEngine response_engine;

        public ViewMainDepartmentsInTheStore() : this(new StubDepartmentRepository(), new StubResponseEngine())
        {
        }

        public ViewMainDepartmentsInTheStore(DepartmentRepository department_repository, ResponseEngine response_engine)
        {
            this.department_repository = department_repository;
            this.response_engine = response_engine;
        }

        public void process(Request request)
        {
            response_engine.display(department_repository.get_the_main_departments());
        }
    }
}