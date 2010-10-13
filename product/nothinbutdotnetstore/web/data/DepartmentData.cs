using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace nothinbutdotnetstore.web.data
{
    public interface DepartmentData
    {
        IEnumerable<string> get_department_data();
    }
    public class StaticDepartmentData : DepartmentData
    {

        public IEnumerable<string> get_department_data()
        {
            throw new NotImplementedException();
        }
    }
}
