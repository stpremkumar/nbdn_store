namespace nothinbutdotnetstore.web.infrastructure.frontcontroller
{
    public interface RequestCommand : ApplicationCommand
    {
        bool can_handle(Request request);
    }
}