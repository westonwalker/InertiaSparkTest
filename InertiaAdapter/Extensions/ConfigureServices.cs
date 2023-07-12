﻿using InertiaAdapter.Core;
using InertiaAdapter.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace InertiaAdapter.Extensions
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddInertia(this IServiceCollection services)
        {
            services.AddSingleton<IResultFactory, ResultFactory>();
            return services;
        }
    }
}