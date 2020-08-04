using System;
using DynamicViewModule.Drivers;
using DynamicViewModule.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using OrchardCore.ContentManagement;
using OrchardCore.ContentManagement.Display.ContentDisplay;
using OrchardCore.Data.Migration;
using OrchardCore.Modules;
using OrchardCore.ResourceManagement;

namespace DynamicViewModule
{
    public class Startup : StartupBase
    {
        public override void ConfigureServices(IServiceCollection services)
        {
            services.AddContentPart<DataTablePart>()
                .UseDisplayDriver<DataTablePartDisplay>();
            services.AddScoped<IDataMigration, Migrations.Migrations>();

            services.AddScoped<IResourceManifestProvider, ResourceManifest>();
        }

        public override void Configure(IApplicationBuilder builder, IEndpointRouteBuilder routes, IServiceProvider serviceProvider)
        {


        }
    }
}
