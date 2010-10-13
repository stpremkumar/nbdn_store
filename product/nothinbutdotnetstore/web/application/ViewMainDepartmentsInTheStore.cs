using System;
using System.Web;
using nothinbutdotnetstore.web.data;
using nothinbutdotnetstore.web.infrastructure.frontcontroller;

namespace nothinbutdotnetstore.web.application
{
    public class ViewMainDepartmentsInTheStore : ApplicationCommand
    {
        DepartmentData department_data;

        public ViewMainDepartmentsInTheStore(DepartmentData department_data)
        {
            this.department_data = department_data;
        }

        public Response process(Request request)
        {
            return new DepartmentsResponse(department_data.get_department_data());
        }
    }
}