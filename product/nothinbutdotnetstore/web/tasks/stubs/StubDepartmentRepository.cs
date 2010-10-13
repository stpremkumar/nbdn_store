using System.Collections.Generic;
using System.Linq;
using nothinbutdotnetstore.web.application.model;

namespace nothinbutdotnetstore.web.tasks.stubs
{
    public class StubDepartmentRepository : DepartmentRepository
    {
        public IEnumerable<DepartmentItem> get_the_main_departments()
        {
            return Enumerable.Range(1, 1000).Select(x => new DepartmentItem {name = x.ToString("Department 0")});
        }
    }
}