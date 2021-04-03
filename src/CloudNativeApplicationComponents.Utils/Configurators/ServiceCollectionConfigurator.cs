using Microsoft.Extensions.DependencyInjection;
using System;

namespace CloudNativeApplicationComponents.Utils.Configurators
{
    public class ServiceCollectionConfigurator
    {
        public IServiceCollection ServiceCollection { get; }

        public ServiceCollectionConfigurator(IServiceCollection collection)
        {
            ServiceCollection = collection
                ?? throw new ArgumentNullException(nameof(collection));
        }
    }
}
