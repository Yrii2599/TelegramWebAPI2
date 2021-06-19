using Microsoft.Extensions.DependencyInjection;

namespace AbstractionsLayer
{
    public interface IServices
    {
        void Initialise(IServiceCollection services);
    }
}
