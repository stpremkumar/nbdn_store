using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using nothinbutdotnetstore.web.application.model;

namespace nothinbutdotnetstore.web.tasks
{
    public interface SubDepartmentRepository
    {
        IEnumerable<SubDepartmentItem> get_the_sub_departments();
    }
}
