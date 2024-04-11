using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CIPlatform.BAL.Interfaces;
using CIPlatform.BAL.Services;
using CIPLATFORM.Interfaces;
using CIPLATFORM.Services;

namespace CIPLATFORM
{
    public static class ServiceCollectionExtensions
    {
        public static void RegisterDependency(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();

            services.AddScoped<ICommonService, CommonService>();

            services.AddScoped<IMissionService, MissionService>();

            services.AddScoped<IStoryService, StoryService>();
        }
    }
}