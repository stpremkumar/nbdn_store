using System.Collections.Generic;

namespace nothinbutdotnetstore.web.application
{
    public class DepartmentsResponse : Response
    {
        public DepartmentsResponse(IEnumerable<string> departments)
        {
            this.departments = departments;
        }

        public IEnumerable<string> departments;
    }
}