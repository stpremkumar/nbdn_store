namespace nothinbutdotnetstore.web.infrastructure.frontcontroller
{
    public interface ApplicationCommand
    {
        void process(Request request);
    }
}