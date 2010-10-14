using nothinbutdotnetstore.web.infrastructure.frontcontroller;
using nothinbutdotnetstore.web.infrastructure.frontcontroller.stubs;
using nothinbutdotnetstore.web.tasks;
using nothinbutdotnetstore.web.tasks.stubs;

namespace nothinbutdotnetstore.web.application
{
    public class ViewSubDepartmentsInTheStore : ApplicationCommand
    {
        SubDepartmentRepository subdepartment_repository;
        ResponseEngine response_engine;

        //public ViewSubDepartmentsInTheStore()
        //    : this(new StubDepartmentRepository(), new StubResponseEngine())
        //{
        //}

        public ViewSubDepartmentsInTheStore(SubDepartmentRepository subdepartment_repository, ResponseEngine response_engine)
        {
            this.subdepartment_repository = subdepartment_repository;
            this.response_engine = response_engine;
        }

        public void process(Request request)
        {
            response_engine.display(subdepartment_repository.get_the_sub_departments());
        }
    }
}