using System.Web;

namespace nothinbutdotnetstore.web.infrastructure.frontcontroller.stubs
{
    public class StubResponseEngine : ResponseEngine
    {
        public void display<ViewModel>(ViewModel view_model)
        {
            HttpContext.Current.Items.Add("blah",view_model);
            HttpContext.Current.Server.Transfer("~/views/DepartmentBrowser.aspx", true);
        }
    }
}