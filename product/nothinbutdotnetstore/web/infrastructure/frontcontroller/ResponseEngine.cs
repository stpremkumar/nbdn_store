namespace nothinbutdotnetstore.web.infrastructure.frontcontroller
{
    public interface ResponseEngine
    {
        void display<ViewModel>(ViewModel view_model);
    }
}