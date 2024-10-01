﻿using ClientesApp.Domain.Entities;
using ClientesApp.Domain.Interfaces.Services;
using ClientesApp.Domain.Services;
using ClientesApp.Domain.Validations;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace ClientesApp.Domain.Extensions
{
    public static class ClienteDomainServiceExtension
    {
        public static IServiceCollection AddDomainService(this IServiceCollection services)
        {
            services.AddTransient<IClienteDomainService, ClienteDomainService>();
            services.AddTransient<IValidator<Cliente>, ClienteValidator>();

            return services;
        }
    }
}
