

namespace nothinbutdotnetstore.web.infrastructure
{
    public interface RequestCommandSpecification
    {
        bool Satisfies(Request request);
    }
}
