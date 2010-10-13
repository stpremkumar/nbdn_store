namespace nothinbutdotnetstore.web.infrastructure
{
    public interface RequestCommand
    {
        void process(Request request);
        bool can_handle(Request request);
    }
}