using System;
using Microsoft.Extensions.DependencyInjection;

namespace explorer.Utils
{
    public static class ServiceProvider
    {
        private static IServiceProvider _provider;
        private static IServiceCollection _services;

        static ServiceProvider()
        {
            _services = new ServiceCollection();
        }
        
        public static void Setup(IServiceCollection services)
        {
            _provider = services.BuildServiceProvider();
            _services = services;
        }

        public static T Resolve<T>()
        {
            return _provider.GetRequiredService<T>();
        }

        public static void AddSingleton<TImplementation>(Func<IServiceProvider, TImplementation> implementationFactory) where TImplementation : class
        {
            _services.AddSingleton<TImplementation>(implementationFactory);
            _provider = _services.BuildServiceProvider();
        }
    }
}