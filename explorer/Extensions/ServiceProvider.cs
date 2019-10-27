using System;
using Microsoft.Extensions.DependencyInjection;

namespace explorer.Extensions
{
    public static class ServiceProvider
    {
        private static IServiceProvider _provider;

        public static void Setup(IServiceCollection services)
        {
            _provider = services.BuildServiceProvider();
        }

        public static T Resolve<T>()
        {
            return _provider.GetRequiredService<T>();
        }
    }
}