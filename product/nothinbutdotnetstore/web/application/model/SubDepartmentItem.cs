using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace nothinbutdotnetstore.web.application.model
{
    public class SubDepartmentItem
    {
        public DepartmentItem departmentItem { get; set; }
        public IEnumerable<DepartmentItem> items { get; set; }
    }
}
