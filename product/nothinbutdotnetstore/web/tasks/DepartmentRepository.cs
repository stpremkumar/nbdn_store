using System.Collections.Generic;
using nothinbutdotnetstore.web.application.model;

namespace nothinbutdotnetstore.web.tasks
{
    public interface DepartmentRepository
    {
        IEnumerable<DepartmentItem> get_the_main_departments();
    }
}