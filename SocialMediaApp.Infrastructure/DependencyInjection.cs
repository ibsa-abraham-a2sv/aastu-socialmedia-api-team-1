using Microsoft.Extensions.DependencyInjection;
using SocialMediaApp.Infrastructure.Authentication;
using SocialMediaApp.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialMediaApp.Application.Persistence.Contracts.Common;
using SocialMediaApp.Application.Persistence.Contracts.Common.Services;
using SocialMediaApp.Infrastructure.Services;
using Microsoft.Extensions.Configuration;

namespace SocialMediaApp.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, ConfigurationManager configuration)
        {
            services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));
            services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
            services.AddSingleton<IDateTimeProvider, DayTimeProvider>();
            return services;
        }
    }
}
