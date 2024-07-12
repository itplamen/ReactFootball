using Microsoft.Extensions.DependencyInjection;

namespace ReactFootball.Infrastructure.IoCContainer.Contracts
{
    public interface IPackage
    {
        void RegisterServices(IServiceCollection services);
    }
}
